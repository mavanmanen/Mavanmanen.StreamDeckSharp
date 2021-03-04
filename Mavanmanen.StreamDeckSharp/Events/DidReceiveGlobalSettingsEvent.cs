using Mavanmanen.StreamDeckSharp.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events
{
    public class DidReceiveGlobalSettingsEvent : StreamDeckEvent
    {
        [JsonProperty("payload")]
        public ReceiveGlobalSettingsPayload? Payload { get; private set; }
    }
}