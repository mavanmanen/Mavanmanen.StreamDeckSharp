using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents.Payloads
{
    internal class DeviceSize
    {
        [JsonProperty("columns")]
        public int Columns { get; private set; }

        [JsonProperty("rows")]
        public int Rows { get; private set; }

        public DeviceSize()
        {
            
        }

        public DeviceSize(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }
    }
}