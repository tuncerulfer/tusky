using System.Collections.Generic;
using Xunit;

namespace Tusky.Tests.Types
{
    [Collection("DataContext")]
    public class JsonTypeTests
    {
        private readonly DataContextFixture _dataContext;

        public JsonTypeTests(DataContextFixture fixture) => _dataContext = fixture;

        [Theory]
        [MemberData(nameof(Data))]
        public void TestJsonPersistance<T>(SampleObject sampleObject)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new JsonModel();
                model.SampleObjectJson = sampleObject;
                model.SampleObjectJsonb = sampleObject;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<JsonModel>(modelId);
                Assert.Equal(model.SampleObjectJson.Id, sampleObject.Id);
                Assert.Equal(model.SampleObjectJson.Title, sampleObject.Title);
                Assert.Equal(model.SampleObjectJson.Sizes, sampleObject.Sizes);
                Assert.Equal(model.SampleObjectJsonb.Id, sampleObject.Id);
                Assert.Equal(model.SampleObjectJsonb.Title, sampleObject.Title);
                Assert.Equal(model.SampleObjectJsonb.Sizes, sampleObject.Sizes);
            }
        }

        [Theory]
        [InlineData(null)]
        public void TestJsonNullPersistance<T>(SampleObject sampleObject)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new JsonModel();
                model.SampleObjectJson = sampleObject;
                model.SampleObjectJsonb = sampleObject;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<JsonModel>(modelId);
                Assert.Null(model.SampleObjectJson);
                Assert.Null(model.SampleObjectJsonb);
            }
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new SampleObject()
                    {
                        Id = 123,
                        Title = "Sample Title 123",
                        Sizes = new List<int> { 1, 2, 3 }
                    }
                }
            };
    }

    public class JsonModel
    {
        public virtual int Id { get; set; }
        public virtual SampleObject SampleObjectJson { get; set; }
        public virtual SampleObject SampleObjectJsonb { get; set; }
        public virtual int[] SampleArrayJson { get; set; }
        public virtual int[] SampleArrayJsonb { get; set; }
    }

    public class SampleObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<int> Sizes { get; set; }
    }
}
