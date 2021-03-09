using Mavanmanen.StreamDeckSharp.Enum;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetTitleMessage : Message
    {
        public SetTitleMessage(string context, string title, Target? target = null, int? state = null) : base(MessageEventType.SetTitle, context, new
        {
            title,
            target,
            state
        })
        {
        }
    }
}
