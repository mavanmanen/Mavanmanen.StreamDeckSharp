using System;
using System.Linq;
using System.Reflection;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Attributes.Data;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.PropertyInspector;

namespace Mavanmanen.StreamDeckSharp.Internal.Definitions
{
    internal class ActionDefinition
    {
        public Type Type { get; }
        public ActionData ActionData { get; }
        public ActionStateData[]? ActionStateData { get; }
        public bool PropertyInspectorSet { get; }


        public ActionDefinition(Type type)
        {
            Type = type;

            ActionData = Type.GetCustomAttribute<StreamDeckActionAttribute>()!.Data;

            StreamDeckActionStateAttribute[] stateAttributes = type.GetCustomAttributes<StreamDeckActionStateAttribute>().ToArray();
            if (stateAttributes.Any())
            {
                ActionStateData = stateAttributes.Select(a => a.Data).ToArray();
            }
            else if(ActionData.Icon != null)
            {
                ActionStateData = new []
                {
                    new ActionStateData(ActionData.Icon, null, null, null, true, null, TitleAlignment.Middle, FontFamily.Arial, FontStyle.Regular, null, false) 
                };
            }

            var propertyInspector = type.GetCustomAttribute<StreamDeckPropertyInspectorAttribute>();
            if (propertyInspector != null)
            {
                PropertyInspectorSet = true;
            }
        }
    }
}