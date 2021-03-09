using System;
using System.Linq.Expressions;

namespace Mavanmanen.StreamDeckSharp.Internal.Verification
{
    internal class VerifierBase<TClass, TProp> where TClass : Verifiable<TClass>
    {
        protected readonly TProp Value;
        protected readonly string PropName = null!;

        protected VerifierBase(TClass instance, Expression<Func<TClass, TProp>> memberSelector)
        {
            Value = memberSelector.Compile().Invoke(instance);

            if (memberSelector.Body is MemberExpression memberExpression)
            {
                PropName = memberExpression.Member.Name;
            }
            else if(memberSelector.Body is UnaryExpression unaryExpression)
            {
                PropName = ((MemberExpression) unaryExpression.Operand).Member.Name;
            }
        }

        protected static void Fail(string message) => throw new Exception(message);
    }
}