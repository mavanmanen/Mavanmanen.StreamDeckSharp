namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class LogMessage : Message
    {
        public LogMessage(string message) : base("logMessage", null, new { message })
        {
        }
    }
}
