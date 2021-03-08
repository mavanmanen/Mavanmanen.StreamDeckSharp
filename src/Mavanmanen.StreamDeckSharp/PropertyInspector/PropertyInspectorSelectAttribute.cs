using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a select field
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorSelectAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorSelectAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "select", required)
        {
        }
    }
}