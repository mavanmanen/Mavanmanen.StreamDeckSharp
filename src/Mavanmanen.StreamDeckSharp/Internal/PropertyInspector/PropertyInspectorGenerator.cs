using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Mavanmanen.StreamDeckSharp.Internal.Definitions;
using Mavanmanen.StreamDeckSharp.PropertyInspector;

namespace Mavanmanen.StreamDeckSharp.Internal.PropertyInspector
{
    internal class PropertyInspectorGenerator
    {
        private const string DIR = "./propertyInspector";
        private readonly List<ActionDefinition> _actions;

        public PropertyInspectorGenerator(List<ActionDefinition> actions)
        {
            _actions = actions;
        }

        public void GeneratePropertyInspectors()
        {
            WriteSharedItems();
            foreach (var (key, value) in GetPropertyInspectorTypeMap())
            {
                string? page = GeneratePage(value);
                File.WriteAllText($"{DIR}/{key}.html", page);
            }
        }

        private static void WriteSharedItems()
        {
            Directory.CreateDirectory(DIR);
            string css = GetEmbeddedResource("sdpi.css");
            string js = GetEmbeddedResource("pi.js");

            File.WriteAllText($"{DIR}/sdpi.css", css);
            File.WriteAllText($"{DIR}/pi.js", js);
        }

        private static string GetEmbeddedResource(string filename)
        {
            using Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream($"Mavanmanen.StreamDeckSharp.Internal.PropertyInspector.Templates.{filename}")!;
            using StreamReader reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        private static string GetControlTemplate(string filename)
        {
            return GetEmbeddedResource($"Controls.{filename}");
        }

        private Dictionary<string, Type> GetPropertyInspectorTypeMap()
        {
            return _actions
                .Select(a => new
                {
                    key = a.ActionData.Name,
                    value = a.Type.GetCustomAttribute<StreamDeckPropertyInspectorAttribute>()?.SettingsType
                })
                .Where(kv => kv.value != null)
                .ToDictionary(kv => kv.key, kv => kv.value!);
        }

        internal static string? GeneratePage(Type propertyInspectorType)
        {
            object? instance = Activator.CreateInstance(propertyInspectorType);
            if (instance == null)
            {
                return null;
            }

            var properties = propertyInspectorType
                .GetProperties()
                .Where(p => p.CustomAttributes.Any(a => a.AttributeType.IsAssignableTo(typeof(PropertyInspectorItemBase))))
                .ToArray();

            if (!properties.Any())
            {
                return null;
            }

            var sb = new StringBuilder();

            foreach (PropertyInfo property in properties)
            {
                Type attributeType = property.CustomAttributes.Single(a => a.AttributeType.IsAssignableTo(typeof(PropertyInspectorItemBase))).AttributeType;
                var attribute = (PropertyInspectorItemBase) property.GetCustomAttribute(attributeType)!;
                object? propertyValue = property.GetValue(instance);

                sb.AppendLine();

                switch (attribute)
                {
                    case PropertyInspectorTextAreaAttribute:
                        sb.AppendLine(CreateTextArea(attribute, propertyValue));
                        break;

                    case PropertyInspectorSelectAttribute:
                        PropertyInspectorSelectOptionAttribute[] options = property.GetCustomAttributes<PropertyInspectorSelectOptionAttribute>().ToArray();
                        sb.AppendLine(CreateSelect(attribute, options, propertyValue));
                        break;

                    default:
                        sb.AppendLine(CreateSimpleField(attribute, propertyValue));
                        break;
                }
            }

            string? template = GetEmbeddedResource("pi.html");
            template = template.Replace("{{ CONTENT }}", sb.ToString());
            return template;
        }

        private static string CreateSimpleField(PropertyInspectorItemBase attribute, object? defaultValue)
        {
            string template = GetControlTemplate("simple.html");
            template = template.Replace("{{ LABEL }}", attribute.Label);
            template = template.Replace("{{ TYPE }}", attribute.Type);
            template = template.Replace("{{ VALUE }}", defaultValue == null ? "" : (string) defaultValue);
            template = template.Replace("{{ REQUIRED }}", attribute.Required ? "required" : "");

            return template;
        }

        private static string CreateTextArea(PropertyInspectorItemBase attribute, object? defaultValue)
        {
            string template = GetControlTemplate("textarea.html");
            template = template.Replace("{{ LABEL }}", attribute.Label);
            template = template.Replace("{{ VALUE }}", defaultValue == null ? "" : (string) defaultValue);
            template = template.Replace("{{ REQUIRED }}", attribute.Required ? "required" : "");

            return template;
        }

        private static string CreateSelect(PropertyInspectorItemBase attribute, PropertyInspectorSelectOptionAttribute[] options, object? defaultValue)
        {
            string template = GetControlTemplate("select.html");
            template = template.Replace("{{ LABEL }}", attribute.Label);
            template = template.Replace("{{ REQUIRED }}", attribute.Required ? "required" : "");

            var sb = new StringBuilder();
            foreach (PropertyInspectorSelectOptionAttribute option in options)
            {
                sb.Append($"\t\t<option value='{option.Value}' {(option.Value == (string?) defaultValue ? "selected" : "")}>{option.Label}</option>");
                if (!Equals(option, options.Last()))
                {
                    sb.Append('\n');
                }
            }

            template = template.Replace("{{ OPTIONS }}", sb.ToString());

            return template;
        }
    }
}
