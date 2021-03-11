using Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetStateMessage : Message
    {
        [JsonProperty("payload")]
        public SetStatePayload Payload { get; private set; }

        public SetStateMessage(string context, SetStatePayload payload) : base(MessageEventType.SetState, context)
        {
            Payload = payload;
        }
    }
}
