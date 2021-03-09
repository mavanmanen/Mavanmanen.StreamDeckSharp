using Mavanmanen.StreamDeckSharp.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads
{
    internal class AppearancePayload
    {
        [JsonProperty("settings")]
        public JObject? Settings { get; private set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; private set; } = null!;

        [JsonProperty("state")]
        public uint State { get; private set; }

        [JsonProperty("isInMultiAction")]
        public bool IsInMultiAction { get; private set; }

        public AppearancePayload()
        {
            
        }

        public AppearancePayload(Coordinates coordinates, uint state, bool isInMultiAction, JObject? settings = null)
        {
            Coordinates = coordinates;
            State = state;
            IsInMultiAction = isInMultiAction;
            Settings = settings;
        }
    }
}