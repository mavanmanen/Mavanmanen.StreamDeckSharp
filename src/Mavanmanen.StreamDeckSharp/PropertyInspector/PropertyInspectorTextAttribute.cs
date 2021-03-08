using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a text field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorTextAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorTextAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "text", required)
        {
        }
    }
}