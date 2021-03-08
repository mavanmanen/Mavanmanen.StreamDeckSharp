using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Mavanmanen.StreamDeckSharp.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestActionState
    {
        [JsonProperty("Image")]
        public string Image { get; }

        [JsonProperty("MultiActionImage")]
        public string? MultiActionImage { get; }

        [JsonProperty("Name")]
        public string? Name { get; }

        [JsonProperty("Title")]
        public string? Title { get; }

        [JsonProperty("ShowTitle")]
        public bool? ShowTitle { get; }

        [JsonProperty("TitleColor")]
        public string? TitleColor { get; }

        [JsonProperty("TitleAlignment"), JsonConverter(typeof(StringEnumConverter))]
        public TitleAlignment? TitleAlignmentEnum { get; }

        [JsonProperty("FontFamily"), JsonConverter(typeof(StringEnumConverter))]
        public FontFamily? FontFamilyEnum { get; }

        [JsonProperty("FontStyle"), JsonConverter(typeof(StringEnumConverter))]
        public FontStyle? FontStyleEnum { get; }

        [JsonProperty("FontSize")]
        public int? FontSize { get; }

        [JsonProperty("FontUnderline")]
        public bool? FontUnderline { get; }

        public ManifestActionState(ActionStateData actionStateData)
        {
            Image = actionStateData.Image;
            MultiActionImage = actionStateData.MultiActionImage;
            Name = actionStateData.Name;
            Title = actionStateData.Title;
            ShowTitle = actionStateData.ShowTitle;
            TitleColor = actionStateData.TitleColor;
            TitleAlignmentEnum = actionStateData.TitleAlignment;
            FontFamilyEnum = actionStateData.FontFamily;
            FontStyleEnum = actionStateData.FontStyle;
            FontSize = actionStateData.FontSize;
            FontUnderline = actionStateData.FontUnderline;
        }
    }
}