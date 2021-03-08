using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorPasswordAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorPasswordAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "password", required)
        {
        }
    }
}