namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class OsData
    {
        public string WindowsMinimumVersion { get; }
        public string MacMinimumVersion { get; }

        public OsData(
            string windowsMinimumVersion, 
            string macMinimumVersion)
        {
            WindowsMinimumVersion = windowsMinimumVersion;
            MacMinimumVersion = macMinimumVersion;
        }
    }
}
