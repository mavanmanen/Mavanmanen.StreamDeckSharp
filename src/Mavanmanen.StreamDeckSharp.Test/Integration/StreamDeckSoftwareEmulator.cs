using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Test.Integration
{
    internal class StreamDeckSoftwareEmulator : IDisposable
    {
        private enum Opcode : byte
        {
            Fragment = 0x0,
            Text = 0x1,
            Binary = 0x2,
            CloseConnection = 0x8,
            Ping = 0x9,
            Pong = 0xA
        }

        private readonly int _port;
        private readonly string _pluginUUID;
        private readonly Socket _socket;

        private Socket _clientSocket;
        private bool _connected;

        public StreamDeckSoftwareEmulator(int port, string pluginUUID)
        {
            _port = port;
            _pluginUUID = pluginUUID;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Any, _port));
        }

        public string[] Start()
        {
            _socket.Listen(0);
            _socket.BeginAccept(AcceptCallback, null);

            string[] args =
            {
                "-port", $"{_port}",
                "-pluginUUID", _pluginUUID,
                "-registerEvent", "registerEvent",
                "-info", "{}"
            };

            return args;
        }

        public async Task AwaitConnectionAsync()
        {
            while (_connected == false)
            {
                await Task.Delay(100);
            }
        }

        public TMessage ReceiveMessage<TMessage>() where TMessage : Message
        {
            while (_clientSocket.Connected)
            {
                var buffer = new byte[1048576];
                _clientSocket.Receive(buffer);

                byte[] receivedPayload = ParsePayloadFromFrame(buffer);
                string receivedString = Encoding.UTF8.GetString(receivedPayload);
                Message result = Message.FromJson(receivedString);

                if (result is TMessage correctMessage)
                {
                    return correctMessage;
                }
            }

            return null;
        }

        public void SendEvent(StreamDeckEvent streamDeckEvent)
        {
            string json = JsonConvert.SerializeObject(streamDeckEvent);
            byte[] data = CreateFrameFromString(json);
            _clientSocket.Send(data);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            _clientSocket = _socket.EndAccept(ar);
            _clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

            var buffer = new byte[1048576];
            int receivedDataLength = _clientSocket.Receive(buffer);

            string message = Encoding.UTF8.GetString(buffer, 0, receivedDataLength);

            if (Regex.IsMatch(message, "^GET"))
            {
                string receivedWebSocketKey = Regex.Match(message, "Sec-WebSocket-Key: (.*)").Groups[1].Value.Trim();
                byte[] keyHash = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes($"{receivedWebSocketKey}258EAFA5-E914-47DA-95CA-C5AB0DC85B11"));

                var sb = new StringBuilder();
                sb.Append("HTTP/1.1 101 Switching Protocols\r\n");
                sb.Append("Connection: Upgrade\r\n");
                sb.Append("Upgrade: websocket\r\n");
                sb.Append($"Sec-WebSocket-Accept: {Convert.ToBase64String(keyHash)}\r\n\r\n");

                byte[] responseData = Encoding.UTF8.GetBytes(sb.ToString());
                _clientSocket.Send(responseData);
                _connected = true;
            }
        }

        private static bool IsOpCode(byte[] buffer, Opcode opCode)
        {
            return (buffer[0] & (byte)opCode) == (byte)opCode;
        }

        private static byte[] ParsePayloadFromFrame(byte[] incomingFrameBytes)
        {
            var payloadLength = 0L;
            var totalLength = 0L;
            var keyStartIndex = 0L;

            if ((incomingFrameBytes[1] & 0x7F) < 126)
            {
                payloadLength = incomingFrameBytes[1] & 0x7F;
                keyStartIndex = 2;
                totalLength = payloadLength + 6;
            }

            if ((incomingFrameBytes[1] & 0x7F) == 126)
            {
                payloadLength = BitConverter.ToInt16(new[] { incomingFrameBytes[3], incomingFrameBytes[2] }, 0);
                keyStartIndex = 4;
                totalLength = payloadLength + 8;
            }

            if ((incomingFrameBytes[1] & 0x7F) == 127)
            {
                payloadLength = BitConverter.ToInt64(new[] { incomingFrameBytes[9], incomingFrameBytes[8], incomingFrameBytes[7], incomingFrameBytes[6], incomingFrameBytes[5], incomingFrameBytes[4], incomingFrameBytes[3], incomingFrameBytes[2] }, 0);
                keyStartIndex = 10;
                totalLength = payloadLength + 14;
            }

            if (totalLength > incomingFrameBytes.Length)
            {
                throw new Exception("The buffer length is smaller than the data length.");
            }

            long payloadStartIndex = keyStartIndex + 4;

            byte[] key = { incomingFrameBytes[keyStartIndex], incomingFrameBytes[keyStartIndex + 1], incomingFrameBytes[keyStartIndex + 2], incomingFrameBytes[keyStartIndex + 3] };

            var payload = new byte[payloadLength];
            Array.Copy(incomingFrameBytes, payloadStartIndex, payload, 0, payloadLength);
            for (var i = 0; i < payload.Length; i++)
            {
                payload[i] = (byte)(payload[i] ^ key[i % 4]);
            }

            return payload;
        }

        private static byte[] CreateFrameFromString(string message, Opcode opCode = Opcode.Text)
        {
            byte[] frame;

            if (!string.IsNullOrWhiteSpace(message))
            {
                byte[] payload = Encoding.UTF8.GetBytes(message);

                if (payload.Length < 126)
                {
                    frame = new byte[2 + payload.Length];
                    frame[1] = (byte)payload.Length;
                    Array.Copy(payload, 0, frame, 2, payload.Length);
                }
                else if (payload.Length >= 126 && payload.Length <= 65535)
                {
                    frame = new byte[4 + payload.Length];
                    frame[1] = 126;
                    frame[2] = (byte)((payload.Length >> 8) & 255);
                    frame[3] = (byte)(payload.Length & 255);
                    Array.Copy(payload, 0, frame, 4, payload.Length);
                }
                else
                {
                    frame = new byte[10 + payload.Length];
                    frame[1] = 127;
                    frame[2] = (byte)((payload.Length >> 56) & 255);
                    frame[3] = (byte)((payload.Length >> 48) & 255);
                    frame[4] = (byte)((payload.Length >> 40) & 255);
                    frame[5] = (byte)((payload.Length >> 32) & 255);
                    frame[6] = (byte)((payload.Length >> 24) & 255);
                    frame[7] = (byte)((payload.Length >> 16) & 255);
                    frame[8] = (byte)((payload.Length >> 8) & 255);
                    frame[9] = (byte)(payload.Length & 255);
                    Array.Copy(payload, 0, frame, 10, payload.Length);
                }
            }
            else
            {
                frame = new byte[2];
            }

            frame[0] = (byte)((byte)opCode | 0x80);

            return frame;
        }

        public void Dispose()
        {
            _socket.Close();
            _socket?.Dispose();

            _clientSocket.Close();
            _clientSocket?.Dispose();
        }
    }
}
