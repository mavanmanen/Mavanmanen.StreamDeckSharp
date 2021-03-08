using Mavanmanen.StreamDeckSharp.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mavanmanen.StreamDeckSharp.Payloads
{
    /// <summary>
    /// Parameters for a title change.
    /// </summary>
    public class TitleParameters
    {
        /// <summary>
        /// The font family that was changed to.
        /// </summary>
        [JsonProperty("fontFamily"), JsonConverter(typeof(StringEnumConverter))]
        public FontFamily? FontFamily { get; private set; }

        /// <summary>
        /// The font size that was changed to.
        /// </summary>
        [JsonProperty("fontSize")]
        public uint? FontSize { get; private set; }

        /// <summary>
        /// The font style that was changed to.
        /// </summary>
        [JsonProperty("fontStyle"), JsonConverter(typeof(StringEnumConverter))]
        public FontStyle? FontStyle { get; private set; }

        /// <summary>
        /// If font underline was turned on or off.
        /// </summary>
        [JsonProperty("fontUnderline")]
        public bool? FontUnderline { get; private set; }

        /// <summary>
        /// If showing the title was turned on or off.
        /// </summary>
        [JsonProperty("showTitle")]
        public bool? ShowTitle { get; private set; }

        /// <summary>
        /// The title alignment that was changed to.
        /// </summary>
        [JsonProperty("titleAlignment"), JsonConverter(typeof(StringEnumConverter))]
        public TitleAlignment? TitleAlignment { get; private set; }

        /// <summary>
        /// The title color that was changed to.
        /// </summary>
        [JsonProperty("titleColor")]
        public string? TitleColor { get; private set; }
    }
}