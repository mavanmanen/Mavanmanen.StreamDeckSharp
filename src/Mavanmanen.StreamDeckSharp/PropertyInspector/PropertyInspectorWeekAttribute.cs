using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a week field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorWeekAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorWeekAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "week", required)
        {
            
        }
    }
}