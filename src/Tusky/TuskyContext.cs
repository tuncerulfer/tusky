using Microsoft.Extensions.Options;
using NHibernate;

namespace Tusky
{
    public interface ITuskyContext
    {
        ISessionFactory SessionFactory { get; }
    }

    public class TuskyContext : ITuskyContext
    {
        public ISessionFactory SessionFactory { get; }

        public TuskyContext(IOptions<TuskyOptions> optionsAccessor)
        {
            var options = optionsAccessor.Value;
            var configuration = options.Configuration;
            SessionFactory = configuration.BuildSessionFactory();
        }
    }
}
