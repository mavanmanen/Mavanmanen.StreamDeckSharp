using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestOs
    {
        [JsonIgnore]
        public ManifestOsPlatform PlatformEnum { get; }

        [JsonProperty("Platform")]
        public string Platform => PlatformEnum.ToString("G").ToLower();

        [JsonProperty("MinimumVersion")]
        public string MinimumVersion { get; }

        public ManifestOs(ManifestOsPlatform platformEnum, string minimumVersion)
        {
            PlatformEnum = platformEnum;
            MinimumVersion = minimumVersion;
        }
    }
}