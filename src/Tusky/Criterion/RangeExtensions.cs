using Tusky.Entities;

namespace Tusky.Criterion
{
    public static class RangeExtensions
    {
        public static bool Equal<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool NotEqual<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool GreaterThan<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool LessThan<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool GreaterThanOrEqual<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool LessThanOrEqual<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool Contains<T>(this Range<T> @this, T value) =>
            throw new DirectUsageException();

        public static bool Contains<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool ContainedBy<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool ContainedBy<T>(this T @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool Overlaps<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool StrictlyLeftOf<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool StrictlyRightOf<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool NotExtendLeftOf<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool NotExtendRightOf<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static bool AdjacentTo<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static Range<T> Union<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static Range<T> Intersect<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();

        public static Range<T> Diff<T>(this Range<T> @this, Range<T> range) =>
            throw new DirectUsageException();
    }
}
