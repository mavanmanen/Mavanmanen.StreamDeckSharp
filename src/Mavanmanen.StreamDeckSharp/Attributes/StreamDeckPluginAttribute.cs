using System;
using System.Linq;
using Mavanmanen.StreamDeckSharp.Attributes.Data;

namespace Mavanmanen.StreamDeckSharp.Attributes
{
    /// <summary>
    /// The Stream Deck plugin.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class StreamDeckPluginAttribute : Attribute
    {
        internal PluginData Data { get; }
        
        /// <param name="name">The name of the plugin.<br/>This string is displayed to the user in the Stream Deck store.</param>
        /// <param name="icon">The relative path to a PNG image without the .png extension.<br/>This image is displayed in the Plugin Store window.<br/>The PNG image should be a 72pt x 72pt image.<br/>You should provide @1x and @2x versions of the image.<br/>The Stream Deck application takes care of loading the appropriate version of the image.</param>
        /// <param name="author">The author of the plugin.<br/>This string is displayed to the user in the Stream Deck store.</param>
        /// <param name="description">Provides a general description of what the plugin does.<br/>This string is displayed to the user in the Stream Deck store.</param>
        /// <param name="version">The version of the plugin which can only contain digits and periods.<br/>This is used for the software update mechanism.</param>
        /// <param name="url">A URL displayed to the user if they want to get more info about the plugin.</param>
        /// <param name="category">The name of the custom category in which the actions should be listed.<br/>This string is visible to the user in the actions list.<br/>If you don't provide a category, the actions will appear inside a "Custom" category.</param>
        /// <param name="categoryIcon">The relative path to a PNG image without the .png extension.<br/>This image is used in the actions list.<br/>The PNG image should be a 28pt x 28pt image.<br/>You should provide @1x and @2x versions of the image.<br/>The Stream Deck application takes care of loading the appropriate version of the image.</param>
        /// <param name="propertyInspectorPath">The relative path to the Property Inspector html file if your plugin want to display some custom settings in the Property Inspector.<br/>If missing, the plugin will have an empty Property Inspector.</param>
        /// <param name="defaultWindowSize">Specify the default window size when a Javascript plugin or Property Inspector opens a window using window.open().<br/>Default value is "500,650".</param>
        public StreamDeckPluginAttribute(
            string name,
            string icon,
            string author,
            string description,
            string version,
            string? url = null,
            string? category = null,
            string? categoryIcon = null,
            string? propertyInspectorPath = null,
            string? defaultWindowSize = null)
        {
            if (category != null && categoryIcon == null)
            {
                throw new ArgumentNullException(nameof(categoryIcon), "CategoryIcon must be set when the category is also set.");
            }

            (int, int)? defaultWindowSizeTuple = null;

            if (defaultWindowSize != null)
            {
                int[] values = defaultWindowSize.Split(',').Select(int.Parse).ToArray();
                defaultWindowSizeTuple = (values[0], values[1]);
            }
            

            Data = new PluginData(name, icon, author, description, version, url, category, categoryIcon, propertyInspectorPath, defaultWindowSizeTuple);
        }
    }
}