using Newtonsoft.Json;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetGlobalSettingsMessage : Message
    {
        [JsonProperty("payload")]
        public object Payload { get; private set; }

        public SetGlobalSettingsMessage(string context, object payload) : base(MessageEventType.SetGlobalSettings, context)
        {
            Payload = payload;
        }
    }
}
