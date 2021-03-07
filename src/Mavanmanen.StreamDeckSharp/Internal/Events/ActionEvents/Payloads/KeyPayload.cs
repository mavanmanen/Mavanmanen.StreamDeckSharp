using Mavanmanen.StreamDeckSharp.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads
{
    internal class KeyPayload
    {
        [JsonProperty("settings")]
        public JObject? Settings { get; private set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; private set; } = null!;

        [JsonProperty("state")]
        public uint State { get; private set; }

        [JsonProperty("userDesiredState")]
        public uint UserDesiredState { get; private set; }

        [JsonProperty("isInMultiAction")]
        public bool IsInMultiAction { get; private set; }
    }
}