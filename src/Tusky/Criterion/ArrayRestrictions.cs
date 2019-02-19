using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Tusky.Criterion
{
    public class ArrayRestrictions
    {
        internal ArrayRestrictions() { }

        public static AbstractCriterion Equal(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.Equal);

        public static AbstractCriterion Equal(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.Equal);

        public static AbstractCriterion NotEqual(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.NotEqual);

        public static AbstractCriterion NotEqual(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.NotEqual);

        public static AbstractCriterion GreaterThan(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.GreaterThan);

        public static AbstractCriterion GreaterThan(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.GreaterThan);

        public static AbstractCriterion LessThan(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.LessThan);

        public static AbstractCriterion LessThan(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.LessThan);

        public static AbstractCriterion GreaterThanOrEqual(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqual(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.GreaterThanOrEqual);

        public static AbstractCriterion LessThanOrEqual(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqual(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.LessThanOrEqual);

        public static AbstractCriterion Contains(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.Contains);

        public static AbstractCriterion Contains(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.Contains);

        public static AbstractCriterion ContainedBy(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.ContainedBy);

        public static AbstractCriterion ContainedBy(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.ContainedBy);

        public static AbstractCriterion Overlaps(string propertyName, object value) =>
            RestrictionWrapper.Compare(propertyName, value, ArrayOperator.Overlaps);

        public static AbstractCriterion Overlaps(IProjection projection, object value) =>
            RestrictionWrapper.Compare(projection, value, ArrayOperator.Overlaps);

        public static AbstractCriterion EqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.Equal);

        public static AbstractCriterion EqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.Equal);

        public static AbstractCriterion EqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.Equal);

        public static AbstractCriterion EqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.Equal);

        public static AbstractCriterion NotEqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.NotEqual);

        public static AbstractCriterion NotEqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.NotEqual);

        public static AbstractCriterion NotEqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.NotEqual);

        public static AbstractCriterion NotEqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.NotEqual);

        public static AbstractCriterion GreaterThanProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.GreaterThan);

        public static AbstractCriterion GreaterThanProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.GreaterThan);

        public static AbstractCriterion GreaterThanProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.GreaterThan);

        public static AbstractCriterion GreaterThanProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.GreaterThan);

        public static AbstractCriterion LessThanProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.LessThan);

        public static AbstractCriterion LessThanProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.LessThan);

        public static AbstractCriterion LessThanProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.LessThan);

        public static AbstractCriterion LessThanProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.LessThan);

        public static AbstractCriterion GreaterThanOrEqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.GreaterThanOrEqual);

        public static AbstractCriterion GreaterThanOrEqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.GreaterThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.LessThanOrEqual);

        public static AbstractCriterion LessThanOrEqualProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.LessThanOrEqual);

        public static AbstractCriterion ContainsProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.Contains);

        public static AbstractCriterion ContainsProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.Contains);

        public static AbstractCriterion ContainsProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.Contains);

        public static AbstractCriterion ContainsProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.Contains);

        public static AbstractCriterion ContainedByProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.ContainedBy);

        public static AbstractCriterion ContainedByProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.ContainedBy);

        public static AbstractCriterion ContainedByProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.ContainedBy);

        public static AbstractCriterion ContainedByProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.ContainedBy);

        public static AbstractCriterion OverlapsProperty(string leftPropertyName, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightPropertyName, ArrayOperator.Overlaps);

        public static AbstractCriterion OverlapsProperty(IProjection leftProjection, string rightPropertyName) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightPropertyName, ArrayOperator.Overlaps);

        public static AbstractCriterion OverlapsProperty(IProjection leftProjection, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftProjection, rightProjection, ArrayOperator.Overlaps);

        public static AbstractCriterion OverlapsProperty(string leftPropertyName, IProjection rightProjection) =>
            RestrictionWrapper.CompareProperty(leftPropertyName, rightProjection, ArrayOperator.Overlaps);

        public static void RegisterHooks() => RegisterHooks<int>();

        protected static ICriterion ProcessCompare<T>(MethodCallExpression expression, string op) =>
            RestrictionWrapper.ProcessCompare<T>(expression, op);

        protected static ICriterion ProcessCompare<T>(MethodCallExpression expression, string op, Func<object, object> normalizeValue) =>
            RestrictionWrapper.ProcessCompare<T>(expression, op, normalizeValue);

        private static void RegisterHooks<T>()
        {
            var value = default(T);
            var array = new T[0] as Array;
            ExpressionProcessor.RegisterCustomMethodCall(() => array.Equal(array), e => ProcessCompare<T>(e, ArrayOperator.Equal));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.NotEqual(array), e => ProcessCompare<T>(e, ArrayOperator.NotEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.GreaterThan(array), e => ProcessCompare<T>(e, ArrayOperator.GreaterThan));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.LessThan(array), e => ProcessCompare<T>(e, ArrayOperator.LessThan));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.GreaterThanOrEqual(array), e => ProcessCompare<T>(e, ArrayOperator.GreaterThanOrEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.LessThanOrEqual(array), e => ProcessCompare<T>(e, ArrayOperator.LessThanOrEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.Contains(array), e => ProcessCompare<T>(e, ArrayOperator.Contains));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.Contains(value), e => ProcessCompare<T>(e, ArrayOperator.Contains, (v) => NormalizeValue<T>(v)));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.ContainedBy(array), e => ProcessCompare<T>(e, ArrayOperator.ContainedBy));
            ExpressionProcessor.RegisterCustomMethodCall(() => value.ContainedBy(array), e => ProcessCompare<T>(e, ArrayOperator.ContainedBy, (v) => NormalizeValue<T>(v)));
            ExpressionProcessor.RegisterCustomMethodCall(() => array.Overlaps(array), e => ProcessCompare<T>(e, ArrayOperator.Overlaps));
        }

        private static object NormalizeValue<T>(object value) => (value is Array) ? value : new T[] { (T)value };
    }
}
