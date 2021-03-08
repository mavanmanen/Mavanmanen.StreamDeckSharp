using System;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Enum;
using Mavanmanen.StreamDeckSharp.Internal.Client;
using Mavanmanen.StreamDeckSharp.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp
{
    public abstract class StreamDeckAction : IDisposable
    {
        public string Context { get; internal set; } = null!;
        public string PluginContext { get; internal set; } = null!;
        public string Device { get; internal set; } = null!;
        public uint State { get; internal set; }
        public uint UserDesiredState { get; internal set; }
        public bool IsInMultiAction { get; internal set; }
        public JObject? Settings { get; internal set; }
        public Coordinates Coordinates { get; internal set; } = null!;
        internal IActionClient Client { get; set; } = null!;

        public virtual Task OnKeyDownAsync() => Task.CompletedTask;
        public virtual Task OnKeyUpAsync() => Task.CompletedTask;
        public virtual Task WillAppearAsync() => Task.CompletedTask;
        public virtual Task WillDisappearAsync() => Task.CompletedTask;
        public virtual Task TitleParametersDidChangeAsync(string title, TitleParameters parameters) => Task.CompletedTask;
        public virtual Task PropertyInspectorDidAppearAsync() => Task.CompletedTask;
        public virtual Task PropertyInspectorDidDisappearAsync() => Task.CompletedTask;

        protected TSettings? GetSettings<TSettings>() where TSettings : class => Settings == null ? null : JsonConvert.DeserializeObject<TSettings>(Settings!.ToString());
        protected async Task SetSettingsAsync(object settings) => await Client.SetSettingsAsync(Context, settings);
        protected async Task SetGlobalSettingsAsync(object settings) => await Client.SetGlobalSettings(PluginContext, settings);
        protected async Task OpenUrlAsync(string url) => await Client.OpenUrlAsync(url);
        protected async Task LogMessageAsync(string message) => await Client.LogMessageAsync(message);
        protected async Task SetTitleAsync(string title, Target? target = null, int? state = null) => await Client.SetTitleAsync(Context, title, target, state);
        protected async Task SetImageAsync(string? base64Image, Target? target = null, int? state = null) => await Client.SetImageAsync(Context, base64Image, target, state);
        protected async Task ShowAlertAsync() => await Client.ShowAlertAsync(Context);
        protected async Task ShowOkAsync() => await Client.ShowOkAsync(Context);
        protected async Task SetStateAsync(int state) => await Client.SetStateAsync(Context, state);
        protected async Task SendToPropertyInspectorAsync(object payload) => await Client.SendToPropertyInspectorAsync(Context, payload);
        protected async Task SwitchToProfile(string? profileName) => await Client.SwitchToProfileAsync(PluginContext, Device, profileName);

        public void Dispose()
        {
        }
    }
}