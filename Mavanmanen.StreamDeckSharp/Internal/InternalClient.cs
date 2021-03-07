using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal
{
    internal class InternalClient
    {
        private const int BUFFER_SIZE = 1048576;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private readonly ClientArguments _arguments;
        private ClientWebSocket? _socket;

        public event EventHandler<StreamDeckActionEvent>? ActionEventReceived;
        public event EventHandler<StreamDeckPluginEvent>? PluginEventReceived;

        public InternalClient(string[] args)
        {
            _arguments = ClientArguments.ParseFromArgs(args);
        }

        public async Task RunAsync()
        {
            if (_socket != null)
            {
                throw new InvalidOperationException("Already running.");
            }

            try
            {
                _socket = new ClientWebSocket();
                await _socket.ConnectAsync(new Uri($"ws://localhost:{_arguments.Port}"), _cancellationTokenSource.Token);
                while (_socket.State == WebSocketState.Connecting)
                {
                    await Task.Delay(500, _cancellationTokenSource.Token);
                }

                if (_socket.State != WebSocketState.Open)
                {
                    await DisconnectAsync();
                }

                await SendAsync(new RegisterEventMessage(_arguments.RegisterEvent, _arguments.UUID));

                await ReceiveAsync();
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

        private async Task ReceiveAsync()
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
                StreamDeckEvent? streamDeckEvent = StreamDeckEvent.FromJson(json);
                if (streamDeckEvent == null)
                {
                    continue;
                }

                switch (streamDeckEvent.Event)
                {
                    case EventTypes.KeyDown:
                    case EventTypes.KeyUp:
                    case EventTypes.WillAppear:
                    case EventTypes.WillDisappear:
                    case EventTypes.TitleParameterDidChange:
                    case EventTypes.DidReceiveSettings:
                    case EventTypes.PropertyInspectorDidAppear:
                    case EventTypes.PropertyInspectorDidDisappear:
                        ActionEventReceived?.Invoke(this, (StreamDeckActionEvent) streamDeckEvent);
                        break;

                    case EventTypes.DeviceDidConnect:
                    case EventTypes.DeviceDidDisconnect:
                    case EventTypes.ApplicationDidLaunch:
                    case EventTypes.ApplicationDidTerminate:
                    case EventTypes.SendToPlugin:
                    case EventTypes.DidReceiveGlobalSettings:
                        PluginEventReceived?.Invoke(this, (StreamDeckPluginEvent) streamDeckEvent);
                        break;
                }
            }
        }

        private async Task SendAsync(IMessage message)
        {
            if (_socket == null)
            {
                return;
            }

            try
            {
                await _semaphore.WaitAsync();
                byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
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
    }
}
