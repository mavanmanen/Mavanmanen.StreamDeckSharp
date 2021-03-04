using Mavanmanen.StreamDeckSharp.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events
{
    public class TitleParameterDidChangeEvent : StreamDeckEvent
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