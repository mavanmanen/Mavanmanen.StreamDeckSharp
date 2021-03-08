using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp
{
    public abstract class StreamDeckAction
    {
        public string Context { get; internal set; } = null!;
        public string Device { get; internal set; } = null!;
        public uint State { get; internal set; }
        public uint UserDesiredState { get; internal set; }
        public bool IsInMultiAction { get; internal set; }
        public JObject? Settings { get; internal set; }
        public Coordinates Coordinates { get; internal set; } = null!;

        protected TSettings? GetSettings<TSettings>() where TSettings : class => Settings == null ? null : JsonConvert.DeserializeObject<TSettings>(Settings!.ToString());

        public virtual Task OnKeyDownAsync() => Task.CompletedTask;
        public virtual Task OnKeyUpAsync() => Task.CompletedTask;
        public virtual Task WillAppearAsync() => Task.CompletedTask;
        public virtual Task WillDisappearAsync() => Task.CompletedTask;
        public virtual Task TitleParametersDidChange(string title, TitleParameters parameters) => Task.CompletedTask;
        public virtual Task DidReceiveSettingsAsync() => Task.CompletedTask;
    }
}