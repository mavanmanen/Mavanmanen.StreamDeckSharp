using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class DidReceiveSettingsEvent : StreamDeckEvent
    {
        [JsonProperty("payload")]
        public ReceiveSettingsPayload? Payload { get; private set; }
    }
}