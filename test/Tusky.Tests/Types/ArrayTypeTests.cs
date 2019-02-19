using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

namespace Tusky.Tests.Types
{
    [Collection("DataContext")]
    public class ArrayTypeTests
    {
        private readonly DataContextFixture _dataContext;

        public ArrayTypeTests(DataContextFixture fixture) => _dataContext = fixture;

        [Theory]
        [MemberData(nameof(SingleRankData))]
        public void TestSingleRankArrayPersistance(PropertyInfo property, Array expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new ArraySingleRankModel();
                property.SetValue(model, expected);
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<ArraySingleRankModel>(modelId);
                var actual = property.GetValue(model);
                Assert.Equal(expected, actual);
            }
        }

        public static IEnumerable<object[]> SingleRankData =>
            new List<object[]>
            {
                // With values
                new object[]
                {
                    GetPropertyForSingle((m) => m.Int16ArrayProperty),
                    new short[] { 86, -2627, 8077, 15229, -111, 29368 },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.Int32ArrayProperty),
                    new int[] { 17805494, -332242808, -2670503, 474911063, 8542384, 198400465 },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.Int64ArrayProperty),
                    new long[] { 14522562291015, -580356502, 50334771618750, 198748474918, -428229031930 },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.DecimalArrayProperty),
                    new decimal[] { -90.5502667m, 8506948.27m, 11382.56053m, 1.937119899m, 82095.4811m, -194.3378635m },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.SingleArrayProperty),
                    new float[] { 55.9820993f, 11685883.69f, -60.7643079f, -175335.5297f, -5.77610155f, 2111.09757f },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.DoubleArrayProperty),
                    new double[] { -161.093249230733d, 16483.64091d, 5770307337315.7d, -125.3044157d, 462724.229d, 4201.140437466981789d },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.StringArrayProperty),
                    new string[] { "Vestibulum et", "nisi vel", "diam ornare", "ornare non", "sed arcu" },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.BooleanArrayProperty),
                    new bool[] { true, true, false, true, false, false, true, true },
                },
                //new object[]
                //{
                //    GetProperty((m) => m.DateTimeArrayProperty),
                //    new DateTime[] {
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
                    GetPropertyForSingle((m) => m.Int16ArrayProperty),
                    new short[] { },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.Int32ArrayProperty),
                    new int[] { },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.Int64ArrayProperty),
                    new long[] { },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.DecimalArrayProperty),
                    new decimal[] { },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.SingleArrayProperty),
                    new float[] { },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.DoubleArrayProperty),
                    new double[] { },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.StringArrayProperty),
                    new string[] { },
                },
                new object[]
                {
                    GetPropertyForSingle((m) => m.BooleanArrayProperty),
                    new bool[] { },
                },
                //new object[]
                //{
                //    GetProperty((m) => m.DateTimeArrayProperty),
                //    new DateTime[] { },
                //},
            };

        private static object GetPropertyForSingle(Expression<Func<ArraySingleRankModel, Array>> function) =>
            ReflectionUtil.GetProperty(function);

        [Theory]
        [MemberData(nameof(MultipleRankData))]
        public void TestMultipleRankArrayPersistance(PropertyInfo property, Array expected)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new ArrayMultipleRankModel();
                property.SetValue(model, expected);
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<ArrayMultipleRankModel>(modelId);
                var actual = property.GetValue(model);
                Assert.Equal(expected, actual);
            }
        }

        public static IEnumerable<object[]> MultipleRankData =>
            new List<object[]>
            {
                // With values
                new object[]
                {
                    GetPropertyForMultiple((m) => m.Int16ArrayProperty),
                    new short[,] { { 86, -2627 }, { 8077, 15229 }, { -111, 29368 } },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.Int32ArrayProperty),
                    new int[,] { { 17805494, -332242808 }, { -2670503, 474911063 }, { 8542384, 198400465 } },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.Int64ArrayProperty),
                    new long[,] { { 14522562291015, -580356502 }, { 50334771618750, 198748474918 }, { -428229031930, 2341641389613 } },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.DecimalArrayProperty),
                    new decimal[,] { { -90.5502667m, 8506948.27m, 11382.56053m }, { 1.937119899m, 82095.4811m, -194.3378635m } },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.SingleArrayProperty),
                    new float[,] { { 55.9820993f, 11685883.69f }, { -60.7643079f, -175335.5297f }, { -5.77610155f, 2111.09757f } },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.DoubleArrayProperty),
                    new double[,] { { -161.093249230733d, 16483.64091d, 5770307337315.7d }, { -125.3044157d, 462724.229d, 4201.140437466981789d } },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.StringArrayProperty),
                    new string[,]
                    {
                        { "Vestibulum et", "nisi vel", "diam ornare", "ornare non" },
                        { "sed arcu.",  "In leo leo", "porta in magna", "at" },
                    },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.BooleanArrayProperty),
                    new bool[,] { { true, true }, { false, true }, { false, false }, { true, true }, { false, true } },
                },
                //new object[]
                //{
                //    GetProperty((m) => m.DateTimeArrayProperty),
                //    new DateTime[,]
                //    {
                //        {
                //            new DateTime(1981, 01, 15, 19, 44, 05, 123),
                //            new DateTime(1904, 01, 24, 5, 51, 2, 878),
                //            new DateTime(2369, 08, 21, 8, 30, 59, 224),
                //        },
                //        {
                //            new DateTime(2015, 09, 24, 23, 2, 17, 309),
                //            new DateTime(2008, 07, 17, 0, 12, 33, 297),
                //            new DateTime(1922, 02, 14, 16, 44, 9, 956),
                //        }
                //    },
                //},

                // Empty
                new object[]
                {
                    GetPropertyForMultiple((m) => m.Int16ArrayProperty),
                    new short[0,0] { },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.Int32ArrayProperty),
                    new int[,] { },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.Int64ArrayProperty),
                    new long[,] { },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.DecimalArrayProperty),
                    new decimal[,] { },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.SingleArrayProperty),
                    new float[,] { },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.DoubleArrayProperty),
                    new double[,] { },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.StringArrayProperty),
                    new string[,] { },
                },
                new object[]
                {
                    GetPropertyForMultiple((m) => m.BooleanArrayProperty),
                    new bool[,] { },
                },
                //new object[]
                //{
                //    GetProperty((m) => m.DateTimeArrayProperty),
                //    new DateTime[,] { },
                //},
            };

        private static object GetPropertyForMultiple(Expression<Func<ArrayMultipleRankModel, Array>> function) =>
            ReflectionUtil.GetProperty(function);
    }

    public class ArraySingleRankModel
    {
        public virtual int Id { get; set; }
        public virtual short[] Int16ArrayProperty { get; set; }
        public virtual int[] Int32ArrayProperty { get; set; }
        public virtual long[] Int64ArrayProperty { get; set; }
        public virtual decimal[] DecimalArrayProperty { get; set; }
        public virtual float[] SingleArrayProperty { get; set; }
        public virtual double[] DoubleArrayProperty { get; set; }
        public virtual string[] StringArrayProperty { get; set; }
        public virtual bool[] BooleanArrayProperty { get; set; }
        public virtual DateTime[] DateArrayProperty { get; set; }
        public virtual DateTime[] DateTimeArrayProperty { get; set; }
        public virtual DateTimeOffset[] DateTimeOffsetArrayProperty { get; set; }
    }

    public class ArrayMultipleRankModel
    {
        public virtual int Id { get; set; }
        public virtual short[,] Int16ArrayProperty { get; set; }
        public virtual int[,] Int32ArrayProperty { get; set; }
        public virtual long[,] Int64ArrayProperty { get; set; }
        public virtual decimal[,] DecimalArrayProperty { get; set; }
        public virtual float[,] SingleArrayProperty { get; set; }
        public virtual double[,] DoubleArrayProperty { get; set; }
        public virtual string[,] StringArrayProperty { get; set; }
        public virtual bool[,] BooleanArrayProperty { get; set; }
        public virtual DateTime[,] DateArrayProperty { get; set; }
        public virtual DateTime[,] DateTimeArrayProperty { get; set; }
        public virtual DateTimeOffset[,] DateTimeOffsetArrayProperty { get; set; }
    }
}
