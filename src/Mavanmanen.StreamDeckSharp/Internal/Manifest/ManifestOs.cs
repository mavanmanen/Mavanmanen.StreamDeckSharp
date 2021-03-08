using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestOs
    {
        [JsonProperty("Platform"), JsonConverter(typeof(StringEnumConverter))]
        public ManifestOsPlatform PlatformEnum { get; }

        [JsonProperty("MinimumVersion")]
        public string MinimumVersion { get; }

        public ManifestOs(ManifestOsPlatform platformEnum, string minimumVersion)
        {
            PlatformEnum = platformEnum;
            MinimumVersion = minimumVersion;
        }
    }
}