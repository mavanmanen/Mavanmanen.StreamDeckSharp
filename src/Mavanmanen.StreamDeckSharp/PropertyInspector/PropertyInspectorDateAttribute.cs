﻿using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorDateAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorDateAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "date", required)
        {
            
        }
    }
}