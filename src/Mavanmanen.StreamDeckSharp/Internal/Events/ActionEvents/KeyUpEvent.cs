using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class KeyUpEvent : KeyEvent
    {
        public KeyUpEvent(string action, string context, string device, KeyPayload payload) : base(EventType.KeyUp, action, context, device, payload)
        {
        }
    }
}