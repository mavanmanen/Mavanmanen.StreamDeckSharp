namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetGlobalSettingsMessage : Message
    {
        public SetGlobalSettingsMessage(string context, object payload) : base(MessageEventType.SetGlobalSettings, context, payload)
        {
        }
    }
}
