using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public TitleAlignment? TitleAlignmentEnum { get; }

        [JsonProperty("TitleAlignment")]
        public string? TitleAlignment => TitleAlignmentEnum?.ToString("G").ToLower();

        [JsonIgnore]
        public FontFamily? FontFamilyEnum { get; }

        [JsonProperty("FontFamily")]
        public string? FontFamily => FontFamilyEnum?.ToString("G").Replace('_', ' ');

        [JsonIgnore]
        public FontStyle? FontStyleEnum { get; }

        [JsonProperty("FontStyle")]
        public string? FontStyle => FontFamilyEnum?.ToString("G").Replace('_', ' ');

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