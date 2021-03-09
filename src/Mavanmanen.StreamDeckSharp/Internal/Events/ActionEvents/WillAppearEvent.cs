using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class WillAppearEvent : AppearanceEvent
    {
        public WillAppearEvent(string action, string context, string device, AppearancePayload payload) : base(EventType.WillAppear, action, context, device, payload)
        {
        }
    }
}