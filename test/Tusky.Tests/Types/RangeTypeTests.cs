using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Tusky.Entities;
using NodaTime;
using Xunit;

namespace Tusky.Tests.Types
{
    [Collection("DataContext")]
    public class RangeTypeTests
    {
        private readonly DataContextFixture _dataContext;

        public RangeTypeTests(DataContextFixture fixture) => _dataContext = fixture;

        [Theory]
        [MemberData(nameof(Data))]
        public void TestRangePersistance<T>(PropertyInfo property, T start, T end, Range<T> expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new RangeModel();
                property.SetValue(model, new Range<T>(start, end));
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<RangeModel>(modelId);
                var actual = property.GetValue(model);
                Assert.Equal(expected, actual);
            }
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                // Int32RangeType
                new object[] { GetProperty((m) => m.Int32RangeProperty), 8064, 29157, new Range<int>(8064, 29157) },
                new object[] { GetProperty((m) => m.Int32RangeProperty), 10642, int.MaxValue, new Range<int>(10642, int.MaxValue) },
                new object[] { GetProperty((m) => m.Int32RangeProperty), int.MinValue, 12576, new Range<int>(int.MinValue, 12576) },
                new object[] { GetProperty((m) => m.Int32RangeProperty), int.MinValue, int.MaxValue, new Range<int>(int.MinValue, int.MaxValue) },
                new object[] { GetProperty((m) => m.Int32RangeProperty), default(int), default(int), Range<int>.Empty },

                // Int64RangeType
                new object[] { GetProperty((m) => m.Int64RangeProperty), 86705231L, 215791820L, new Range<long>(86705231, 215791820) },
                new object[] { GetProperty((m) => m.Int64RangeProperty), 728670523170L, long.MaxValue, new Range<long>(728670523170, long.MaxValue) },
                new object[] { GetProperty((m) => m.Int64RangeProperty), long.MinValue, 57935215918L, new Range<long>(long.MinValue, 57935215918) },
                new object[] { GetProperty((m) => m.Int64RangeProperty), long.MinValue, long.MaxValue, new Range<long>(long.MinValue, long.MaxValue) },
                new object[] { GetProperty((m) => m.Int64RangeProperty), default(long), default(long), Range<long>.Empty },

                // DecimalRangeType
                new object[] { GetProperty((m) => m.DecimalRangeProperty), 1898.763273m, 8046.383414m, new Range<decimal>(1898.763273m, 8046.383414m) },
                new object[] { GetProperty((m) => m.DecimalRangeProperty), 521342.61m, decimal.MaxValue, new Range<decimal>(521342.61m, decimal.MaxValue) },
                new object[] { GetProperty((m) => m.DecimalRangeProperty), decimal.MinValue, 4.84616852134m, new Range<decimal>(decimal.MinValue, 4.84616852134m) },
                new object[] { GetProperty((m) => m.DecimalRangeProperty), decimal.MinValue, decimal.MaxValue, new Range<decimal>(decimal.MinValue, decimal.MaxValue) },
                new object[] { GetProperty((m) => m.DecimalRangeProperty), default(decimal), default(decimal), Range<decimal>.Empty },

                // LocalDateTimeRangeType
                new object[]
                {
                    GetProperty((m) => m.TimestampRangeProperty),
                    new LocalDateTime(2018, 1, 1, 15, 8, 3),
                    new LocalDateTime(2018, 3, 14, 0, 36, 56),
                    new Range<LocalDateTime>(
                        new LocalDateTime(2018, 1, 1, 15, 8, 3),
                        new LocalDateTime(2018, 3, 14, 0, 36, 56))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampRangeProperty),
                    new LocalDateTime(2018, 5, 7, 8, 30, 0),
                    LocalDate.MaxIsoValue.At(LocalTime.MaxValue),
                    new Range<LocalDateTime>(
                        new LocalDateTime(2018, 5, 7, 8, 30, 0),
                        LocalDate.MaxIsoValue.At(LocalTime.MaxValue))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampRangeProperty),
                    LocalDate.MinIsoValue.At(LocalTime.MinValue),
                    new LocalDateTime(2018, 9, 2, 23, 12, 55),
                    new Range<LocalDateTime>(
                        LocalDate.MinIsoValue.At(LocalTime.MinValue),
                        new LocalDateTime(2018, 9, 2, 23, 12, 55))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampRangeProperty),
                    LocalDate.MinIsoValue.At(LocalTime.MinValue),
                    LocalDate.MaxIsoValue.At(LocalTime.MaxValue),
                    new Range<LocalDateTime>(
                        LocalDate.MinIsoValue.At(LocalTime.MinValue),
                        LocalDate.MaxIsoValue.At(LocalTime.MaxValue))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampRangeProperty),
                    default(LocalDateTime), default(LocalDateTime),
                    Range<LocalDateTime>.Empty
                },

                // OffsetDateTimeRangeType
                new object[]
                {
                    GetProperty((m) => m.TimestampTzOneRangeProperty),
                    new OffsetDateTime(new LocalDateTime(2018, 1, 1, 15, 8, 3), Offset.FromHours(4)),
                    new OffsetDateTime(new LocalDateTime(2018, 3, 14, 0, 36, 56), Offset.FromHours(4)),
                    new Range<OffsetDateTime>(
                        new OffsetDateTime(new LocalDateTime(2018, 1, 1, 11, 8, 3), Offset.Zero),
                        new OffsetDateTime(new LocalDateTime(2018, 3, 13, 20, 36, 56), Offset.Zero))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampTzOneRangeProperty),
                    new OffsetDateTime(new LocalDateTime(2018, 5, 7, 8, 30, 0), Offset.FromHoursAndMinutes(1, 30)),
                    new OffsetDateTime(LocalDate.MaxIsoValue.At(LocalTime.MaxValue), Offset.MaxValue),
                    new Range<OffsetDateTime>(
                        new OffsetDateTime(new LocalDateTime(2018, 5, 7, 7, 00, 0), Offset.Zero),
                        new OffsetDateTime(LocalDate.MaxIsoValue.At(LocalTime.MaxValue), Offset.MaxValue))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampTzOneRangeProperty),
                    new OffsetDateTime(LocalDate.MinIsoValue.At(LocalTime.MinValue), Offset.MinValue),
                    new OffsetDateTime(new LocalDateTime(2018, 9, 2, 23, 12, 55), Offset.FromHours(-2)),
                    new Range<OffsetDateTime>(
                        new OffsetDateTime(LocalDate.MinIsoValue.At(LocalTime.MinValue), Offset.MinValue),
                        new OffsetDateTime(new LocalDateTime(2018, 9, 3, 01, 12, 55), Offset.Zero))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampTzOneRangeProperty),
                    new OffsetDateTime(LocalDate.MinIsoValue.At(LocalTime.MinValue), Offset.MinValue),
                    new OffsetDateTime(LocalDate.MaxIsoValue.At(LocalTime.MaxValue), Offset.MaxValue),
                    new Range<OffsetDateTime>(
                        new OffsetDateTime(LocalDate.MinIsoValue.At(LocalTime.MinValue), Offset.MinValue),
                        new OffsetDateTime(LocalDate.MaxIsoValue.At(LocalTime.MaxValue), Offset.MaxValue))
                },
                new object[]
                {
                    GetProperty((m) => m.TimestampTzOneRangeProperty),
                    default(OffsetDateTime), default(OffsetDateTime),
                    Range<OffsetDateTime>.Empty
                },

                // LocalDateRangeType
                new object[]
                {
                    GetProperty((m) => m.DateRangeProperty),
                    new LocalDate(2018, 1, 1), new LocalDate(2018, 3, 14),
                    new Range<LocalDate>(new LocalDate(2018, 1, 1), new LocalDate(2018, 3, 14))
                },
                new object[]
                {
                    GetProperty((m) => m.DateRangeProperty),
                    new LocalDate(2018, 5, 7), LocalDate.MaxIsoValue,
                    new Range<LocalDate>(new LocalDate(2018, 5, 7), LocalDate.MaxIsoValue)
                },
                new object[]
                {
                    GetProperty((m) => m.DateRangeProperty),
                    LocalDate.MinIsoValue, new LocalDate(2018, 9, 2),
                    new Range<LocalDate>(LocalDate.MinIsoValue, new LocalDate(2018, 9, 2))
                },
                new object[]
                {
                    GetProperty((m) => m.DateRangeProperty),
                    LocalDate.MinIsoValue, LocalDate.MaxIsoValue,
                    new Range<LocalDate>(LocalDate.MinIsoValue, LocalDate.MaxIsoValue)
                },
                new object[]
                {
                    GetProperty((m) => m.DateRangeProperty),
                    default(LocalDate), default(LocalDate),
                    Range<LocalDate>.Empty
                },
            };

        private static object GetProperty<T>(Expression<Func<RangeModel, Range<T>>> function) =>
            ReflectionUtil.GetProperty(function);
    }

    public class RangeModel
    {
        public virtual int Id { get; set; }
        public virtual Range<int> Int32RangeProperty { get; set; }
        public virtual Range<long> Int64RangeProperty { get; set; }
        public virtual Range<decimal> DecimalRangeProperty { get; set; }
        public virtual Range<LocalDate> DateRangeProperty { get; set; }
        public virtual Range<LocalDateTime> TimestampRangeProperty { get; set; }
        public virtual Range<OffsetDateTime> TimestampTzOneRangeProperty { get; set; }
        public virtual Range<ZonedDateTime> TimestampTzTwoRangeProperty { get; set; }
    }
}
