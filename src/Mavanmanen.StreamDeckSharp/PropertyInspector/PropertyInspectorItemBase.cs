using System;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    public abstract class PropertyInspectorItemBase : Attribute
    {
        internal string Label { get; }
        internal string Type { get; }
        internal bool Required { get; }

        protected PropertyInspectorItemBase(string label, string type, bool required)
        {
            Label = label;
            Type = type;
            Required = required;
        }
    }
}