using System;

namespace Mavanmanen.StreamDeckSharp
{
    public abstract class StreamDeckProfile
    {
        public virtual Type?[][]? StreamDeck3x5 { get; } = null!;
        public virtual Type?[][]? StreamDeckMini2x6 { get; } = null!;
        public virtual Type?[][]? StreamDeckXl4x8 { get; } = null!;
        public virtual Type?[][]? StreamDeckMobile3x5 { get; } = null!;
    }
}
