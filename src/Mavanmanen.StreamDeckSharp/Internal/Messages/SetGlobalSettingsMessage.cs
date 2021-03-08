namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetGlobalSettingsMessage : Message
    {
        public SetGlobalSettingsMessage(string context, object payload) : base("setGlobalSettings", context, payload)
        {
        }
    }
}
