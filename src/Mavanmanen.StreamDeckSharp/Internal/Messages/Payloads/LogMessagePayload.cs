using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads
{
    internal class LogMessagePayload
    {
        [JsonProperty("message")]
        public string Message { get; private set; }

        public LogMessagePayload(string message)
        {
            Message = message;
        }
    }
}
