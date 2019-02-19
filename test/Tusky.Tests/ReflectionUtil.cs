using System;
using System.Linq.Expressions;

namespace Tusky.Tests
{
    public static class ReflectionUtil
    {
        public static object GetProperty<T1, T2>(Expression<Func<T1, T2>> function)
        {
            var memberExpression = function.Body as MemberExpression;
            var objectExpression = memberExpression.Expression;
            var propertyName = memberExpression.Member.Name;
            return objectExpression.Type.GetProperty(propertyName);
        }
    }
}
