using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events.Payloads
{
    public class DeviceInfo
    {
        [JsonProperty("type")]
        public DeviceType Type { get; private set; }

        [JsonProperty("size")]
        public DeviceSize? Size { get; private set; }
    }
}