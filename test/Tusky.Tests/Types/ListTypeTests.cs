using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

namespace Tusky.Tests.Types
{
    [Collection("DataContext")]
    public class ListTypeTests
    {
        private readonly DataContextFixture _dataContext;

        public ListTypeTests(DataContextFixture fixture) => _dataContext = fixture;

        [Theory]
        [MemberData(nameof(Data))]
        public void TestListPersistance<T>(PropertyInfo property, IList<T> expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new ListModel();
                property.SetValue(model, expected);
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<ListModel>(modelId);
                var actual = property.GetValue(model);
                Assert.Equal(expected, actual);
            }
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                // With values
                new object[]
                {
                    GetProperty((m) => m.Int16ListProperty),
                    new List<short> { 86, -2627, 8077, 15229, -111, 29368 },
                },
                new object[]
                {
                    GetProperty((m) => m.Int32ListProperty),
                    new List<int> { 17805494, -332242808, -2670503, 474911063, 8542384, 198400465 },
                },
                new object[]
                {
                    GetProperty((m) => m.Int64ListProperty),
                    new List<long> { 14522562291015, -580356502, 50334771618750, 198748474918, -428229031930 },
                },
                new object[]
                {
                    GetProperty((m) => m.DecimalListProperty),
                    new List<decimal> { -90.5502667m, 8506948.27m, 11382.56053m, 1.937119899m, 82095.4811m, -194.3378635m },
                },
                new object[]
                {
                    GetProperty((m) => m.SingleListProperty),
                    new List<float> { 55.9820993f, 11685883.69f, -60.7643079f, -175335.5297f, -5.77610155f, 2111.09757f },
                },
                new object[]
                {
                    GetProperty((m) => m.DoubleListProperty),
                    new List<double> { -161.093249230733d, 16483.64091d, 5770307337315.7d, -125.3044157d, 462724.229d, 4201.140437466981789d },
                },
                new object[]
                {
                    GetProperty((m) => m.StringListProperty),
                    new List<string> { "Vestibulum et", "nisi vel", "diam ornare", "ornare non", "sed arcu" },
                },
                new object[]
                {
                    GetProperty((m) => m.BooleanListProperty),
                    new List<bool> { true, true, false, true, false, false, true, true },
                },
                //new object[]
                //{
                //    GetProperty((m) => m.DateTimeListProperty),
                //    new List<DateTime>
                //    {
                //        new DateTime(1981, 01, 15, 19, 44, 05, 123),
                //        new DateTime(1904, 01, 24, 5, 51, 2, 878),
                //        new DateTime(2369, 08, 21, 8, 30, 59, 224),
                //        new DateTime(2015, 09, 24, 23, 2, 17, 309),
                //        new DateTime(2008, 07, 17, 0, 12, 33, 297),
                //        new DateTime(1922, 02, 14, 16, 44, 9, 956),
                //    },
                //},

                // Empty
                new object[]
                {
                    GetProperty((m) => m.Int16ListProperty),
                    new List<short> { },
                },
                new object[]
                {
                    GetProperty((m) => m.Int32ListProperty),
                    new List<int> { },
                },
                new object[]
                {
                    GetProperty((m) => m.Int64ListProperty),
                    new List<long> { },
                },
                new object[]
                {
                    GetProperty((m) => m.DecimalListProperty),
                    new List<decimal> { },
                },
                new object[]
                {
                    GetProperty((m) => m.SingleListProperty),
                    new List<float> { },
                },
                new object[]
                {
                    GetProperty((m) => m.DoubleListProperty),
                    new List<double> { },
                },
                new object[]
                {
                    GetProperty((m) => m.StringListProperty),
                    new List<string> { },
                },
                new object[]
                {
                    GetProperty((m) => m.BooleanListProperty),
                    new List<bool> { },
                },
                //new object[]
                //{
                //    GetProperty((m) => m.DateTimeListProperty),
                //    new List<DateTime> { },
                //},
            };

        private static object GetProperty<T>(Expression<Func<ListModel, IList<T>>> function) =>
            ReflectionUtil.GetProperty(function);
    }

    public class ListModel
    {
        public virtual int Id { get; set; }
        public virtual IList<short> Int16ListProperty { get; set; }
        public virtual IList<int> Int32ListProperty { get; set; }
        public virtual IList<long> Int64ListProperty { get; set; }
        public virtual IList<decimal> DecimalListProperty { get; set; }
        public virtual IList<float> SingleListProperty { get; set; }
        public virtual IList<double> DoubleListProperty { get; set; }
        public virtual IList<string> StringListProperty { get; set; }
        public virtual IList<bool> BooleanListProperty { get; set; }
        public virtual IList<DateTime> DateListProperty { get; set; }
        public virtual IList<DateTime> DateTimeListProperty { get; set; }
        public virtual IList<DateTimeOffset> DateTimeOffsetListProperty { get; set; }
    }
}
