namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class ApplicationsToMonitorData
    {
        public string[]? WindowsApplications { get; }
        public string[]? MacApplications { get; }

        public ApplicationsToMonitorData(
            string[]? windowsApplications, 
            string[]? macApplications)
        {
            WindowsApplications = windowsApplications;
            MacApplications = macApplications;
        }
    }
}
