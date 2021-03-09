using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Mavanmanen.StreamDeckSharp.Internal.Messages;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Client
{
    internal class InternalClient
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
                case EventTypes.KeyDown:
                case EventTypes.KeyUp:
                case EventTypes.WillAppear:
                case EventTypes.WillDisappear:
                case EventTypes.TitleParametersDidChange:
                case EventTypes.DidReceiveSettings:
                case EventTypes.PropertyInspectorDidAppear:
                case EventTypes.PropertyInspectorDidDisappear:
                    ActionEventReceived?.Invoke(this, (StreamDeckActionEvent)streamDeckEvent);
                    break;

                case EventTypes.DeviceDidConnect:
                case EventTypes.DeviceDidDisconnect:
                case EventTypes.ApplicationDidLaunch:
                case EventTypes.ApplicationDidTerminate:
                case EventTypes.SendToPlugin:
                case EventTypes.DidReceiveGlobalSettings:
                case EventTypes.SystemDidWakeUp:
                    PluginEventReceived?.Invoke(this, (StreamDeckPluginEvent)streamDeckEvent);
                    break;
            }
        }

        public async Task RunAsync()
        {
            if (await _socketClient.ConnectAsync(_arguments.Port))
            {
                await SendAsync(new RegisterEventMessage(_arguments.RegisterEvent, _arguments.UUID));
                await _socketClient.ReceiveAsync();
            }
        }

        public async Task SendAsync(Message message)
        {
            await _socketClient.SendAsync(JsonConvert.SerializeObject(message, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
        }
    }
}
