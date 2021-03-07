using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestSoftware
    {
        [JsonProperty("MinimumVersion")]
        public string MinimumVersion => "4.1";
    }
}