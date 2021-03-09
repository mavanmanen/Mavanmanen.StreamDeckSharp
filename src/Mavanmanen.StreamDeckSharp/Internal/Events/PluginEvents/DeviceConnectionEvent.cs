using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class DeviceDidConnectEvent : StreamDeckPluginEvent
    {
        [JsonProperty("deviceInfo")]
        public DeviceInfo DeviceInfo { get; private set; }

        public DeviceDidConnectEvent(string device, DeviceInfo deviceInfo) : base(EventType.DeviceDidConnect, device)
        {
            DeviceInfo = deviceInfo;
        }
    }
}