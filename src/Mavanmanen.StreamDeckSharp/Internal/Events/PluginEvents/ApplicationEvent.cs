using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal abstract class ApplicationEvent : StreamDeckPluginEvent
    {
        [JsonProperty("payload")]
        public ApplicationPayload Payload { get; private set; }


        protected ApplicationEvent(EventType eventType, string device, ApplicationPayload payload) : base(eventType, device)
        {
            Payload = payload;
        }
    }
}