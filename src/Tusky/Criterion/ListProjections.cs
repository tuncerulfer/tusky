using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Tusky.Criterion
{
    public class ListProjections
    {
        internal ListProjections() { }

        public static void RegisterHooks() => RegisterHooks<int>();

        protected static IProjection ProcessOperator(MethodCallExpression expression, string op) =>
            ProjectionWrapper.ProcessOperator(expression, op);

        private static void RegisterHooks<T>()
        {
            var value = default(T);
            var list = new List<T>() as IList<T>;
            ExpressionProcessor.RegisterCustomProjection(() => list.Union(list), e => ProcessOperator(e, ArrayOperator.Union));
            ExpressionProcessor.RegisterCustomProjection(() => list.Union(value), e => ProcessOperator(e, ArrayOperator.Union));
            ExpressionProcessor.RegisterCustomProjection(() => value.Union(list), e => ProcessOperator(e, ArrayOperator.Union));
        }
    }
}
