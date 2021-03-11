using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SendToPropertyInspectorMessage : Message
    {
        [JsonProperty("payload")]
        public object Payload { get; private set; }

        public SendToPropertyInspectorMessage(string context, object payload) : base(MessageEventType.SentToPropertyInspector, context)
        {
            Payload = payload;
        }
    }
}
