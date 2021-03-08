using System;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for select field options.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PropertyInspectorSelectOptionAttribute : Attribute
    {
        internal string Label { get; }
        internal string Value { get; }

        /// <param name="label">The option's label.</param>
        /// <param name="value">The option's value.</param>
        public PropertyInspectorSelectOptionAttribute(string label, string value)
        {
            Label = label;
            Value = value;
        }
    }
}