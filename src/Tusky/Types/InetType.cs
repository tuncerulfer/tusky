using System;
using System.Data;
using System.Data.Common;
using System.Net;
using Tusky.SqlTypes;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NpgsqlTypes;

namespace Tusky.Types
{
    [Serializable]
    public class InetType : MutableType
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Inet)
        };

        public override Type ReturnedType => typeof(IPAddress);

        public override object Copy(object value) => IPAddress.Parse(value.ToString());

        public override object Get(object value, ISessionImplementor session, object owner) => value;

        public override void Set(DbParameter parameter, object value, ISessionImplementor session) => parameter.Value = value;
    }
}
