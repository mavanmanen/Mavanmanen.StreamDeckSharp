using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class StreamDeckPluginEvent : StreamDeckEvent
    {
        [JsonProperty("device")]
        public string Device { get; private set; } = null!;
    }
}