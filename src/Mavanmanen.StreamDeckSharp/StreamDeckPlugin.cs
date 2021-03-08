using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp
{
    /// <summary>
    /// Represents the Stream Deck plugin instance.
    /// </summary>
    public abstract class StreamDeckPlugin : IDisposable
    {
        /// <summary>
        /// An opaque value identifying the plugin.
        /// </summary>
        public string Context { get; internal set; } = null!;

        /// <summary>
        /// An opaque value identifying the device.
        /// </summary>
        public string Device { get; internal set; } = null!;

        internal IPluginClient Client { get; set; } = null!;

        /// <summary>
        /// Called on startup to register your services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public virtual void RegisterServices(IServiceCollection services) { }

        /// <summary>
        /// Called when a device is connected.
        /// </summary>
        public virtual Task DeviceDidConnectAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when a device is disconnected.
        /// </summary>
        public virtual Task DeviceDidDisconnectAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when an application specified in the manifest is launched.
        /// </summary>
        /// <param name="application">The name of the application that was launched.</param>
        public virtual Task ApplicationDidLaunchAsync(string application) => Task.CompletedTask;

        /// <summary>
        /// Called when an application specified in the manifest is terminated.
        /// </summary>
        /// <param name="application">The name of the application that was terminated.</param>
        public virtual Task ApplicationDidTerminateAsync(string application) => Task.CompletedTask;

        /// <summary>
        /// Called when the host system wakes up, may be called multiple times during this process.
        /// </summary>
        public virtual Task SystemDidWakeUpAsync() => Task.CompletedTask;

        /// <summary>
        /// Called when global settings are received.
        /// </summary>
        /// <param name="settings">The settings payload.</param>
        public virtual Task DidReceiveGlobalSettingsAsync(JObject settings) => Task.CompletedTask;

        /// <summary>
        /// Save data securely and globally for the plugin.
        /// </summary>
        /// <param name="settings">The settings data, will be serialized to json.</param>
        protected async Task SetGlobalSettingsAsync(object settings) => await Client.SetGlobalSettings(Context, settings);

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
        /// Switch to a profile that is defined in the manifest.
        /// </summary>
        /// <param name="device">The device to do the switch.</param>
        /// <param name="profileName">The name of the profile to switch to.</param>
        protected async Task SwitchToProfile(string device, string? profileName) => await Client.SwitchToProfileAsync(Context, device, profileName);

        public void Dispose()
        {
        }
    }
}