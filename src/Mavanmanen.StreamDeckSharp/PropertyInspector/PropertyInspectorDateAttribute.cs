using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a date field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorDateAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorDateAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "date", required)
        {
            
        }
    }
}