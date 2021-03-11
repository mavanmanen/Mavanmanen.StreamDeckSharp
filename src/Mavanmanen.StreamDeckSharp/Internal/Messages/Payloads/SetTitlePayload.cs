using Mavanmanen.StreamDeckSharp.Enum;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads
{
    internal class SetTitlePayload
    {
        [JsonProperty("title")]
        public string? Title { get; private set; }

        [JsonProperty("target")]
        public Target? Target { get; private set; }

        [JsonProperty("state")]
        public int? State { get; private set; }

        public SetTitlePayload(string title, Target? target = null, int? state = null)
        {
            Title = title;
            Target = target;
            State = state;
        }
    }
}