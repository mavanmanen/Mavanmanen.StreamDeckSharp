using System;
using Mavanmanen.StreamDeckSharp.Attributes.Data;

namespace Mavanmanen.StreamDeckSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class StreamDeckOsAttribute : Attribute
    {
        internal OsData Data { get; }

        /// <summary>
        /// The minimum version of the operating system that the plugin requires.
        /// For Windows 10, you can use 10.<br/>
        /// For macOS 10.11, you can use 10.11.<br/>
        /// </summary>
        /// <param name="windowsMinimumVersion">On Windows, the OS Build information is used for the MinimumVersion.</param>
        /// <param name="macMinimumVersion">On macOS, the version is used for the MinimumVersion.</param>
        public StreamDeckOsAttribute(
            string windowsMinimumVersion,
            string macMinimumVersion)
        {
            Data = new OsData(windowsMinimumVersion, macMinimumVersion);
        }
    }
}