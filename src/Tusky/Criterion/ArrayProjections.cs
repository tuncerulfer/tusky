using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Tusky.Criterion
{
    public class ArrayProjections
    {
        internal ArrayProjections() { }

        public static void RegisterHooks() => RegisterHooks<int>();

        protected static IProjection ProcessOperator(MethodCallExpression expression, string op) =>
            ProjectionWrapper.ProcessOperator(expression, op);

        private static void RegisterHooks<T>()
        {
            var value = default(T);
            var array = new T[0] as Array;
            ExpressionProcessor.RegisterCustomProjection(() => array.Union(array), e => ProcessOperator(e, ArrayOperator.Union));
            ExpressionProcessor.RegisterCustomProjection(() => array.Union(value), e => ProcessOperator(e, ArrayOperator.Union));
            ExpressionProcessor.RegisterCustomProjection(() => value.Union(array), e => ProcessOperator(e, ArrayOperator.Union));
        }
    }
}
