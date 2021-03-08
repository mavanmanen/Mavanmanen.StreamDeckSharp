using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorDateTimeLocalAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorDateTimeLocalAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "datetime-local", required)
        {

        }
    }
}