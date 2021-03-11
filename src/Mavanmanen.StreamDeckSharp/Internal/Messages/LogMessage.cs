using Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class LogMessage : Message
    {
        [JsonProperty("payload")]
        public LogMessagePayload Payload { get; private set; }

        public LogMessage(LogMessagePayload payload) : base(MessageEventType.LogMessage)
        {
            Payload = payload;
        }
    }
}
