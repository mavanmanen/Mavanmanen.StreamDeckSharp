using System;
using System.Linq.Expressions;

namespace Mavanmanen.StreamDeckSharp.Internal.Verification
{
    internal class IntVerifier<TClass> : VerifierBase<TClass, int?>
    {
        public IntVerifier(TClass instance, Expression<Func<TClass, int?>> memberSelector) : base(instance, memberSelector)
        {
        }

        public IntVerifier<TClass> Min(int n)
        {
            if (Value < n)
            {
                Fail($"Int {PropName} must be higher or equal to {n}");
            }

            return this;
        }

        public IntVerifier<TClass> Max(int n)
        {
            if (Value > n)
            {
                Fail($"Int {PropName} must be lower or equal to {n}");
            }

            return this;
        }
    }
}