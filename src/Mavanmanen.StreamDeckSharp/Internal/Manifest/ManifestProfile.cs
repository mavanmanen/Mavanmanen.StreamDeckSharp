using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Mavanmanen.StreamDeckSharp.Enum;
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
                Enum.DeviceType.StreamDeck => "kESDSDKDeviceType_StreamDeck",
                Enum.DeviceType.StreamDeckMini => "kESDSDKDeviceType_StreamDeckMini",
                Enum.DeviceType.StreamDeckXL => "kESDSDKDeviceType_StreamDeckXL",
                Enum.DeviceType.StreamDeckMobile => "kESDSDKDeviceType_StreamDeckMobile",
                Enum.DeviceType.CorsairGKeys => "kESDSDKDeviceType_CorsairGKeys",
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