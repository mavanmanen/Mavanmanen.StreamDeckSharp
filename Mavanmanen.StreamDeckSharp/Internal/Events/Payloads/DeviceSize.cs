using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.Payloads
{
    internal class DeviceSize
    {
        [JsonProperty("columns")]
        public int Columns { get; private set; }

        [JsonProperty("rows")]
        public int Rows { get; private set; }
    }
}