using System.Linq;
using Mavanmanen.StreamDeckSharp.Internal.Verification;

namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class ApplicationsToMonitorData : Verifiable<ApplicationsToMonitorData>
    {
        public string[]? WindowsApplications { get; }
        public string[]? MacApplications { get; }

        public ApplicationsToMonitorData(
            string[]? windowsApplications, 
            string[]? macApplications)
        {
            WindowsApplications = windowsApplications;
            MacApplications = macApplications;

            if (MacApplications?.Any() == true)
            {
                for (var i = 0; i < MacApplications.Length; i++)
                {
                    Verify(this, x => x.WindowsApplications![i]).NotEmpty();
                }
            }

            if (MacApplications?.Any() == true)
            {
                for (var i = 0; i < MacApplications.Length; i++)
                {
                    Verify(this, x => x.WindowsApplications![i]).NotEmpty();
                }
            }
        }
    }
}
