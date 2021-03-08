using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorEmailAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorEmailAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "email", required)
        {
            
        }
    }
}