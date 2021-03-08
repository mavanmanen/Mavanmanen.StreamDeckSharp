namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetStateMessage : Message
    {
        public SetStateMessage(string context, int state) : base("setState", context, new { state })
        {
        }
    }
}
