namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetSettingsMessage : Message
    {
        public SetSettingsMessage(string context, object payload) : base(MessageEventType.SetSettings, context, payload)
        {
        }
    }
}