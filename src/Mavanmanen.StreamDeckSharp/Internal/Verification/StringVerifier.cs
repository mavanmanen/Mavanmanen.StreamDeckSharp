using System;
using System.Linq.Expressions;

namespace Mavanmanen.StreamDeckSharp.Internal.Verification
{
    internal class StringVerifier<TClass> : VerifierBase<TClass, string?> where TClass : Verifiable<TClass>
    {
        public StringVerifier(TClass instance, Expression<Func<TClass, string?>> memberSelector) : base(instance, memberSelector)
        {
        }

        public StringVerifier<TClass> NotNull()
        {
            if (Value == null)
            {
                Fail($"String {PropName} must not be null.");
            }

            return this;
        }

        public StringVerifier<TClass> NotEmpty()
        {
            if (Value == string.Empty)
            {
                Fail($"String {PropName} must not be empty.");
            }

            return this;
        }

        public StringVerifier<TClass> Regex(string pattern)
        {
            if (Value == null)
            {
                return this;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(Value, pattern))
            {
                Fail($"String {PropName} does not match pattern '{pattern}'.");
            }

            return this;
        }
    }
}