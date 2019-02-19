using System.Collections.Generic;
using NodaTime;
using Xunit;

namespace Tusky.Tests.Types
{
    [Collection("DataContext")]
    public class NodaTimeTests
    {
        private readonly DataContextFixture _dataContext;

        public NodaTimeTests(DataContextFixture fixture) => _dataContext = fixture;

        [Theory]
        [MemberData(nameof(InstantData))]
        public void TestInstantTimePersistance(Instant expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.TimestampOneProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(expected, model.TimestampOneProperty);
            }
        }

        public static IEnumerable<object[]> InstantData =>
            new List<object[]>
            {
                new object[] { Instant.FromUtc(2018, 08, 17, 21, 05, 33) }
            };

        [Theory]
        [MemberData(nameof(LocalDateTimeData))]
        public void TestLocalDateTimePersistance(LocalDateTime expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.TimestampTwoProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(expected, model.TimestampTwoProperty);
            }
        }

        public static IEnumerable<object[]> LocalDateTimeData =>
            new List<object[]>
            {
                new object[] { new LocalDateTime(2018, 08, 17, 21, 05, 33) }
            };

        [Theory]
        [MemberData(nameof(LocalDateData))]
        public void TestLocalDatePersistance(LocalDate expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.DateProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(expected, model.DateProperty);
            }
        }

        public static IEnumerable<object[]> LocalDateData =>
            new List<object[]>
            {
                new object[] { new LocalDate(1999, 08, 27) },
                new object[] { null },
            };

        [Theory]
        [MemberData(nameof(LocalTimeData))]
        public void TestLocalTimePersistance(LocalTime expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.TimeProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(expected, model.TimeProperty);
            }
        }

        public static IEnumerable<object[]> LocalTimeData =>
            new List<object[]>
            {
                new object[] { new LocalTime(18, 41, 06) }
            };

        private static readonly DateTimeZone zoneLocal = DateTimeZoneProviders.Tzdb.GetSystemDefault(); // UTC
        private static readonly DateTimeZone zoneLosAngeles = DateTimeZoneProviders.Tzdb["America/Los_Angeles"]; // -08:00
        private static readonly DateTimeZone zoneTashkent = DateTimeZoneProviders.Tzdb["Asia/Tashkent"]; // +05:00

        [Theory]
        [MemberData(nameof(ZonedDateTimeData))]
        public void TestZonedDateTimePersistance(ZonedDateTime expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.TimestampTzOneProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(expected.ToInstant(), model.TimestampTzOneProperty.ToInstant());
            }
        }

        public static IEnumerable<object[]> ZonedDateTimeData =>
            new List<object[]>
            {
                new object[] { new ZonedDateTime(Instant.FromUtc(2018, 08, 17, 21, 05, 33), zoneLosAngeles) },
            };

        [Theory]
        [MemberData(nameof(OffsetDateTimeData))]
        public void TestOffsetDateTimePersistance(OffsetDateTime expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.TimestampTzTwoProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(expected.ToInstant(), model.TimestampTzTwoProperty.ToInstant());
            }
        }

        public static IEnumerable<object[]> OffsetDateTimeData =>
            new List<object[]>
            {
                new object[] { new OffsetDateTime(new LocalDateTime(2018, 08, 17, 21, 05, 33), Offset.FromHours(5)) }
            };

        [Theory]
        [MemberData(nameof(OffsetTimeData))]
        public void TestOffsetTimePersistance(OffsetTime expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.TimeTzProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(expected, model.TimeTzProperty);
            }
        }

        public static IEnumerable<object[]> OffsetTimeData =>
            new List<object[]>
            {
                new object[] { new OffsetTime(new LocalTime(18, 41, 06), Offset.FromHours(-8)) }
            };

        [Theory]
        [MemberData(nameof(PeriodData))]
        public void TestPeriodPersistance(Period expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new NodaTimeModel();
                model.IntervalProperty = expected;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<NodaTimeModel>(modelId);
                Assert.Equal(model.IntervalProperty, expected);
            }
        }

        public static IEnumerable<object[]> PeriodData =>
            new List<object[]>
            {
                new object[] { Period.FromDays(457) },
            };
    }

    public class NodaTimeModel
    {
        public virtual int Id { get; set; }
        public virtual Instant TimestampOneProperty { get; set; }
        public virtual LocalDateTime TimestampTwoProperty { get; set; }
        public virtual LocalDate DateProperty { get; set; }
        public virtual LocalTime TimeProperty { get; set; }
        public virtual ZonedDateTime TimestampTzOneProperty { get; set; }
        public virtual OffsetDateTime TimestampTzTwoProperty { get; set; }
        public virtual OffsetDate DateTzProperty { get; set; }
        public virtual OffsetTime TimeTzProperty { get; set; }
        public virtual Period IntervalProperty { get; set; }
    }
}
