using System;

namespace Tusky.Criterion
{
    public static class ArrayExtensions
    {
        public static bool Equal(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool NotEqual(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool GreaterThan(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool LessThan(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool GreaterThanOrEqual(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool LessThanOrEqual(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool Contains(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool Contains<T>(this Array @this, T item) =>
            throw new DirectUsageException();

        public static bool ContainedBy(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static bool ContainedBy<T>(this T @this, Array array) =>
            throw new DirectUsageException();

        public static bool Overlaps(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static Array Union(this Array @this, Array array) =>
            throw new DirectUsageException();

        public static Array Union<T>(this Array @this, T item) =>
            throw new DirectUsageException();

        public static Array Union<T>(this T @this, Array array) =>
            throw new DirectUsageException();
    }
}
