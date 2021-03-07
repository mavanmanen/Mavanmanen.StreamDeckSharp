namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class PluginData
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
        }
    }
}