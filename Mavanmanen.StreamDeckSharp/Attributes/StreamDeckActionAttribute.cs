using System;
using Mavanmanen.StreamDeckSharp.Attributes.Data;

namespace Mavanmanen.StreamDeckSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class StreamDeckActionAttribute : Attribute
    {
        internal ActionData Data { get; }

        /// <summary>
        /// A plugin can indeed have one or multiple actions.<br/>
        /// For example the Game Capture plugin has 6 actions: Scene, Record, Screenshot, Flashback Recording, Stream, Live Commentary.
        /// </summary>
        /// <param name="name">The name of the action. This string is visible to the user in the actions list.</param>
        /// <param name="icon">	The relative path to a PNG image without the .png extension.<br/>This image is displayed in the actions list.<br/>The PNG image should be a 20pt x 20pt image.<br/>You should provide @1x and @2x versions of the image.<br/>The Stream Deck application take care of loaded the appropriate version of the image.<br/>This icon is not required for actions not visible in the actions list (VisibleInActionsList set to false).</param>
        /// <param name="tooltip">The string displayed as tooltip when the user leaves the mouse over your action in the actions list.</param>
        /// <param name="propertyInspectorPath">This can override PropertyInspectorPath member from the plugin if you wish to have different PropertyInspectorPath based on the action.<br/>The relative path to the Property Inspector html file if your plugin want to display some custom settings in the Property Inspector.</param>
        /// <param name="supportedInMultiActions">Boolean to prevent the action from being used in a Multi Action.<br/>True by default.</param>
        /// <param name="visibleInActionsList">Boolean to hide the action in the actions list. This can be used for plugin that only works with a specific profile.<br/>True by default.</param>
        public StreamDeckActionAttribute(
            string name,
            string? icon,
            string? tooltip = null,
            string? propertyInspectorPath = null,
            bool supportedInMultiActions = true,
            bool visibleInActionsList = false)
        {
            if (icon == null && visibleInActionsList)
            {
                throw new ArgumentNullException(nameof(icon), "Icon may only be null if visibleInActionsList is set to false.");
            }

            Data  = new ActionData(name, icon, tooltip, propertyInspectorPath, supportedInMultiActions, visibleInActionsList);
        }
    }
}