using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal
{
    internal class InternalClient
    {
        private const int BUFFER_SIZE = 1048576;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private readonly StreamDeckClientArguments _arguments;
        private ClientWebSocket? _socket;

        public event EventHandler<EventArgs>? Connected;
        public event EventHandler<EventArgs>? Disconnected;

        public event EventHandler<KeyDownEvent>? KeyDown;
        public event EventHandler<KeyUpEvent>? KeyUp;
        public event EventHandler<WillAppearEvent>? WillAppear;
        public event EventHandler<WillDisappearEvent>? WillDisappear;
        public event EventHandler<TitleParameterDidChangeEvent>? TitleParametersDidChange;
        public event EventHandler<DeviceDidConnectEvent>? DeviceDidConnect;
        public event EventHandler<DeviceDidDisconnectEvent>? DeviceDidDisconnect;
        public event EventHandler<ApplicationDidLaunchEvent>? ApplicationDidLaunch;
        public event EventHandler<ApplicationDidTerminateEvent>? ApplicationDidTerminate;
        public event EventHandler<SendToPluginEvent>? SendToPlugin;
        public event EventHandler<DidReceiveSettingsEvent>? DidReceiveSettings;
        public event EventHandler<DidReceiveGlobalSettingsEvent>? DidReceiveGlobalSettings;
        public event EventHandler<PropertyInspectorDidAppearEvent>? PropertyInspectorDidAppear;
        public event EventHandler<PropertyInspectorDidDisappearEvent>? PropertyInspectorDidDisappear;

        public InternalClient(string[] args) : this(StreamDeckClientArguments.ParseFromArgs(args)) { }

        public InternalClient(StreamDeckClientArguments args)
        {
            _arguments = args;
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

                Connected?.Invoke(this, new EventArgs());
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
            Disconnected?.Invoke(this, new EventArgs());
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

                if (result == null)
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
                
                switch (streamDeckEvent)
                {
                    case KeyDownEvent keyDownEvent:
                        KeyDown?.Invoke(this, keyDownEvent);
                        break;

                    case KeyUpEvent keyUpEvent:
                        KeyUp?.Invoke(this, keyUpEvent);
                        break;

                    case WillAppearEvent willAppearEvent:
                        WillAppear?.Invoke(this, willAppearEvent);
                        break;

                    case WillDisappearEvent willDisappearEvent:
                        WillDisappear?.Invoke(this, willDisappearEvent);
                        break;

                    case TitleParameterDidChangeEvent titleParameterDidChangeEvent:
                        TitleParametersDidChange?.Invoke(this, titleParameterDidChangeEvent);
                        break;

                    case DeviceDidConnectEvent deviceDidConnectEvent:
                        DeviceDidConnect?.Invoke(this, deviceDidConnectEvent);
                        break;

                    case DeviceDidDisconnectEvent deviceDidDisconnectEvent:
                        DeviceDidDisconnect?.Invoke(this, deviceDidDisconnectEvent);
                        break;

                    case ApplicationDidLaunchEvent applicationDidLaunchEvent:
                        ApplicationDidLaunch?.Invoke(this, applicationDidLaunchEvent);
                        break;

                    case ApplicationDidTerminateEvent applicationDidTerminateEvent:
                        ApplicationDidTerminate?.Invoke(this, applicationDidTerminateEvent);
                        break;

                    case SendToPluginEvent sendToPluginEvent:
                        SendToPlugin?.Invoke(this, sendToPluginEvent);
                        break;

                    case DidReceiveSettingsEvent didReceiveSettingsEvent:
                        DidReceiveSettings?.Invoke(this, didReceiveSettingsEvent);
                        break;

                    case DidReceiveGlobalSettingsEvent didReceiveGlobalSettingsEvent:
                        DidReceiveGlobalSettings?.Invoke(this, didReceiveGlobalSettingsEvent);
                        break;

                    case PropertyInspectorDidAppearEvent propertyInspectorDidAppearEvent:
                        PropertyInspectorDidAppear?.Invoke(this, propertyInspectorDidAppearEvent);
                        break;

                    case PropertyInspectorDidDisappearEvent propertyInspectorDidDisappearEvent:
                        PropertyInspectorDidDisappear?.Invoke(this, propertyInspectorDidDisappearEvent);
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
