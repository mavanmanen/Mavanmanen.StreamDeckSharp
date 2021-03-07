using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class ApplicationDidLaunchEvent : StreamDeckPluginEvent
    {
        [JsonProperty("payload")]
        public ApplicationPayload? Payload { get; private set; }
    }
}