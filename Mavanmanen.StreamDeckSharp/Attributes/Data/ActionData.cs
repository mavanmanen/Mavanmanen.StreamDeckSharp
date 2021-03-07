namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class ActionData
    {
        public string Name { get; }
        public string? Icon { get; }
        public string? Tooltip { get; }
        public string? PropertyInspectorPath { get; }
        public bool SupportedInMultiActions { get; }
        public bool VisibleInActionsList { get; }

        public ActionData(string name, string? icon, string? tooltip, string? propertyInspectorPath, bool supportedInMultiActions, bool visibleInActionsList)
        {
            Name = name;
            Icon = icon;
            Tooltip = tooltip;
            PropertyInspectorPath = propertyInspectorPath;
            SupportedInMultiActions = supportedInMultiActions;
            VisibleInActionsList = visibleInActionsList;
        }
    }
}