using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads
{
    internal class DeviceInfo
    {

        [JsonProperty("type")]
        public DeviceType Type { get; private set; }

        [JsonProperty("size")]
        public DeviceSize? Size { get; private set; }

        public DeviceInfo()
        {
            
        }

        public DeviceInfo(DeviceType deviceType, DeviceSize? size = null)
        {
            Type = deviceType;
            Size = size;
        }
    }
}