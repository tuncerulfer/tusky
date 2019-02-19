using Xunit;

namespace Tusky.Tests.Types
{
    [Collection("DataContext")]
    public class EnumTypeTests
    {
        private readonly DataContextFixture _dataContext;

        public EnumTypeTests(DataContextFixture fixture) => _dataContext = fixture;

        [Theory]
        [InlineData(Mood.Happy)]
        [InlineData(Mood.VeryHappy)]
        public void TestEnumPersistance<T>(Mood mood)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new EnumModel();
                model.CurrentMood = mood;
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<EnumModel>(modelId);
                Assert.Equal(model.CurrentMood, mood);
            }
        }
    }

    public enum Mood
    {
        Sad = 1,
        Happy = 2,
        VeryHappy = 3
    }

    public class EnumModel
    {
        public virtual int Id { get; set; }
        public virtual Mood CurrentMood { get; set; }
    }
}
