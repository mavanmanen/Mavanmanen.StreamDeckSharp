using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a path field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorPathAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorPathAttribute([CallerMemberName]string? label = null, bool required = false) : base(label!, "path", required)
        {
            
        }
    }
}