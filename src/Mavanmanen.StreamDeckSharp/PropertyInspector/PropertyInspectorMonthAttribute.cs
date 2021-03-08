using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a month field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorMonthAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorMonthAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "month", required)
        {
            
        }
    }
}