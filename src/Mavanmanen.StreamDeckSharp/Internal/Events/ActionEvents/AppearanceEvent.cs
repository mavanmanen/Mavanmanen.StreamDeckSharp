using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal abstract class AppearanceEvent : StreamDeckActionEvent
    {
        [JsonProperty("payload")]
        public AppearancePayload Payload { get; private set; }

        protected AppearanceEvent(EventType eventType, string action, string context, string device, AppearancePayload payload) : base(eventType, action, context, device)
        {
            Payload = payload;
        }
    }
}