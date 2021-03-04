using Mavanmanen.StreamDeckSharp.Internal.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events
{
    internal class ApplicationDidTerminateEvent : StreamDeckEvent
    {
        [JsonProperty("payload")]
        public ApplicationPayload? Payload { get; private set; }
    }
}