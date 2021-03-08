﻿using System;
using System.Runtime.CompilerServices;

namespace Mavanmanen.StreamDeckSharp.PropertyInspector
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInspectorWeekAttribute : PropertyInspectorItemBase
    {
        public PropertyInspectorWeekAttribute([CallerMemberName] string? label = null, bool required = false) : base(label!, "week", required)
        {
            
        }
    }
}