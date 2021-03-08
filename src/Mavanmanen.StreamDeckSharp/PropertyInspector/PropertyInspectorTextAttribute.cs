using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorTextAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorTextAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "text", required)
        {
        }
    }
}