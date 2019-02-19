using System;
using System.Data;
using System.Data.Common;
using Force.DeepCloner;
using Tusky.SqlTypes;
using Newtonsoft.Json;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NpgsqlTypes;

namespace Tusky.Types
{
    [Serializable]
    public class JsonbType<T> : MutableType where T : class
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Jsonb)
        };

        public override Type ReturnedType => typeof(T);

        public override object Copy(object value)
        {
            return value.DeepClone();
        }

        public override object Get(object value, ISessionImplementor session, object owner)
        {
            return JsonConvert.DeserializeObject<T>((string)value);
        }

        public override void Set(DbParameter parameter, object value, ISessionImplementor session)
        {
            parameter.Value = JsonConvert.SerializeObject(value);
        }
    }
}
