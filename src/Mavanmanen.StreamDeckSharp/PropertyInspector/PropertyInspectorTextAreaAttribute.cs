using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a textarea field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorTextAreaAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorTextAreaAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "textarea", required)
        {
            
        }
    }
}