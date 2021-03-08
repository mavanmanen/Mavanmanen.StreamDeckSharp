using Mavanmanen.StreamDeckSharp.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mavanmanen.StreamDeckSharp.Payloads
{
    public class TitleParameters
    {
        [JsonProperty("fontFamily"), JsonConverter(typeof(StringEnumConverter))]
        public FontFamily? FontFamily { get; private set; }

        [JsonProperty("fontSize")]
        public uint? FontSize { get; private set; }

        [JsonProperty("fontStyle"), JsonConverter(typeof(StringEnumConverter))]
        public FontStyle? FontStyle { get; private set; }

        [JsonProperty("fontUnderline")]
        public bool? FontUnderline { get; private set; }

        [JsonProperty("showTitle")]
        public bool? ShowTitle { get; private set; }

        [JsonProperty("titleAlignment"), JsonConverter(typeof(StringEnumConverter))]
        public TitleAlignment? TitleAlignment { get; private set; }

        [JsonProperty("titleColor")]
        public string? TitleColor { get; private set; }
    }
}