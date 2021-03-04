using Mavanmanen.StreamDeckSharp.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events
{
    public class ApplicationDidTerminateEvent : StreamDeckEvent
    {
        [JsonProperty("payload")]
        public ApplicationPayload? Payload { get; private set; }
    }
}