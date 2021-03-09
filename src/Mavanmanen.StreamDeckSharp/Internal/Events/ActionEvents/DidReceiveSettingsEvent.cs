using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class DidReceiveSettingsEvent : StreamDeckActionEvent
    {
        [JsonProperty("payload")]
        public ReceiveSettingsPayload Payload { get; private set; }

        public DidReceiveSettingsEvent(string action, string context, string device, ReceiveSettingsPayload payload) : base(EventType.DidReceiveSettings, action, context, device)
        {
            Payload = payload;
        }
    }
}