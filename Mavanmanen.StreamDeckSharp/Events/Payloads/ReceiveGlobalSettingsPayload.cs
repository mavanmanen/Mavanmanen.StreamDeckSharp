using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Events.Payloads
{
    public class ReceiveGlobalSettingsPayload
    {
        [JsonProperty("settings")]
        public JObject? Settings { get; private set; }
    }
}