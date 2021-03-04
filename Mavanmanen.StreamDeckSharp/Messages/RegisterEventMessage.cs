using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Messages
{
    internal class RegisterEventMessage : IMessage
    {
        [JsonProperty("event")]
        public string Event { get; }

        [JsonProperty("uuid")]
        public string UUID { get; }

        public RegisterEventMessage(string eventName, string uuid)
        {
            Event = eventName;
            UUID = uuid;
        }
    }
}