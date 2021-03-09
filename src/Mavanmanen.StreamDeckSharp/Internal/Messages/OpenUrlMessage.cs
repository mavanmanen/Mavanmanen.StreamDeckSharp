namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class OpenUrlMessage : Message
    {
        public OpenUrlMessage(string url) : base(MessageEventType.OpenUrl, null, new { url })
        {
        }
    }
}
