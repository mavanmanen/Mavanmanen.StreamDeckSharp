using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Events.Payloads
{
    internal class ApplicationPayload
    {
        [JsonProperty("application")]
        public string? Application { get; private set; }
    }
}