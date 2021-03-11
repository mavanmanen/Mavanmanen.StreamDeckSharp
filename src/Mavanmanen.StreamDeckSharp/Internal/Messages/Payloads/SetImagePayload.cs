using Mavanmanen.StreamDeckSharp.Enum;
using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads
{
    internal class SetImagePayload
    {
        [JsonProperty("image")]
        public string? Image { get; private set; }

        [JsonProperty("target")]
        public Target? Target { get; private set; }

        [JsonProperty("state")]
        public int? State { get; private set; }

        public SetImagePayload(string image, Target? target = null, int? state = null)
        {
            Image = image;
            Target = target;
            State = state;
        }
    }
}
