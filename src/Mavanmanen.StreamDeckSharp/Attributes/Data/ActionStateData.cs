using Mavanmanen.StreamDeckSharp.Enum;

namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class ActionStateData
    {
        public string Image { get; }
        public string? Name { get; }
        public string? MultiActionImage { get; }
        public string? Title { get; }
        public bool ShowTitle { get; }
        public string? TitleColor { get; }
        public TitleAlignment TitleAlignment { get; }
        public FontFamily FontFamily { get; }
        public FontStyle FontStyle { get; }
        public int? FontSize { get; }
        public bool FontUnderline { get; }

        public ActionStateData(string image,
            string? name,
            string? multiActionImage,
            string? title,
            bool showTitle,
            string? titleColor,
            TitleAlignment titleAlignment,
            FontFamily fontFamily,
            FontStyle fontStyle,
            int? fontSize,
            bool fontUnderline)
        {
            Image = image;
            Name = name;
            MultiActionImage = multiActionImage;
            Title = title;
            ShowTitle = showTitle;
            TitleColor = titleColor;
            TitleAlignment = titleAlignment;
            FontFamily = fontFamily;
            FontStyle = fontStyle;
            FontSize = fontSize;
            FontUnderline = fontUnderline;
        }
    }
}
