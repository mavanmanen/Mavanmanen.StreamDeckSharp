using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class RegisterPluginMessage : Message
    {
        [JsonProperty("uuid")]
        public string UUID { get; private set; }

        public RegisterPluginMessage(string uuid) : base(MessageEventType.RegisterPlugin)
        {
            UUID = uuid;
        }
    }
}