using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Manifest
{
    internal class ManifestApplicationsToMonitor
    {
        [JsonProperty("mac")]
        public string[]? Mac { get; }

        [JsonProperty("windows")]
        public string[]? Windows { get; }

        public ManifestApplicationsToMonitor(ApplicationsToMonitorData applicationsToMonitorData)
        {
            Mac = applicationsToMonitorData.MacApplications;
            Windows = applicationsToMonitorData.WindowsApplications;
        }
    }
}