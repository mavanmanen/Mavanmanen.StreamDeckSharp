using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mavanmanen.StreamDeckSharp.Internal.Definitions;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestGenerator
    {
        private readonly PluginDefinition _plugin;
        private readonly List<ActionDefinition> _actions;

        public ManifestGenerator(PluginDefinition plugin, List<ActionDefinition> actions)
        {
            _plugin = plugin;
            _actions = actions;
        }

        public void GenerateManifest()
        {
            string pluginNameSpace = _plugin.Type.Namespace!.ToLower();
            IEnumerable<ManifestAction> actions = _actions.Select(a => new ManifestAction(pluginNameSpace, a.ActionData, a.ActionStateData, a.PropertyInspectorSet));
            var manifest = new Manifest(pluginNameSpace, _plugin.PluginData, _plugin.OsData, _plugin.ProfileData, _plugin.ApplicationsToMonitorData, actions);

            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("manifest.json", json);
        }
    }
}
