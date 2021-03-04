using Mavanmanen.StreamDeckSharp.Internal.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal class TitleParameterDidChangeEvent : StreamDeckEvent
    {
        [JsonProperty("action")]
        public string? Action { get; private set; }

        [JsonProperty("context")]
        public string? Context { get; private set; }

        [JsonProperty("device")]
        public string? Device { get; private set; }

        [JsonProperty("payload")]
        public TitleParametersPayload? Payload { get; private set; }
    }
}