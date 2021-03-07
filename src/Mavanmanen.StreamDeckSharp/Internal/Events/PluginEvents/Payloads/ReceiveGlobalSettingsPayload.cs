using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads
{
    internal class ReceiveGlobalSettingsPayload
    {
        [JsonProperty("settings")]
        public JObject? Settings { get; private set; }
    }
}