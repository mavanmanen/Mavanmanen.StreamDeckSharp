using Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SwitchToProfileMessage : Message
    {
        [JsonProperty("device")]
        public string Device { get; private set; }

        [JsonProperty("payload")]
        public SwitchToProfilePayload Payload { get; private set; }

        public SwitchToProfileMessage(string context, string device, SwitchToProfilePayload payload) : base(MessageEventType.SwitchToProfile, context)
        {
            Device = device;
            Payload = payload;
        }
    }
}
