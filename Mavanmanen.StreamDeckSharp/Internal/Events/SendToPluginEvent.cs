using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal class SendToPluginEvent : StreamDeckEvent
    {
        [JsonProperty("action")]
        public string? Action { get; private set; }

        [JsonProperty("context")]
        public string? Context { get; private set; }

        [JsonProperty("payload")]
        public JObject? Payload { get; private set; }
    }
}