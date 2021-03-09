using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal abstract class KeyEvent : StreamDeckActionEvent
    {
        [JsonProperty("payload")]
        public KeyPayload Payload { get; private set; }

        protected KeyEvent(EventType eventType, string action, string context, string device, KeyPayload payload) : base(eventType, action, context, device)
        {
            Payload = payload;
        }
    }
}