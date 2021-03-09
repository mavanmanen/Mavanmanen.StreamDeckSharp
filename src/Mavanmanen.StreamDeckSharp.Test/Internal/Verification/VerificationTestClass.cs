using Mavanmanen.StreamDeckSharp.Internal.Verification;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.Verification
{
    internal class VerificationTestClass : Verifiable<VerificationTestClass>
    {
        public string StringProperty { get; set; }
        public int? IntProperty { get; set; }
    }
}