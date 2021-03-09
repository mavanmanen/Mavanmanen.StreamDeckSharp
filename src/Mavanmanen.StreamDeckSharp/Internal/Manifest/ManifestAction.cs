using System.Collections.Generic;
using System.Linq;
using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestAction
    {
        [JsonProperty("Icon")]
        public string? Icon { get; }

        [JsonProperty("Name")]
        public string Name { get; }

        [JsonProperty("PropertyInspectorPath")]
        public string? PropertyInspectorPath { get; set; }

        [JsonProperty("States")]
        public ManifestActionState[]? States { get; }

        [JsonProperty("SupportedInMultiActions")]
        public bool? SupportedInMultiActions { get; }

        [JsonProperty("Tooltip")]
        public string? Tooltip { get; }

        [JsonProperty("UUID")]
        public string Uuid { get; }

        [JsonProperty("VisibleInActionsList")]
        public bool? VisibleInActionsList { get; }

        public ManifestAction(string uuidBase, ActionData actionData, IEnumerable<ActionStateData>? actionStateData, bool propertyInspectorSet)
        {
            Icon = actionData.Icon;
            Name = actionData.Name;
            States = actionStateData?.Select(a => new ManifestActionState(a)).ToArray();
            SupportedInMultiActions = actionData.SupportedInMultiActions;
            Tooltip = actionData.Tooltip;
            Uuid = $"{uuidBase}.{Name.ToLower()}";
            VisibleInActionsList = actionData.VisibleInActionsList;

            if (propertyInspectorSet)
            {
                PropertyInspectorPath = $"propertyInspector/{Name}.html";
            }
        }
    }
}