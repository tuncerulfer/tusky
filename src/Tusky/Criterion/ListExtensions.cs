using System.Collections.Generic;

namespace Tusky.Criterion
{
    public static class ListExtensions
    {
        public static bool Equal<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool NotEqual<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool GreaterThan<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool LessThan<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool GreaterThanOrEqual<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool LessThanOrEqual<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool Contains<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool Contains<T>(this IList<T> @this, T item) =>
            throw new DirectUsageException();

        public static bool ContainedBy<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool ContainedBy<T>(this T @this, IList<T> list) =>
            throw new DirectUsageException();

        public static bool Overlaps<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static IList<T> Union<T>(this IList<T> @this, IList<T> list) =>
            throw new DirectUsageException();

        public static IList<T> Union<T>(this IList<T> @this, T item) =>
            throw new DirectUsageException();

        public static IList<T> Union<T>(this T @this, IList<T> list) =>
            throw new DirectUsageException();
    }
}
