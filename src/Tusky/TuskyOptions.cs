using NHibernate.Cfg;

namespace Tusky
{
    public class TuskyOptions
    {
        public Configuration Configuration { get; set; } = new Configuration();
    }
}
