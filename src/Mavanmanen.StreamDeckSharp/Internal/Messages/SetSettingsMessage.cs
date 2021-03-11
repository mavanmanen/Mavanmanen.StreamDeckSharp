using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetSettingsMessage : Message
    {
        [JsonProperty("payload")]
        public object Payload { get; private set; }

        public SetSettingsMessage(string context, object payload) : base(MessageEventType.SetSettings, context)
        {
            Payload = payload;
        }
    }
}