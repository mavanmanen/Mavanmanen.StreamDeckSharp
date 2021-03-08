using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a time field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorTimeAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorTimeAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "time", required)
        {
            
        }
    }
}