using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tusky.Types;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Impl;
using Expression = System.Linq.Expressions.Expression;

namespace Tusky.Criterion
{
    public static class ProjectionWrapper
    {
        public static IProjection CreateConstantProjection(Expression expression)
        {
            var value = ExpressionProcessor.FindValue(expression);
            return new ConstantProjection(value, TypeUtil.GuessType(value));
        }

        public static IProjection FindMemberProjection(Expression expression)
        {
            var projection = ExpressionProcessor.FindMemberProjection(expression).AsProjection();
            return (projection is ConstantProjection) ? CreateConstantProjection(expression) : projection;
        }

        public static IProjection ProcessOperator(MethodCallExpression methodCallExpression, string op)
        {
            var expressions = new List<Expression>();

            if (methodCallExpression.Object != null)
            {
                expressions.Add(methodCallExpression.Object);
            }

            foreach (var argumentExpression in methodCallExpression.Arguments)
            {
                expressions.Add(argumentExpression);
            }

            var sqlFunction = new VarArgsSQLFunction("(", op, ")");
            var returnType = TypeUtil.GuessType(expressions[0].Type);
            var projections = expressions.Select(e => FindMemberProjection(e)).ToArray();

            return Projections.SqlFunction(sqlFunction, returnType, projections);
        }
    }
}
