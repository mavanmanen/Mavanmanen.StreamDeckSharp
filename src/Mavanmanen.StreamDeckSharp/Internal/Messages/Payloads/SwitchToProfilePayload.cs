using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads
{
    internal class SwitchToProfilePayload
    {
        [JsonProperty("profile")]
        public string? Profile { get; private set; }

        public SwitchToProfilePayload(string? profile)
        {
            Profile = profile;
        }
    }
}
