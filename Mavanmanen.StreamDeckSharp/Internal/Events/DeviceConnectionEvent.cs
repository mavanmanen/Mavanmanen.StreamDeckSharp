using Mavanmanen.StreamDeckSharp.Internal.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal class DeviceDidConnectEvent : StreamDeckEvent
    {
        [JsonProperty("device")]
        public string? Device { get; private set; }

        [JsonProperty("deviceInfo")]
        public DeviceInfo? DeviceInfo { get; private set; }
    }
}