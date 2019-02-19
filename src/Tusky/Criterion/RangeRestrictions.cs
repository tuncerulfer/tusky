using System.Linq.Expressions;
using Tusky.Entities;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Tusky.Criterion
{
    public class RangeRestrictions
    {
        internal RangeRestrictions() { }

        public static AbstractCriterion Equal(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.Equal);

        public static AbstractCriterion Equal(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.Equal);

        public static AbstractCriterion NotEqual(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.NotEqual);

        public static AbstractCriterion NotEqual(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.NotEqual);

        public static AbstractCriterion GreaterThan(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.GreaterThan);

        public static AbstractCriterion GreaterThan(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.GreaterThan);

        public static AbstractCriterion LessThan(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.LessThan);

        public static AbstractCriterion LessThan(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.LessThan);

        public static AbstractCriterion GreaterThanOrEqual(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqual(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.GreaterThanOrEqual);

        public static AbstractCriterion LessThanOrEqual(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqual(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.LessThanOrEqual);

        public static AbstractCriterion Contains(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.Contains);

        public static AbstractCriterion Contains(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.Contains);

        public static AbstractCriterion ContainedBy(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.ContainedBy);

        public static AbstractCriterion ContainedBy(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.ContainedBy);

        public static AbstractCriterion Overlaps(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.Overlaps);

        public static AbstractCriterion Overlaps(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.Overlaps);

        public static AbstractCriterion StrictlyLeftOf(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.StrictlyLeftOf);

        public static AbstractCriterion StrictlyLeftOf(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.StrictlyLeftOf);

        public static AbstractCriterion StrictlyRightOf(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.StrictlyRightOf);

        public static AbstractCriterion StrictlyRightOf(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.StrictlyRightOf);

        public static AbstractCriterion NotExtendLeftOf(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.NotExtendLeftOf);

        public static AbstractCriterion NotExtendLeftOf(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.NotExtendLeftOf);

        public static AbstractCriterion NotExtendRightOf(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.NotExtendRightOf);

        public static AbstractCriterion NotExtendRightOf(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.NotExtendRightOf);

        public static AbstractCriterion AdjacentTo(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, RangeOperator.AdjacentTo);

        public static AbstractCriterion AdjacentTo(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, RangeOperator.AdjacentTo);

        public static AbstractCriterion EqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.Equal);

        public static AbstractCriterion EqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.Equal);

        public static AbstractCriterion EqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.Equal);

        public static AbstractCriterion EqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.Equal);

        public static AbstractCriterion NotEqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.NotEqual);

        public static AbstractCriterion NotEqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.NotEqual);

        public static AbstractCriterion NotEqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.NotEqual);

        public static AbstractCriterion NotEqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.NotEqual);

        public static AbstractCriterion GreaterThanProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.GreaterThan);

        public static AbstractCriterion GreaterThanProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.GreaterThan);

        public static AbstractCriterion GreaterThanProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.GreaterThan);

        public static AbstractCriterion GreaterThanProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.GreaterThan);

        public static AbstractCriterion LessThanProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.LessThan);

        public static AbstractCriterion LessThanProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.LessThan);

        public static AbstractCriterion LessThanProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.LessThan);

        public static AbstractCriterion LessThanProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.LessThan);

        public static AbstractCriterion GreaterThanOrEqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.GreaterThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.LessThanOrEqual);

        public static AbstractCriterion ContainsProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.Contains);

        public static AbstractCriterion ContainsProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.Contains);

        public static AbstractCriterion ContainsProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.Contains);

        public static AbstractCriterion ContainsProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.Contains);

        public static AbstractCriterion ContainedByProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.ContainedBy);

        public static AbstractCriterion ContainedByProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.ContainedBy);

        public static AbstractCriterion ContainedByProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.ContainedBy);

        public static AbstractCriterion ContainedByProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.ContainedBy);

        public static AbstractCriterion OverlapsProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.Overlaps);

        public static AbstractCriterion OverlapsProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.Overlaps);

        public static AbstractCriterion OverlapsProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.Overlaps);

        public static AbstractCriterion OverlapsProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.Overlaps);

        public static AbstractCriterion StrictlyLeftOfProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.StrictlyLeftOf);

        public static AbstractCriterion StrictlyLeftOfProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.StrictlyLeftOf);

        public static AbstractCriterion StrictlyLeftOfProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.StrictlyLeftOf);

        public static AbstractCriterion StrictlyLeftOfProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.StrictlyLeftOf);

        public static AbstractCriterion StrictlyRightOfProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.StrictlyRightOf);

        public static AbstractCriterion StrictlyRightOfProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.StrictlyRightOf);

        public static AbstractCriterion StrictlyRightOfProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.StrictlyRightOf);

        public static AbstractCriterion StrictlyRightOfProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.StrictlyRightOf);

        public static AbstractCriterion NotExtendLeftOfProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.NotExtendLeftOf);

        public static AbstractCriterion NotExtendLeftOfProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.NotExtendLeftOf);

        public static AbstractCriterion NotExtendLeftOfProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.NotExtendLeftOf);

        public static AbstractCriterion NotExtendLeftOfProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.NotExtendLeftOf);

        public static AbstractCriterion NotExtendRightOfProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.NotExtendRightOf);

        public static AbstractCriterion NotExtendRightOfProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.NotExtendRightOf);

        public static AbstractCriterion NotExtendRightOfProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.NotExtendRightOf);

        public static AbstractCriterion NotExtendRightOfProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.NotExtendRightOf);

        public static AbstractCriterion AdjacentToProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, RangeOperator.AdjacentTo);

        public static AbstractCriterion AdjacentToProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, RangeOperator.AdjacentTo);

        public static AbstractCriterion AdjacentToProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, RangeOperator.AdjacentTo);

        public static AbstractCriterion AdjacentToProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, RangeOperator.AdjacentTo);

        public static void RegisterHooks() => RegisterHooks<int>();

        protected static ICriterion ProcessCompare<T>(MethodCallExpression expression, string op) =>
            RestrictionWrapper.ProcessCompare<T>(expression, op);

        private static void RegisterHooks<T>()
        {
            var value = default(T);
            var range = new Range<T>(value, value);
            ExpressionProcessor.RegisterCustomMethodCall(() => range.Equal(range), e => ProcessCompare<T>(e, RangeOperator.Equal));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.NotEqual(range), e => ProcessCompare<T>(e, RangeOperator.NotEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.GreaterThan(range), e => ProcessCompare<T>(e, RangeOperator.GreaterThan));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.LessThan(range), e => ProcessCompare<T>(e, RangeOperator.LessThan));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.GreaterThanOrEqual(range), e => ProcessCompare<T>(e, RangeOperator.GreaterThanOrEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.LessThanOrEqual(range), e => ProcessCompare<T>(e, RangeOperator.LessThanOrEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.Contains(range), e => ProcessCompare<T>(e, RangeOperator.Contains));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.Contains(value), e => ProcessCompare<T>(e, RangeOperator.Contains));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.ContainedBy(range), e => ProcessCompare<T>(e, RangeOperator.ContainedBy));
            ExpressionProcessor.RegisterCustomMethodCall(() => value.ContainedBy(range), (e) => ProcessCompare<T>(e, RangeOperator.ContainedBy));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.Overlaps(range), e => ProcessCompare<T>(e, RangeOperator.Overlaps));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.StrictlyLeftOf(range), e => ProcessCompare<T>(e, RangeOperator.StrictlyLeftOf));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.StrictlyRightOf(range), e => ProcessCompare<T>(e, RangeOperator.StrictlyRightOf));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.NotExtendLeftOf(range), e => ProcessCompare<T>(e, RangeOperator.NotExtendLeftOf));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.NotExtendRightOf(range), e => ProcessCompare<T>(e, RangeOperator.NotExtendRightOf));
            ExpressionProcessor.RegisterCustomMethodCall(() => range.AdjacentTo(range), e => ProcessCompare<T>(e, RangeOperator.AdjacentTo));
        }
    }
}
