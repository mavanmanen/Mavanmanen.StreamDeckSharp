using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class KeyEvent : StreamDeckActionEvent
    {
        [JsonProperty("payload")]
        public KeyPayload Payload { get; private set; } = null!;
    }
}