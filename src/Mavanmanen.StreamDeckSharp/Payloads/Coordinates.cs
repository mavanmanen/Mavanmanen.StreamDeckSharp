using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Payloads
{
    public class Coordinates
    {
        [JsonProperty("column")]
        public int Column { get; private set; }

        [JsonProperty("row")]
        public int Row { get; private set; }
    }
}