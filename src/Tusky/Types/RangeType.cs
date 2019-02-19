using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Tusky.Entities;
using Tusky.SqlTypes;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NodaTime;
using NpgsqlTypes;

namespace Tusky.Types
{
    public abstract class RangeType<T> : ImmutableType, IParameterizedType
    {
        public abstract T MinValue { get; }
        public abstract T MaxValue { get; }

        protected bool _startInclusive = true;
        protected bool _endInclusive = true;

        public bool StartInclusive => _startInclusive;
        public bool EndInclusive => _endInclusive;
        public override Type ReturnedType => typeof(Range<T>);

        public override object Get(object value, ISessionImplementor session, object owner)
        {
            var range = (NpgsqlRange<T>)Import(value);

            if (range.IsEmpty)
            {
                return Range<T>.Empty;
            }

            var lowerBound = range.LowerBound;
            if (range.LowerBoundInfinite)
            {
                lowerBound = MinValue;
            }
            else if (range.LowerBoundIsInclusive != _startInclusive)
            {
                lowerBound = Normalize(lowerBound, _startInclusive);
            }

            var upperBound = range.UpperBound;
            if (range.UpperBoundInfinite)
            {
                upperBound = MaxValue;
            }
            else if (range.UpperBoundIsInclusive != _endInclusive)
            {
                upperBound = Normalize(upperBound, !_endInclusive);
            }

            return new Range<T>(lowerBound, upperBound);
        }

        public override void Set(DbParameter parameter, object value, ISessionImplementor session)
        {
            var obj = (Range<T>)value;

            if (obj.IsEmpty)
            {
                parameter.Value = Export(NpgsqlRange<T>.Empty);
                return;
            }

            var lowerBound = obj.Start;
            var lowerBoundInfitive = lowerBound.Equals(MinValue);
            var lowerBoundInclusive = (!lowerBoundInfitive) ? _startInclusive : false;

            var upperBound = obj.End;
            var upperBoundInfinitive = upperBound.Equals(MaxValue);
            var upperBoundInclusive = (!upperBoundInfinitive) ? _endInclusive : false;

            var range = new NpgsqlRange<T>(
                lowerBound, lowerBoundInclusive, lowerBoundInfitive,
                upperBound, upperBoundInclusive, upperBoundInfinitive);

            parameter.Value = Export(range);
        }

        public void SetParameterValues(IDictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return;
            }

            if (parameters.TryGetValue("start_inclusive", out var startInclusive))
            {
                _startInclusive = bool.Parse(startInclusive);
            }

            if (parameters.TryGetValue("end_inclusive", out var endInclusive))
            {
                _endInclusive = bool.Parse(endInclusive);
            }
        }

        protected virtual object Import(object value)
        {
            return value;
        }

        protected virtual object Export(object value)
        {
            return value;
        }

        protected virtual T Normalize(T bound, bool shiftUp)
        {
            return bound;
        }
    }

    [Serializable]
    public class Int32RangeType : RangeType<int>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.Integer)
        };

        public override int MinValue => int.MinValue;
        public override int MaxValue => int.MaxValue;

        public Int32RangeType() : base() { }

        protected override int Normalize(int bound, bool shiftUp)
        {
            return bound + ((shiftUp) ? 1 : -1);
        }
    }

    [Serializable]
    public class Int64RangeType : RangeType<long>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.Bigint)
        };

        public override long MinValue => long.MinValue;
        public override long MaxValue => long.MaxValue;

        public Int64RangeType() : base() { }

        protected override long Normalize(long bound, bool shiftUp)
        {
            return bound + ((shiftUp) ? 1 : -1);
        }
    }

    [Serializable]
    public class DecimalRangeType : RangeType<decimal>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.Numeric),
        };

        public override decimal MinValue => long.MinValue;
        public override decimal MaxValue => long.MaxValue;

        public DecimalRangeType() : base() { }
    }

    [Serializable]
    public class DateTimeRangeType : RangeType<DateTime>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.Timestamp)
        };

        public override DateTime MinValue => DateTime.MinValue;
        public override DateTime MaxValue => DateTime.MaxValue;

        public DateTimeRangeType() : base()
        {
            _endInclusive = false;
        }
    }

    [Serializable]
    public class DateTimeOffsetRangeType : RangeType<DateTimeOffset>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.TimestampTz)
        };

        public override DateTimeOffset MinValue => DateTimeOffset.MinValue;
        public override DateTimeOffset MaxValue => DateTimeOffset.MaxValue;

        public DateTimeOffsetRangeType() : base()
        {
            _endInclusive = false;
        }
    }

    [Serializable]
    public class LocalDateTimeRangeType : RangeType<LocalDateTime>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.Timestamp)
        };

        public override LocalDateTime MinValue => LocalDate.MinIsoValue.At(LocalTime.MinValue);
        public override LocalDateTime MaxValue => LocalDate.MaxIsoValue.At(LocalTime.MaxValue);

        public LocalDateTimeRangeType() : base()
        {
            _endInclusive = false;
        }

        protected override object Import(object value)
        {
            var range = (NpgsqlRange<Instant>)value;
            return new NpgsqlRange<LocalDateTime>(
                range.LowerBound.InUtc().LocalDateTime, range.LowerBoundIsInclusive, range.LowerBoundInfinite,
                range.UpperBound.InUtc().LocalDateTime, range.UpperBoundIsInclusive, range.UpperBoundInfinite);
        }

        protected override object Export(object value)
        {
            var range = (NpgsqlRange<LocalDateTime>)value;
            return new NpgsqlRange<Instant>(
                range.LowerBound.InUtc().ToInstant(), range.LowerBoundIsInclusive, range.LowerBoundInfinite,
                range.UpperBound.InUtc().ToInstant(), range.UpperBoundIsInclusive, range.UpperBoundInfinite);
        }
    }

    [Serializable]
    public class OffsetDateTimeRangeType : RangeType<OffsetDateTime>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.TimestampTz)
        };

        public override OffsetDateTime MinValue => new OffsetDateTime(LocalDate.MinIsoValue.At(LocalTime.MinValue), Offset.MinValue);
        public override OffsetDateTime MaxValue => new OffsetDateTime(LocalDate.MaxIsoValue.At(LocalTime.MaxValue), Offset.MaxValue);

        public OffsetDateTimeRangeType() : base()
        {
            _endInclusive = false;
        }

        protected override object Import(object value)
        {
            var range = (NpgsqlRange<Instant>)value;
            return new NpgsqlRange<OffsetDateTime>(
                range.LowerBound.InUtc().ToOffsetDateTime(), range.LowerBoundIsInclusive, range.LowerBoundInfinite,
                range.UpperBound.InUtc().ToOffsetDateTime(), range.UpperBoundIsInclusive, range.UpperBoundInfinite);
        }

        protected override object Export(object value)
        {
            var range = (NpgsqlRange<OffsetDateTime>)value;
            return new NpgsqlRange<Instant>(
                range.LowerBound.ToInstant(), range.LowerBoundIsInclusive, range.LowerBoundInfinite,
                range.UpperBound.ToInstant(), range.UpperBoundIsInclusive, range.UpperBoundInfinite);
        }
    }

    [Serializable]
    public class LocalDateRangeType : RangeType<LocalDate>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Range | NpgsqlDbType.Date)
        };

        public override LocalDate MinValue => LocalDate.MinIsoValue;
        public override LocalDate MaxValue => LocalDate.MaxIsoValue;

        public LocalDateRangeType() : base()
        {
            _endInclusive = false;
        }

        protected override LocalDate Normalize(LocalDate bound, bool shiftUp)
        {
            return bound + Period.FromDays(((shiftUp) ? -1 : 0));
        }
    }
}
