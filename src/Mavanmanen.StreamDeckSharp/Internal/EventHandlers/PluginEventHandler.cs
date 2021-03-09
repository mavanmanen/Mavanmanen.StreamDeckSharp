using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;

namespace Mavanmanen.StreamDeckSharp.Internal.EventHandlers
{
    internal class PluginEventHandler : IDisposable
    {
        private readonly StreamDeckPlugin _plugin;

        public PluginEventHandler(StreamDeckPlugin plugin, ClientArguments clientArguments)
        {
            _plugin = plugin;
            _plugin.Context = clientArguments.UUID;
        }

        public async Task HandleEventAsync(StreamDeckPluginEvent pluginEvent)
        {
            _plugin.Device = pluginEvent.Device;

            switch (pluginEvent.Event)
            {
                case EventType.DeviceDidConnect:
                    await _plugin.DeviceDidConnectAsync();
                    break;

                case EventType.DeviceDidDisconnect:
                    await _plugin.DeviceDidDisconnectAsync();
                    break;

                case EventType.ApplicationDidLaunch:
                case EventType.ApplicationDidTerminate:
                    await HandleApplicationEvent((ApplicationEvent)pluginEvent);
                    break;

                case EventType.DidReceiveGlobalSettings:
                    await _plugin.DidReceiveGlobalSettingsAsync(((DidReceiveGlobalSettingsEvent) pluginEvent).Payload.Settings);
                    break;

                case EventType.SystemDidWakeUp:
                    await _plugin.SystemDidWakeUpAsync();
                    break;
            }
        }

        private async Task HandleApplicationEvent(ApplicationEvent applicationEvent)
        {
            switch (applicationEvent.Event)
            {
                case EventType.ApplicationDidLaunch:
                    await _plugin.ApplicationDidLaunchAsync(applicationEvent.Payload.Application);
                    break;

                case EventType.ApplicationDidTerminate:
                    await _plugin.ApplicationDidTerminateAsync(applicationEvent.Payload.Application);
                    break;
            }
        }

        public void Dispose()
        {
        }
    }
}