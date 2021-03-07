using System;
using Mavanmanen.StreamDeckSharp.Attributes.Data;

namespace Mavanmanen.StreamDeckSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class StreamDeckActionStateAttribute : Attribute
    {
        internal ActionStateData Data { get; }

        /// <summary>
        /// Specifies an array of states.<br/>
        /// Each action can have one state or 2 states (on/off).<br/>
        /// For example the Hotkey action has a single state. However the Game Capture Record action has 2 states, active and inactive.
        /// </summary>
        /// <param name="image">The default image for the state.</param>
        /// <param name="name">The name of the state displayed in the dropdown menu in the Multi action.<br/>For example Start or Stop for the states of the Game Capture Record action.<br/>If the name is not provided, the state will not appear in the Multi Action.</param>
        /// <param name="multiActionImage">This can be used if you want to provide a different image for the state when the action is displayed in a Multi Action.</param>
        /// <param name="title">Default title.</param>
        /// <param name="showTitle">Boolean to hide/show the title.<br/>True by default.</param>
        /// <param name="titleColor">Default title color.</param>
        /// <param name="titleAlignment">Default title vertical alignment.</param>
        /// <param name="fontFamily">Default font family for the title.</param>
        /// <param name="fontStyle">Default font style for the title.</param>
        /// <param name="fontSize">Default font size for the title.</param>
        /// <param name="fontUnderline">Boolean to have an underline under the title.<br/>False by default.</param>
        public StreamDeckActionStateAttribute(
            string image,
            string? name = null,
            string? multiActionImage = null,
            string? title = null,
            bool showTitle = true,
            string? titleColor = null,
            TitleAlignment titleAlignment = TitleAlignment.Middle,
            FontFamily fontFamily = FontFamily.Arial,
            FontStyle fontStyle = FontStyle.Regular,
            string? fontSize = null,
            bool fontUnderline = false)
        {
            Data = new ActionStateData(image, name, multiActionImage, title, showTitle, titleColor, titleAlignment, fontFamily, fontStyle, fontSize != null ? int.Parse(fontSize) : (int?) null, fontUnderline);
        }
    }
}