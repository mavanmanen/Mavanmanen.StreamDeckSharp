using System;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class StreamDeckPropertyInspectorAttribute : Attribute
    {
        internal Type SettingsType { get; }

        public StreamDeckPropertyInspectorAttribute(Type settingsType)
        {
            SettingsType = settingsType;
        }
    }
}
