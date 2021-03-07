using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Events;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;

namespace Mavanmanen.StreamDeckSharp.Internal
{
    internal class PluginEventHandler
    {
        private readonly StreamDeckPlugin _plugin;

        public PluginEventHandler(StreamDeckPlugin plugin)
        {
            _plugin = plugin;
        }

        public async Task HandleEventAsync(StreamDeckPluginEvent pluginEvent)
        {
            switch (pluginEvent.Event)
            {
                case EventTypes.DeviceDidConnect:
                    await _plugin.DeviceDidConnectAsync();
                    break;

                case EventTypes.DeviceDidDisconnect:
                    break;

                case EventTypes.ApplicationDidLaunch:
                    break;

                case EventTypes.ApplicationDidTerminate:
                    break;

                case EventTypes.SendToPlugin:
                    break;

                case EventTypes.DidReceiveGlobalSettings:
                    break;
            }
        }
    }
}