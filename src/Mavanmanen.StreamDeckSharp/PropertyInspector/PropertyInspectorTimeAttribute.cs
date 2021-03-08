using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorTimeAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorTimeAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "time", required)
        {
            
        }
    }
}