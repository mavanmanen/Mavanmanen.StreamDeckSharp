using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal abstract class Message
    {
        [JsonProperty("event")]
        public string Event { get; }

        [JsonProperty("context")]
        public string? Context { get; }

        [JsonProperty("payload")]
        public object? Payload { get; protected set; }

        protected Message(string eventName, string? context = null, object? payload = null)
        {
            Event = eventName;
            Context = context;
            Payload = payload;
        }
    }
}
