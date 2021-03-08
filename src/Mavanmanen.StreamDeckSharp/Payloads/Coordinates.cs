using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Payloads
{
    /// <summary>
    /// Coordinates of a key.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// The column index.
        /// </summary>
        [JsonProperty("column")]
        public int Column { get; private set; }

        /// <summary>
        /// The row index.
        /// </summary>
        [JsonProperty("row")]
        public int Row { get; private set; }
    }
}