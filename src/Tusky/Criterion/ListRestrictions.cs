using System.Collections.Generic;
using NHibernate.Impl;

namespace Tusky.Criterion
{
    public class ListRestrictions : ArrayRestrictions
    {
        public static new void RegisterHooks() => RegisterHooks<int>();

        private static void RegisterHooks<T>()
        {
            var value = default(T);
            var list = new List<T>() as IList<T>;
            ExpressionProcessor.RegisterCustomMethodCall(() => list.Equal(list), e => ProcessCompare<T>(e, ArrayOperator.Equal));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.NotEqual(list), e => ProcessCompare<T>(e, ArrayOperator.NotEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.GreaterThan(list), e => ProcessCompare<T>(e, ArrayOperator.GreaterThan));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.LessThan(list), e => ProcessCompare<T>(e, ArrayOperator.LessThan));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.GreaterThanOrEqual(list), e => ProcessCompare<T>(e, ArrayOperator.GreaterThanOrEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.LessThanOrEqual(list), e => ProcessCompare<T>(e, ArrayOperator.LessThanOrEqual));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.Contains(list), e => ProcessCompare<T>(e, ArrayOperator.Contains));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.Contains(value), e => ProcessCompare<T>(e, ArrayOperator.Contains, (v) => NormalizeValue<T>(v)));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.ContainedBy(list), e => ProcessCompare<T>(e, ArrayOperator.ContainedBy));
            ExpressionProcessor.RegisterCustomMethodCall(() => value.ContainedBy(list), e => ProcessCompare<T>(e, ArrayOperator.ContainedBy, (v) => NormalizeValue<T>(v)));
            ExpressionProcessor.RegisterCustomMethodCall(() => list.Overlaps(list), e => ProcessCompare<T>(e, ArrayOperator.Overlaps));
        }

        private static object NormalizeValue<T>(object value) => (value is IList<T>) ? value : new List<T>() { (T)value };
    }
}
