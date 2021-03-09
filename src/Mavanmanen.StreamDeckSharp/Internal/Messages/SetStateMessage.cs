namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetStateMessage : Message
    {
        public SetStateMessage(string context, int state) : base(MessageEventType.SetState, context, new { state })
        {
        }
    }
}
