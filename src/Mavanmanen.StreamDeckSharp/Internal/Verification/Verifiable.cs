using System;
using System.Linq.Expressions;

namespace Mavanmanen.StreamDeckSharp.Internal.Verification
{
    internal abstract class Verifiable<TClass>
    {
        protected static StringVerifier<TClass> Verify(TClass instance, Expression<Func<TClass, string?>> memberSelector)
        {
            return new StringVerifier<TClass>(instance, memberSelector);
        }

        protected static IntVerifier<TClass> Verify(TClass instance, Expression<Func<TClass, int?>> memberSelector)
        {
            return new IntVerifier<TClass>(instance, memberSelector);
        }
    }
}
