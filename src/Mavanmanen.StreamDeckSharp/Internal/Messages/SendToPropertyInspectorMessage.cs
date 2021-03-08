namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SendToPropertyInspectorMessage : Message
    {
        public SendToPropertyInspectorMessage(string context, object payload) : base("sendToPropertyInspector", context, payload)
        {
        }
    }
}
