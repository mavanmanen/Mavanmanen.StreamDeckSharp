using Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetTitleMessage : Message
    {
        [JsonProperty("payload")]
        public SetTitlePayload Payload { get; private set; }

        public SetTitleMessage(string context, SetTitlePayload payload) : base(MessageEventType.SetTitle, context)
        {
            Payload = payload;
        }
    }
}
