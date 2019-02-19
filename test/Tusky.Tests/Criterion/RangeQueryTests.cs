using System;
using Tusky.Criterion;
using Tusky.Entities;
using Xunit;

namespace Tusky.Tests.Criterion
{
    [Collection("DataContext")]
    public class RangeQueryTests
    {
        private readonly DataContextFixture _dataContext;

        public RangeQueryTests(DataContextFixture fixture) => _dataContext = fixture;

        [Fact]
        public void TestRangeQueryWithConstantValue()
        {
            using (var session = _dataContext.OpenStatelessSession())
            {
                var value = 7.50m;
                var result = session.QueryOver<Campaign>()
                    .Where(c => c.PriceRange.Contains(value))
                    .List();

                Assert.Empty(result);
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var value = 12.66m;
                var result = session.QueryOver<Campaign>()
                    .Where(c => c.PriceRange.Contains(value))
                    .List();

                Assert.Single(result);
                Assert.Equal(-0.10m, result[0].DiscountRate);
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var value = 20.25m;
                var result = session.QueryOver<Campaign>()
                    .Where(c => value.ContainedBy(c.PriceRange))
                    .List();

                Assert.Single(result);
                Assert.Equal(-0.10m, result[0].DiscountRate);
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var range = new Range<decimal>(30.7m, 41.5m);
                var result = session.QueryOver<Campaign>()
                    .Where(c => c.PriceRange.Contains(range))
                    .List();

                Assert.Single(result);
                Assert.Equal(-0.20m, result[0].DiscountRate);
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var value = 333.99m;
                var result = session.QueryOver<Campaign>()
                    .Where(c => c.PriceRange.Contains(value))
                    .List();

                Assert.Single(result);
                Assert.Equal(-0.40m, result[0].DiscountRate);
            }
        }

        [Fact]
        public void TestRangeQueryWithNativeOperator()
        {
            using (var session = _dataContext.OpenStatelessSession())
            {
                var range = new Range<decimal>(51.41m, 99.99m);
                var result = session.QueryOver<Campaign>()
                    .Where(c => c.PriceRange.Equal(range))
                    .List();

                Assert.Single(result);
                Assert.Equal(-0.30m, result[0].DiscountRate);
            }
        }
    }

    public class Campaign
    {
        public virtual int Id { get; set; }
        public virtual Range<decimal> PriceRange { get; set; }
        public virtual decimal DiscountRate { get; set; }
    }
}
