namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class OpenUrlMessage : Message
    {
        public OpenUrlMessage(string url) : base("openUrl", null, new { url })
        {
        }
    }
}
