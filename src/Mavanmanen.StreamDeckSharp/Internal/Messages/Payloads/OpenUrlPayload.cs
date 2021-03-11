using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads
{
    internal class OpenUrlPayload
    {
        [JsonProperty("url")]
        public string Url { get; private set; }

        public OpenUrlPayload(string url)
        {
            Url = url;
        }
    }
}
