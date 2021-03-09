using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class WillDisappearEvent : AppearanceEvent
    {
        public WillDisappearEvent(string action, string context, string device, AppearancePayload payload) : base(EventType.WillDisappear, action, context, device, payload)
        {
        }
    }
}