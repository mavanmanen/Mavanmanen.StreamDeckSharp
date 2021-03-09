using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal abstract class StreamDeckActionEvent : StreamDeckEvent
    {
        [JsonProperty("action")]
        public string Action { get; private set; }

        [JsonProperty("context")]
        public string Context { get; private set; }

        [JsonProperty("device")]
        public string Device { get; private set; }

        protected StreamDeckActionEvent(EventType eventType, string action, string context, string device) : base(eventType)
        {
            Action = action;
            Context = context;
            Device = device;
        }
    }
}