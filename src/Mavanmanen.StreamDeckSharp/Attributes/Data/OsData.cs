using Mavanmanen.StreamDeckSharp.Internal.Verification;

namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class OsData : Verifiable<OsData>
    {
        public string WindowsMinimumVersion { get; }
        public string MacMinimumVersion { get; }

        public OsData(
            string windowsMinimumVersion, 
            string macMinimumVersion)
        {
            WindowsMinimumVersion = windowsMinimumVersion;
            MacMinimumVersion = macMinimumVersion;

            Verify(this, x => x.WindowsMinimumVersion).NotNull().NotEmpty();
            Verify(this, x => x.MacMinimumVersion).NotNull().NotEmpty();
        }
    }
}
