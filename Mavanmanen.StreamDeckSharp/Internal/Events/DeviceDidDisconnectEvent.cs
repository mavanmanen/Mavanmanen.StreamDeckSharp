using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal class DeviceDidDisconnectEvent : StreamDeckEvent
    {
        [JsonProperty("device")]
        public string? Device { get; private set; }
    }
}