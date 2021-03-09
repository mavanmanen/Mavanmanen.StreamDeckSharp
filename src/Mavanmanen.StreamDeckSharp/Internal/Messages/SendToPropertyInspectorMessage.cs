namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SendToPropertyInspectorMessage : Message
    {
        public SendToPropertyInspectorMessage(string context, object payload) : base(MessageEventType.SentToPropertyInspector, context, payload)
        {
        }
    }
}
