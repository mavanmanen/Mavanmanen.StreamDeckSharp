using Mavanmanen.StreamDeckSharp.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads
{
    internal class ReceiveSettingsPayload
    {
        [JsonProperty("settings")]
        public JObject Settings { get; private set; } = null!;

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; private set; } = null!;

        [JsonProperty("isInMultiAction")]
        public bool IsInMultiAction { get; private set; }
    }
}