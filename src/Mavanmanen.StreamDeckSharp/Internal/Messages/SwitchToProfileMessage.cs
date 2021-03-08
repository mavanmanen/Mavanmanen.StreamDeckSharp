using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SwitchToProfileMessage : Message
    {
        [JsonProperty("device")]
        public string Device { get; }

        public SwitchToProfileMessage(string context, string device, string? profileName = null) : base("switchToProfile", context, new { profile = profileName })
        {
            Device = device;
        }
    }
}
