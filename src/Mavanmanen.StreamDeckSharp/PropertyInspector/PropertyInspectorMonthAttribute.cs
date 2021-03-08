using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorMonthAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorMonthAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "month", required)
        {
            
        }
    }
}