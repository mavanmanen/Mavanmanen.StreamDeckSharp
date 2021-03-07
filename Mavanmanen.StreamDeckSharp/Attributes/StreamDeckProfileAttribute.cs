using System;
using Mavanmanen.StreamDeckSharp.Attributes.Data;

namespace Mavanmanen.StreamDeckSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class StreamDeckProfileAttribute : Attribute
    {
        internal ProfileData Data { get; }

        /// <summary>
        /// Specifies an array of profiles.<br/>
        /// A plugin can indeed have one or multiple profiles that are proposed to the user on installation.<br/>
        /// This lets you create fullscreen plugins.
        /// </summary>
        /// <param name="name">The filename of the profile.</param>
        /// <param name="deviceType">Type of device.</param>
        /// <param name="readOnly">	Boolean to mark the profile as read-only.<br/>False by default.</param>
        /// <param name="dontAutoSwitchWhenInstalled">Boolean to prevent Stream Deck from automatically switching to this profile when installed.<br/>False by default.</param>
        public StreamDeckProfileAttribute(
            string name,
            DeviceType deviceType,
            bool readOnly = false,
            bool dontAutoSwitchWhenInstalled = false)
        {
            Data = new ProfileData(name, deviceType, readOnly, dontAutoSwitchWhenInstalled);
        }
    }
}