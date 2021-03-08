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
                case EventTypes.DeviceDidConnect:
                    await _plugin.DeviceDidConnectAsync();
                    break;

                case EventTypes.DeviceDidDisconnect:
                    await _plugin.DeviceDidDisconnectAsync();
                    break;

                case EventTypes.ApplicationDidLaunch:
                case EventTypes.ApplicationDidTerminate:
                    await HandleApplicationEvent((ApplicationEvent)pluginEvent);
                    break;

                case EventTypes.DidReceiveGlobalSettings:
                    await _plugin.DidReceiveGlobalSettingsAsync(((DidReceiveGlobalSettingsEvent) pluginEvent).Payload.Settings)
                    break;

                case EventTypes.SystemDidWakeUp:
                    await _plugin.SystemDidWakeUpAsync();
                    break;
            }
        }

        private async Task HandleApplicationEvent(ApplicationEvent applicationEvent)
        {
            switch (applicationEvent.Event)
            {
                case EventTypes.ApplicationDidLaunch:
                    await _plugin.ApplicationDidLaunchAsync(applicationEvent.Payload.Application);
                    break;

                case EventTypes.ApplicationDidTerminate:
                    await _plugin.ApplicationDidTerminateAsync(applicationEvent.Payload.Application);
                    break;
            }
        }

        public void Dispose()
        {
        }
    }
}