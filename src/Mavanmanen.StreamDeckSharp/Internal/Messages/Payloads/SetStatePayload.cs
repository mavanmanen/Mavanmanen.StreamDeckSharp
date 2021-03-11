using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages.Payloads
{
    internal class SetStatePayload
    {
        [JsonProperty("state")]
        public int State { get; private set; }

        public SetStatePayload(int state)
        {
            State = state;
        }
    }
}
