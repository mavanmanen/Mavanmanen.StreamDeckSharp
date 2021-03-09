using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents
{
    internal class TitleParameterDidChangeEvent : StreamDeckActionEvent
    {
        [JsonProperty("payload")]
        public TitleParametersPayload Payload { get; private set; }

        public TitleParameterDidChangeEvent(string action, string context, string device, TitleParametersPayload payload) : base(EventType.TitleParametersDidChange, action, context, device)
        {
            Payload = payload;
        }
    }
}