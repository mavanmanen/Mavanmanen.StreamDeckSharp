using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Events.Payloads
{
    public class ApplicationPayload
    {
        [JsonProperty("application")]
        public string? Application { get; private set; }
    }
}