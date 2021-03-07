using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class AppearanceEvent : StreamDeckActionEvent
    {
        [JsonProperty("payload")]
        public AppearancePayload Payload { get; private set; } = null!;
    }
}