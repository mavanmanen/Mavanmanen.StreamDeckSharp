using System;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PropertyInspectorSelectOptionAttribute : Attribute
    {
        internal string Label { get; }
        internal string Value { get; }

        public PropertyInspectorSelectOptionAttribute(string label, string value)
        {
            Label = label;
            Value = value;
        }
    }
}