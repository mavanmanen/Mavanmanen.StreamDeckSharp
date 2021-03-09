using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mavanmanen.StreamDeckSharp.Internal.Client
{
    internal class WebSocketClient : IWebSocketClient
    {
        private ClientWebSocket? _socket;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private const int BUFFER_SIZE = 1048576;

        public event EventHandler<string>? MessageReceived;

        public async Task<bool> ConnectAsync(int port)
        {
            if (_socket != null)
            {
                throw new InvalidOperationException("Already running.");
            }

            try
            {
                _socket = new ClientWebSocket();
                await _socket.ConnectAsync(new Uri($"ws://localhost:{port}"), _cancellationTokenSource.Token);
                while (_socket.State == WebSocketState.Connecting)
                {
                    await Task.Delay(500, _cancellationTokenSource.Token);
                }

                if (_socket.State != WebSocketState.Open)
                {
                    await DisconnectAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                await DisconnectAsync();
            }
        }

        private async Task DisconnectAsync()
        {
            if (_socket == null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();

            ClientWebSocket socket = _socket;
            _socket = null;
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Disconnecting", _cancellationTokenSource.Token);
            socket.Dispose();
        }

        public async Task SendAsync(string message)
        {
            if (_socket == null)
            {
                return;
            }

            try
            {
                await _semaphore.WaitAsync();

                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await _socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, _cancellationTokenSource.Token);
            }
            catch (Exception)
            {
                await DisconnectAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task ReceiveAsync()
        {
            var buffer = new byte[BUFFER_SIZE];
            var arrayBuffer = new ArraySegment<byte>(buffer);
            var textBuffer = new StringBuilder(BUFFER_SIZE);

            while (_socket != null && _socket.State == WebSocketState.Open && !_cancellationTokenSource.IsCancellationRequested)
            {
                textBuffer.Clear();
                WebSocketReceiveResult? result;

                try
                {
                    result = await _socket.ReceiveAsync(arrayBuffer, _cancellationTokenSource.Token);
                }
                catch (Exception)
                {
                    continue;
                }

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    return;
                }

                textBuffer.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                if (!result.EndOfMessage)
                {
                    continue;
                }

                var json = textBuffer.ToString();
                MessageReceived?.Invoke(this, json);
            }
        }

    }
}