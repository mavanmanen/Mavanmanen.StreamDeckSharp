using System;
using Mavanmanen.StreamDeckSharp.Attributes.Data;

namespace Mavanmanen.StreamDeckSharp.Attributes
{
    /// <summary>
    /// A plugin can request to be notified when some applications are launched or terminated.<br/>
    /// In order to do so, the ApplicationsToMonitor object should contain for each platform an array specifying the list of application identifiers to monitor.<br/>
    /// On macOS the application bundle identifier is used while the exe filename is used on Windows.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class StreamDeckApplicationsToMonitorAttribute : Attribute
    {
        internal ApplicationsToMonitorData Data { get; }
        
        /// <param name="windowsApplications">Windows application identifiers.</param>
        /// <param name="macApplications">Mac application identifiers.</param>
        public StreamDeckApplicationsToMonitorAttribute(
            string[]? windowsApplications = null,
            string[]? macApplications = null)
        {
            Data = new ApplicationsToMonitorData(windowsApplications, macApplications);
        }
    }
}