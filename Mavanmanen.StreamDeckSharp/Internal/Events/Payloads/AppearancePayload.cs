using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.Payloads
{
    internal class AppearancePayload
    {
        [JsonProperty("settings")]
        public JObject? Settings { get; private set; }

        [JsonProperty("coordinates")]
        public Coordinates? Coordinates { get; private set; }

        [JsonProperty("state")]
        public uint? State { get; private set; }

        [JsonProperty("isInMultiAction")]
        public bool? IsInMultiAction { get; private set; }
    }
}