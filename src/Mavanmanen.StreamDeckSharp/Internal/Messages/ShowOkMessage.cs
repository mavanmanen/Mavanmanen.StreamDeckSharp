﻿namespace Mavanmanen.StreamDeckSharp.Internal.Messages
{
    internal class ShowOkMessage : Message
    {
        public ShowOkMessage(string context) : base(MessageEventType.ShowOk, context)
        {
        }
    }
}
