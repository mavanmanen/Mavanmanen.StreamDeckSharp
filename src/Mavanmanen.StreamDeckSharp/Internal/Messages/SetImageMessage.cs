using Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetImageMessage : Message
    {
        [JsonProperty("payload")]
        public SetImagePayload Payload { get; private set; }

        public SetImageMessage(string context, SetImagePayload payload) : base(MessageEventType.SetImage, context)
        {
            Payload = payload;
        }
    }
}
