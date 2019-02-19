using System.Linq.Expressions;
using Tusky.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Tusky.Criterion
{
    public class RangeProjections
    {
        internal RangeProjections() { }

        public static void RegisterHooks() => RegisterHooks<int>();

        protected static IProjection ProcessOperator(MethodCallExpression expression, string op) =>
            ProjectionWrapper.ProcessOperator(expression, op);

        protected static IProjection ProcessStart<T>(MemberExpression memberExpression)
        {
            var parentExpression = memberExpression.Expression;
            var projection = ProjectionWrapper.FindMemberProjection(parentExpression);
            return Projections.SqlFunction("lower", NHibernateUtil.GuessType(typeof(T)), projection);
        }

        protected static IProjection ProcessEnd<T>(MemberExpression memberExpression)
        {
            var parentExpression = memberExpression.Expression;
            var projection = ProjectionWrapper.FindMemberProjection(parentExpression);
            return Projections.SqlFunction("upper", NHibernateUtil.GuessType(typeof(T)), projection);
        }

        private static void RegisterHooks<T>()
        {
            var value = default(T);
            var range = new Range<T>(value, value);
            ExpressionProcessor.RegisterCustomProjection(() => range.Start, e => ProcessStart<T>(e));
            ExpressionProcessor.RegisterCustomProjection(() => range.End, e => ProcessEnd<T>(e));
            ExpressionProcessor.RegisterCustomProjection(() => range.Union(range), e => ProcessOperator(e, RangeOperator.Union));
            ExpressionProcessor.RegisterCustomProjection(() => range.Diff(range), e => ProcessOperator(e, RangeOperator.Diff));
            ExpressionProcessor.RegisterCustomProjection(() => range.Intersect(range), e => ProcessOperator(e, RangeOperator.Intersect));
        }
    }
}
