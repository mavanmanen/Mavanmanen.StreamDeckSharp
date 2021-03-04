using Mavanmanen.StreamDeckSharp.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events
{
    public class DeviceDidConnectEvent : StreamDeckEvent
    {
        [JsonProperty("device")]
        public string? Device { get; private set; }

        [JsonProperty("deviceInfo")]
        public DeviceInfo? DeviceInfo { get; private set; }
    }
}