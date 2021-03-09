using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal abstract class StreamDeckPluginEvent : StreamDeckEvent
    {
        [JsonProperty("device")]
        public string Device { get; private set; }

        protected StreamDeckPluginEvent(EventType eventType, string device) : base(eventType)
        {
            Device = device;
        }
    }
}