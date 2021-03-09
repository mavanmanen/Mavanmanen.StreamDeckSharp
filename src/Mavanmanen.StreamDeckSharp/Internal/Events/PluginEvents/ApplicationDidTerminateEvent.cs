using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class ApplicationDidTerminateEvent : ApplicationEvent
    {
        public ApplicationDidTerminateEvent(string device, ApplicationPayload payload) : base(EventType.ApplicationDidTerminate, device, payload)
        {
        }
    }
}