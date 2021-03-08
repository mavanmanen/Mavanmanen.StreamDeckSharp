using System;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    public abstract class PropertyInspectorItemBase : Attribute
    {
        internal string Label { get; }
        internal string Type { get; }
        internal bool Required { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label">The label to display in the property inspector</param>
        /// <param name="type"></param>
        /// <param name="required">If the input is required or not.</param>
        protected PropertyInspectorItemBase(string label, string type, bool required)
        {
            Label = label;
            Type = type;
            Required = required;
        }
    }
}