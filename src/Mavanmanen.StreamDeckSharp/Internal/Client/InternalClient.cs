using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Client
{
    internal class InternalClient : IDisposable
    {
        private readonly ClientArguments _arguments;
        private readonly IWebSocketClient _socketClient;

        public event EventHandler<StreamDeckActionEvent>? ActionEventReceived;
        public event EventHandler<StreamDeckPluginEvent>? PluginEventReceived;

        public InternalClient(ClientArguments args, IWebSocketClient socketClient)
        {
            _arguments = args;
            _socketClient = socketClient;
            _socketClient.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(object? sender, string json)
        {
            StreamDeckEvent? streamDeckEvent = StreamDeckEvent.FromJson(json);
            if (streamDeckEvent == null)
            {
                return;
            }

            switch (streamDeckEvent.Event)
            {
                case EventType.KeyDown:
                case EventType.KeyUp:
                case EventType.WillAppear:
                case EventType.WillDisappear:
                case EventType.TitleParametersDidChange:
                case EventType.DidReceiveSettings:
                case EventType.PropertyInspectorDidAppear:
                case EventType.PropertyInspectorDidDisappear:
                    ActionEventReceived?.Invoke(this, (StreamDeckActionEvent)streamDeckEvent);
                    break;

                case EventType.DeviceDidConnect:
                case EventType.DeviceDidDisconnect:
                case EventType.ApplicationDidLaunch:
                case EventType.ApplicationDidTerminate:
                case EventType.SendToPlugin:
                case EventType.DidReceiveGlobalSettings:
                case EventType.SystemDidWakeUp:
                    PluginEventReceived?.Invoke(this, (StreamDeckPluginEvent)streamDeckEvent);
                    break;
            }
        }

        public async Task RunAsync()
        {
            try
            {
                if (await _socketClient.ConnectAsync(_arguments.Port))
                {
                    await SendAsync(new RegisterPluginMessage(_arguments.UUID));
                    await _socketClient.ReceiveAsync();
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                await _socketClient.DisconnectAsync();
            }
            
        }

        public async Task SendAsync(Message message)
        {
            await _socketClient.SendAsync(JsonConvert.SerializeObject(message, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
        }

        public void Dispose()
        {
            _socketClient.Dispose();
        }
    }
}
