using Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class OpenUrlMessage : Message
    {
        [JsonProperty("payload")]
        public OpenUrlPayload Payload { get; private set; }

        public OpenUrlMessage(OpenUrlPayload payload) : base(MessageEventType.OpenUrl)
        {
            Payload = payload;
        }
    }
}
