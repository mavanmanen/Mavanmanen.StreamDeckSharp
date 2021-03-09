using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class KeyDownEvent : KeyEvent
    {
        public KeyDownEvent(string action, string context, string device, KeyPayload payload) : base(EventType.KeyDown, action, context, device, payload)
        {
        }
    }
}