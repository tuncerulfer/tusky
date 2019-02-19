using System.Collections.Generic;
using NHibernate.Cfg;

namespace Tusky
{
    public static class NHibernateExtensions
    {
        public static Mappings GetMappings(this Configuration configuration)
        {
            return configuration.CreateMappings();
        }

        public static void AddTypeDef<T>(this Mappings mappings, string typeName, IDictionary<string, string> paramMap = null)
        {
            mappings.AddTypeDef(typeName, typeof(T).AssemblyQualifiedName, paramMap ?? new Dictionary<string, string>());
        }
    }
}
