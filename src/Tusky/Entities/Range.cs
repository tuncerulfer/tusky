using System;

namespace Tusky.Entities
{
    public struct Range<T> : IEquatable<Range<T>>
    {
        public T Start { get; set; }
        public T End { get; set; }

        public bool IsEmpty => Start.Equals(default(T)) && End.Equals(default(T));

        public static Range<T> Empty => new Range<T>(default(T), default(T));

        public Range(T start, T end)
        {
            Start = start;
            End = end;
        }

        public override bool Equals(object obj) => (obj is Range<T> && this == (Range<T>)obj);

        public override int GetHashCode() => IsEmpty ? 0 : Start.GetHashCode() + End.GetHashCode();

        public override string ToString() => string.Format("[{0},{1}]", Start.ToString(), End.ToString());

        public bool Equals(Range<T> other) => this == other;

        public static bool operator ==(Range<T> x, Range<T> y) => x.Start.Equals(y.Start) && x.End.Equals(y.End);

        public static bool operator !=(Range<T> x, Range<T> y) => !(x == y);
    }
}
