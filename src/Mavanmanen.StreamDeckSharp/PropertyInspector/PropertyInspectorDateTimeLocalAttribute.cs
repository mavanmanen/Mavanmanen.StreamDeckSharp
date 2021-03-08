using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a datetime-local field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorDateTimeLocalAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        private PropertyInspectorDateTimeLocalAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "datetime-local", required)
        {

        }
    }
}