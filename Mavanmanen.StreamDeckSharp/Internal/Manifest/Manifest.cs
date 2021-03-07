using System.Collections.Generic;
using System.Linq;
using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class Manifest
    {
        [JsonProperty("Actions")]
        public ManifestAction[] Actions { get; }

        [JsonProperty("Author")]
        public string Author { get; }

        [JsonProperty("Category")]
        public string? Category { get; }

        [JsonProperty("CategoryIcon")]
        public string? CategoryIcon { get; }

        [JsonProperty("CodePath")]
        public string? CodePath { get; }

        [JsonProperty("CodePathMac")]
        public string? CodePathMac { get; }

        [JsonProperty("CodePathWin")]
        public string? CodePathWin { get; }

        [JsonProperty("Description")]
        public string Description { get; }

        [JsonProperty("Icon")]
        public string Icon { get; }

        [JsonProperty("Name")]
        public string Name { get; }

        [JsonProperty("Profiles")]
        public ManifestProfile[]? Profiles { get; }

        [JsonProperty("PropertyInspectorPath")]
        public string? PropertyInspectorPath { get; }

        [JsonProperty("DefaultWindowSize")]
        public int[]? DefaultWindowSize { get; }

        [JsonProperty("URL")]
        public string? Url { get; }

        [JsonProperty("Version")]
        public string Version { get; }

        [JsonProperty("SDKVersion")]
        public int SdkVersion => 2;

        [JsonProperty("OS")]
        public ManifestOs[] Os { get; }

        [JsonProperty("Software")]
        public ManifestSoftware Software => new ManifestSoftware();

        [JsonProperty("ApplicationsToMonitor")]
        public ManifestApplicationsToMonitor? ApplicationsToMonitor { get; }

        public Manifest(string pluginNamespace, PluginData pluginData, OsData osData, IEnumerable<ProfileData>? profileData, ApplicationsToMonitorData? applicationsToMonitorData, IEnumerable<ManifestAction> actions)
        {
            Actions = actions.ToArray();
            Author = pluginData.Author;
            Category = pluginData.Category;
            CategoryIcon = pluginData.CategoryIcon;
            CodePathWin = $"{pluginNamespace}.exe";
            CodePathMac = pluginNamespace;
            Description = pluginData.Description;
            Icon = pluginData.Icon;
            Name = pluginData.Name;
            Profiles = profileData?.Select(p => new ManifestProfile(p)).ToArray();
            PropertyInspectorPath = pluginData.PropertyInspectorPath;
            DefaultWindowSize = pluginData.DefaultWindowSize != null ? new[] { (int)pluginData.DefaultWindowSize?.width!, (int)pluginData.DefaultWindowSize?.height! } : null;
            Url = pluginData.Url;
            Version = pluginData.Version;
            Os = new[]
            {
                new ManifestOs(ManifestOsPlatform.Windows, osData.WindowsMinimumVersion),
                new ManifestOs(ManifestOsPlatform.Mac, osData.MacMinimumVersion)
            };
            ApplicationsToMonitor = applicationsToMonitorData != null ? new ManifestApplicationsToMonitor(applicationsToMonitorData) : null;
        }
    }
}