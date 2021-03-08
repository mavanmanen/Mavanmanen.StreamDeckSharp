using System;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used to define the type for the property inspector class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class StreamDeckPropertyInspectorAttribute : Attribute
    {
        internal Type SettingsType { get; }

        /// <param name="settingsType">The type of the property inspector class.</param>
        public StreamDeckPropertyInspectorAttribute(Type settingsType)
        {
            SettingsType = settingsType;
        }
    }
}
