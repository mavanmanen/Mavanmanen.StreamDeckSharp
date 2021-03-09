using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Mavanmanen.StreamDeckSharp.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp
{
    /// <summary>
    /// Represents a Stream Deck plugin action.
    /// </summary>
    public abstract class StreamDeckAction : IDisposable
    {
        /// <summary>
        /// An opaque value identifying the action.
        /// </summary>
        public string Context { get; internal set; } = null!;

        /// <summary>
        /// An opaque value identifying the plugin.
        /// </summary>
        public string PluginContext { get; internal set; } = null!;

        /// <summary>
        /// An opaque value identifying the device.
        /// </summary>
        public string Device { get; internal set; } = null!;

        /// <summary>
        /// This is a parameter that is only set when the action has multiple states defined in its manifest. The 0-based value contains the current state of the action.
        /// </summary>
        public uint State { get; internal set; }

        /// <summary>
        /// This is a parameter that is only set when the action is triggered with a specific value from a Multi Action. For example if the user sets the Game Capture Record action to be disabled in a Multi Action, you would see the value 1. Only the value 0 and 1 are valid.
        /// </summary>
        public uint UserDesiredState { get; internal set; }

        /// <summary>
        /// Boolean indicating if the action is inside a Multi Action.
        /// </summary>
        public bool IsInMultiAction { get; internal set; }

        /// <summary>
        /// This json object contains data that you can set and are stored persistently.
        /// </summary>
        public JObject? Settings { get; internal set; }

        /// <summary>
        /// The coordinates of the action triggered.
        /// </summary>
        public Coordinates Coordinates { get; internal set; } = null!;
        internal IActionClient Client { get; set; } = null!;

        /// <summary>
        /// Called when the action key is pressed.
        /// </summary>
        public virtual Task OnKeyDownAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when the action key is released.
        /// </summary>
        public virtual Task OnKeyUpAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when nstance of an action is displayed on the Stream Deck, for example when the hardware is first plugged in, or when a folder containing that action is entered.
        /// </summary>
        public virtual Task WillAppearAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when an instance of an action ceases to be displayed on Stream Deck, for example when switching profiles or folders.
        /// </summary>
        public virtual Task WillDisappearAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when the user changes the title or title parameters of the instance of an action.
        /// </summary>
        /// <param name="title">The new title.</param>
        /// <param name="parameters">A object describing the new title parameters.</param>
        public virtual Task TitleParametersDidChangeAsync(string title, TitleParameters parameters) => Task.CompletedTask;

        /// <summary>
        /// Called when the property inspector appears.
        /// </summary>
        public virtual Task PropertyInspectorDidAppearAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when the property inspector disappears.
        /// </summary>
        /// <returns></returns>
        public virtual Task PropertyInspectorDidDisappearAsync() => Task.CompletedTask;

        /// <summary>
        /// Get the settings, deserialized into the specified class.
        /// </summary>
        /// <typeparam name="TSettings">The class to deserialize the settings to.</typeparam>
        /// <returns>The settings object.</returns>
        protected TSettings? GetSettings<TSettings>() where TSettings : class => Settings == null ? null : JsonConvert.DeserializeObject<TSettings>(Settings!.ToString());

        /// <summary>
        /// Save data persistently for the action's instance.
        /// </summary>
        /// <param name="settings">The settings data, will be serialized to json.</param>
        protected async Task SetSettingsAsync(object settings) => await Client.SetSettingsAsync(Context, settings);

        /// <summary>
        /// Save data securely and globally for the plugin.
        /// </summary>
        /// <param name="settings">The settings data, will be serialized to json.</param>
        protected async Task SetGlobalSettingsAsync(object settings) => await Client.SetGlobalSettings(PluginContext, settings);

        /// <summary>
        /// Open a url on the host system.
        /// </summary>
        /// <param name="url">The url to open.</param>
        protected async Task OpenUrlAsync(string url) => await Client.OpenUrlAsync(url);

        /// <summary>
        /// Log a message to the Stream Deck driver software.
        /// </summary>
        /// <param name="message">The message to log.</param>
        protected async Task LogMessageAsync(string message) => await Client.LogMessageAsync(message);

        /// <summary>
        /// Dynamically change the title of an instance of an action.
        /// </summary>
        /// <param name="title">The title to display. If the title parameter is null, the title is reset to the title set by the user.</param>
        /// <param name="target">Specify if you want to display the title on the hardware and software, only on the hardware or only on the software. Default is hardware and software.</param>
        /// <param name="state">A 0-based integer value representing the state of an action with multiple states. This is an optional parameter. If not specified, the title is set to all states.</param>
        protected async Task SetTitleAsync(string title, Target? target = null, int? state = null) => await Client.SetTitleAsync(Context, title, target, state);

        /// <summary>
        /// Dynamically change the image displayed by an instance of an action.
        /// </summary>
        /// <param name="base64Image">The image to display encoded in base64 with the image format declared in the mime type (PNG, JPEG, BMP, ...). svg is also supported. If no image is passed, the image is reset to the default image from the manifest.</param>
        /// <param name="target">Specify if you want to display the title on the hardware and software, only on the hardware or only on the software. Default is hardware and software.</param>
        /// <param name="state">A 0-based integer value representing the state of an action with multiple states. This is an optional parameter. If not specified, the title is set to all states.</param>
        /// <returns></returns>
        protected async Task SetImageAsync(string? base64Image, Target? target = null, int? state = null) => await Client.SetImageAsync(Context, base64Image, target, state);

        /// <summary>
        /// Temporarily show an alert icon on the image displayed by an instance of an action.
        /// </summary>
        protected async Task ShowAlertAsync() => await Client.ShowAlertAsync(Context);

        /// <summary>
        /// Temporarily show an OK checkmark icon on the image displayed by an instance of an action.
        /// </summary>
        protected async Task ShowOkAsync() => await Client.ShowOkAsync(Context);

        /// <summary>
        /// Change the state of the action's instance supporting multiple states.
        /// </summary>
        /// <param name="state">A 0-based integer value representing the state requested.</param>
        protected async Task SetStateAsync(int state) => await Client.SetStateAsync(Context, state);

        /// <summary>
        /// Switch to a profile that is defined in the manifest.
        /// </summary>
        /// <param name="profileName">The name of the profile to switch to.</param>
        protected async Task SwitchToProfile(string? profileName) => await Client.SwitchToProfileAsync(PluginContext, Device, profileName);

        public void Dispose()
        {
        }
    }
}