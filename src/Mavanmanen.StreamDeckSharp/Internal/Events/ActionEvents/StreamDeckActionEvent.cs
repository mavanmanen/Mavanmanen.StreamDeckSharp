using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal abstract class StreamDeckActionEvent : StreamDeckEvent
    {
        [JsonProperty("action")]
        public string Action { get; private set; } = null!;

        [JsonProperty("context")]
        public string Context { get; private set; } = null!;

        [JsonProperty("device")]
        public string Device { get; private set; } = null!;
    }
}