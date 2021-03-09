using Mavanmanen.StreamDeckSharp.Internal.Verification;

namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class PluginData : Verifiable<PluginData>
    {
        public string Name { get; }
        public string Icon { get; }
        public string Author { get; }
        public string Description { get; }
        public string Version { get; }
        public string? Url { get; }
        public string? Category { get; }
        public string? CategoryIcon { get; }
        public string? PropertyInspectorPath { get; }
        public (int width, int height)? DefaultWindowSize { get; }

        public PluginData(string name,
            string icon,
            string author,
            string description,
            string version,
            string? url,
            string? category,
            string? categoryIcon,
            string? propertyInspectorPath,
            (int width, int height)? defaultWindowSize)
        {
            Name = name;
            Icon = icon;
            Author = author;
            Description = description;
            Version = version;
            Url = url;
            Category = category;
            CategoryIcon = categoryIcon;
            PropertyInspectorPath = propertyInspectorPath;
            DefaultWindowSize = defaultWindowSize;

            Verify(this, x => x.Name).NotNull().NotEmpty();
            Verify(this, x => x.Icon).NotNull().NotEmpty();
            Verify(this, x => x.Author).NotNull().NotEmpty();
            Verify(this, x => x.Description).NotNull().NotEmpty();
            Verify(this, x => x.Version).NotNull().NotEmpty().Regex(@"^(\d\.?)+$");
            Verify(this, x => x.Url).NotEmpty();

            if (Category != null)
            {
                Verify(this, x => x.Category).NotEmpty();
                Verify(this, x => x.CategoryIcon).NotNull().NotEmpty();
            }

            Verify(this, x => x.PropertyInspectorPath).NotEmpty();

            if (DefaultWindowSize != null)
            {
                Verify(this, x => x.DefaultWindowSize!.Value.height).Min(1);
                Verify(this, x => x.DefaultWindowSize!.Value.width).Min(1);
            }
        }
    }
}