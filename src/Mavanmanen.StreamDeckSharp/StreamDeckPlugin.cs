using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp
{
    public abstract class StreamDeckPlugin : IDisposable
    {
        public string Context { get; internal set; } = null!;
        public string Device { get; internal set; } = null!;
        internal IPluginClient Client { get; set; } = null!;
        public virtual void RegisterServices(IServiceCollection services) { }

        public virtual Task DeviceDidConnectAsync() => Task.CompletedTask;
        public virtual Task DeviceDidDisconnectAsync() => Task.CompletedTask;
        public virtual Task ApplicationDidLaunchAsync(string application) => Task.CompletedTask;
        public virtual Task ApplicationDidTerminateAsync(string application) => Task.CompletedTask;
        public virtual Task SystemDidWakeUpAsync() => Task.CompletedTask;
        public virtual Task DidReceiveGlobalSettingsAsync(JObject settings) => Task.CompletedTask;

        protected async Task SetGlobalSettingsAsync(object settings) => await Client.SetGlobalSettings(Context, settings);
        protected async Task OpenUrlAsync(string url) => await Client.OpenUrlAsync(url);
        protected async Task LogMessageAsync(string message) => await Client.LogMessageAsync(message);
        protected async Task SwitchToProfile(string device, string? profileName) => await Client.SwitchToProfileAsync(Context, device, profileName);

        public void Dispose()
        {
        }

    }
}