using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorSelectAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorSelectAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "select", required)
        {
        }
    }
}