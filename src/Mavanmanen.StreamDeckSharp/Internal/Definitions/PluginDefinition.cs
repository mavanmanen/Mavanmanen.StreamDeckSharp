using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Mavanmanen.StreamDeckSharp.PropertyInspector;

namespace Mavanmanen.StreamDeckSharp.Internal.Definitions
{
    internal class PluginDefinition
    {
        public Type Type { get; }
        public PluginData PluginData { get; }
        public OsData? OsData { get; }
        public ProfileData[]? ProfileData { get; }
        public ApplicationsToMonitorData? ApplicationsToMonitorData { get; }
        public bool PropertyInspectorSet { get; }

        public PluginDefinition(Type type)
        {
            Type = type;

            PluginData = type.GetCustomAttribute<StreamDeckPluginAttribute>()!.Data;
            OsData = type.GetCustomAttribute<StreamDeckMinimumOsVersionAttribute>()?.Data;

            IEnumerable<StreamDeckProfileAttribute> profileAttributes = type.GetCustomAttributes<StreamDeckProfileAttribute>().ToArray();
            if (profileAttributes.Any())
            {
                ProfileData = profileAttributes.Select(p => p.Data).ToArray();
            }

            ApplicationsToMonitorData = type.GetCustomAttribute<StreamDeckApplicationsToMonitorAttribute>()?.Data;

            var propertyInspector = type.GetCustomAttribute<StreamDeckPropertyInspectorAttribute>();
            if (propertyInspector != null)
            {
                PropertyInspectorSet = true;
            }
        }
    }
}