using Mavanmanen.StreamDeckSharp.Events.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events
{
    public class ApplicationDidLaunchEvent : StreamDeckEvent
    {
        [JsonProperty("payload")]
        public ApplicationPayload? Payload { get; private set; }
    }
}