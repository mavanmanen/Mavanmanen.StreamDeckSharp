using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestProfile
    {
        [JsonProperty("Name")]
        public string Name { get; }

        [JsonIgnore]
        public DeviceType? DeviceTypeEnum { get; }

        [JsonProperty("DeviceType")]
        public string? DeviceType =>
            DeviceTypeEnum switch
            {
                Attributes.DeviceType.StreamDeck => "kESDSDKDeviceType_StreamDeck",
                Attributes.DeviceType.StreamDeckMini => "kESDSDKDeviceType_StreamDeckMini",
                Attributes.DeviceType.StreamDeckXL => "kESDSDKDeviceType_StreamDeckXL",
                Attributes.DeviceType.StreamDeckMobile => "kESDSDKDeviceType_StreamDeckMobile",
                Attributes.DeviceType.CorsairGKeys => "kESDSDKDeviceType_CorsairGKeys",
                var _ => null
            };

        [JsonProperty("ReadOnly")]
        public bool? ReadOnly { get; }

        [JsonProperty("DontAutoSwitchWhenInstalled")]
        public bool? DontAutoSwitchWhenInstalled { get; }

        public ManifestProfile(ProfileData profileData)
        {
            Name = profileData.Name;
            DeviceTypeEnum = profileData.DeviceType;
            ReadOnly = profileData.ReadOnly;
            DontAutoSwitchWhenInstalled = profileData.DontAutoSwitchWhenInstalled;
        }
    }
}