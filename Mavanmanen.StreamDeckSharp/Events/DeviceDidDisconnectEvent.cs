using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events
{
    public class DeviceDidDisconnectEvent : StreamDeckEvent
    {
        [JsonProperty("device")]
        public string? Device { get; private set; }
    }
}