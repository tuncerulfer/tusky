using System;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Tusky.Criterion
{
    public static class RestrictionWrapper
    {
        public static CompareExpression Compare(IProjection projection, object value, string op) =>
            new CompareExpression(projection, value, op);

        public static CompareExpression Compare(IProjection projection, object value, string op, bool inverse) =>
            new CompareExpression(projection, value, op, inverse);

        public static CompareExpression Compare(string propertyName, object value, string op) =>
            new CompareExpression(propertyName, value, op);

        public static CompareExpression Compare(string propertyName, object value, string op, bool inverse) =>
            new CompareExpression(propertyName, value, op, inverse);

        public static ComparePropertyExpression CompareProperty(string leftPropertyName, string rightPropertyName, string op) =>
            new ComparePropertyExpression(leftPropertyName, rightPropertyName, op);

        public static ComparePropertyExpression CompareProperty(IProjection leftProjection, string rightPropertyName, string op) =>
            new ComparePropertyExpression(leftProjection, rightPropertyName, op);

        public static ComparePropertyExpression CompareProperty(IProjection leftProjection, IProjection rightProjection, string op) =>
            new ComparePropertyExpression(leftProjection, rightProjection, op);

        public static ComparePropertyExpression CompareProperty(string leftPropertyName, IProjection rightProjection, string op) =>
            new ComparePropertyExpression(leftPropertyName, rightProjection, op);

        public static ICriterion ProcessCompare<T>(MethodCallExpression expression, string op) => ProcessCompare<T>(expression, op, null);

        public static ICriterion ProcessCompare<T>(MethodCallExpression expression, string op, Func<object, object> normalizeValue)
        {
            var leftExpression = expression.Object;
            var rightExpression = expression.Arguments[0];

            if (leftExpression == null)
            {
                leftExpression = expression.Arguments[0];
                rightExpression = expression.Arguments[1];
            }

            var leftProjectionInfo = ExpressionProcessor.FindMemberProjection(leftExpression);
            var rightProjectionInfo = ExpressionProcessor.FindMemberProjection(rightExpression);

            var rightProjection = rightProjectionInfo.AsProjection();
            if (rightProjection is ConstantProjection)
            {
                var value = ExpressionProcessor.FindValue(rightExpression);
                value = (normalizeValue == null) ? value : normalizeValue(value);
                return leftProjectionInfo.CreateCriterion(
                    (propertyName) => Compare(propertyName, value, op),
                    (projection) => Compare(projection, value, op));
            }

            var leftProjection = leftProjectionInfo.AsProjection();
            if (leftProjection is ConstantProjection)
            {
                var value = ExpressionProcessor.FindValue(leftExpression);
                value = (normalizeValue == null) ? value : normalizeValue(value);
                return rightProjectionInfo.CreateCriterion(
                    (propertyName) => Compare(propertyName, value, op, true),
                    (projection) => Compare(projection, value, op, true));
            }

            return leftProjectionInfo.CreateCriterion(
                rightProjectionInfo,
                (propertyName, otherPropertyName) => CompareProperty(propertyName, otherPropertyName, op),
                (propertyName, otherProjection) => CompareProperty(propertyName, otherProjection, op),
                (projection, otherPropertyName) => CompareProperty(projection, otherPropertyName, op),
                (projection, otherProjection) => CompareProperty(projection, otherProjection, op));
        }
    }
}
