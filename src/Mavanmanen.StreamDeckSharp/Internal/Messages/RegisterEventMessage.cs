using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class RegisterEventMessage : Message
    {
        [JsonProperty("uuid")]
        public string UUID { get; }

        public RegisterEventMessage(string eventName, string uuid) : base(eventName)
        {
            UUID = uuid;
        }
    }
}