using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a email field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorEmailAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorEmailAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "email", required)
        {
            
        }
    }
}