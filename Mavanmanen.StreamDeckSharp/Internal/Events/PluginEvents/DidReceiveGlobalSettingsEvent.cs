using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents
{
    internal class DidReceiveGlobalSettingsEvent : StreamDeckPluginEvent
    {
        [JsonProperty("payload")]
        public ReceiveGlobalSettingsPayload? Payload { get; private set; }
    }
}