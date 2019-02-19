using System.Net;
using System.Net.NetworkInformation;
using Xunit;

namespace Tusky.Tests.Types
{
    [Collection("DataContext")]
    public class NetworkTypesTests
    {
        private readonly DataContextFixture _dataContext;

        public NetworkTypesTests(DataContextFixture fixture) => _dataContext = fixture;

        [Theory]
        [InlineData("175.15.203.166")]
        [InlineData("80af:19cf:97ef:4797:8367:43b:d58d:5bab")]
        public void TestInetPersistance<T>(string ipString)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new InetModel();
                model.IpAddress = IPAddress.Parse(ipString);
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<InetModel>(modelId);
                Assert.Equal(model.IpAddress.ToString(), ipString);
            }
        }

        [Theory]
        [InlineData("1DB5BA171E10")]
        public void TestMacAddrPersistance<T>(string address)
        {
            int modelId;

            using (var session = _dataContext.OpenStatelessSession())
            using (var transaction = session.BeginTransaction())
            {
                var model = new MacAddrModel();
                model.MacAddress = PhysicalAddress.Parse(address);
                modelId = (int)session.Insert(model);
                transaction.Commit();
            }

            using (var session = _dataContext.OpenStatelessSession())
            {
                var model = session.Get<MacAddrModel>(modelId);
                Assert.Equal(address, model.MacAddress.ToString());
            }
        }
    }

    public class InetModel
    {
        public virtual int Id { get; set; }
        public virtual IPAddress IpAddress { get; set; }
    }

    public class MacAddrModel
    {
        public virtual int Id { get; set; }
        public virtual PhysicalAddress MacAddress { get; set; }
    }
}
