using System;
using System.Data;
using Tusky.SqlTypes;
using NHibernate.SqlTypes;
using NpgsqlTypes;

namespace Tusky.Types
{
    [Serializable]
    public class JsonType<T> : JsonbType<T> where T : class
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Json)
        };
    }
}
