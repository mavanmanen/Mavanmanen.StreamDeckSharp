using Mavanmanen.StreamDeckSharp.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents.Payloads
{
    internal class TitleParametersPayload
    {
        [JsonProperty("settings")]
        public JObject? Settings { get; private set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; private set; } = null!;

        [JsonProperty("state")]
        public uint State { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; } = null!;

        [JsonProperty("titleParameters")]
        public TitleParameters TitleParameters { get; private set; } = null!;

        public TitleParametersPayload()
        {
            
        }

        public TitleParametersPayload(Coordinates coordinates, uint state, string title, TitleParameters titleParameters, JObject? settings = null)
        {
            Coordinates = coordinates;
            State = state;
            Title = title;
            TitleParameters = titleParameters;
            Settings = settings;
        }
    }
}