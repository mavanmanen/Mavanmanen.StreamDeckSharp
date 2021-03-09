using System;
using System.Linq.Expressions;

namespace Mavanmanen.StreamDeckSharp.Internal.Verification
{
    internal class VerifierBase<TClass, TProp>
    {
        protected readonly TProp Value;
        protected readonly string PropName;

        protected VerifierBase(TClass instance, Expression<Func<TClass, TProp>> memberSelector)
        {
            Value = memberSelector.Compile().Invoke(instance);
            PropName = ((MemberExpression)memberSelector.Body).Member.Name;
        }

        protected static void Fail(string message) => throw new Exception(message);
    }
}