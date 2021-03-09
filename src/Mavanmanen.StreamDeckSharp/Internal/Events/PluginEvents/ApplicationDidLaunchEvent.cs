using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class ApplicationDidLaunchEvent : ApplicationEvent
    {
        public ApplicationDidLaunchEvent(string device, ApplicationPayload payload) : base(EventType.ApplicationDidLaunch, device, payload)
        {
        }
    }
}