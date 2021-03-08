using Mavanmanen.StreamDeckSharp.Enum;

namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class SetImageMessage : Message
    {
        public SetImageMessage(string context, string? base64Image = null, Target? target = null, int? state = null) : base("setImage", context, new
        {
            image = base64Image,
            target,
            state
        })
        {
        }
    }
}
