namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetSettingsMessage : Message
    {
        public SetSettingsMessage(string context, object payload) : base("setSettings", context, payload)
        {
        }
    }
}