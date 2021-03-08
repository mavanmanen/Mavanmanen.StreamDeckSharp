using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    /// <summary>
    /// Used for a password field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorPasswordAttribute : PropertyInspectorItemBase
    {
        /// <inheritdoc />
        public PropertyInspectorPasswordAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "password", required)
        {
        }
    }
}