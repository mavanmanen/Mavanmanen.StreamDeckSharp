using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorTextAreaAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorTextAreaAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "textarea", required)
        {
            
        }
    }
}