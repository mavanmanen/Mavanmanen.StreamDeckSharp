using Mavanmanen.StreamDeckSharp.Internal.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal class DidReceiveGlobalSettingsEvent : StreamDeckEvent
    {
        [JsonProperty("payload")]
        public ReceiveGlobalSettingsPayload? Payload { get; private set; }
    }
}