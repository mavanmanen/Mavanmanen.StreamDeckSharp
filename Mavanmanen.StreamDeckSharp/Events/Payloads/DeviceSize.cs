using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events.Payloads
{
    public class DeviceSize
    {
        [JsonProperty("columns")]
        public int Columns { get; private set; }

        [JsonProperty("rows")]
        public int Rows { get; private set; }
    }
}