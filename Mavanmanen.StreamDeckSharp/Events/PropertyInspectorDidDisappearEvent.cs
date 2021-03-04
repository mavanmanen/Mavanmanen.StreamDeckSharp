using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events
{
    public class PropertyInspectorDidDisappearEvent : StreamDeckEvent
    {
        [JsonProperty("action")]
        public string? Action { get; private set; }

        [JsonProperty("context")]
        public string? Context { get; private set; }

        [JsonProperty("device")]
        public string? Device { get; private set; }
    }
}