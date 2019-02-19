using System;
using System.Data;
using System.Data.Common;
using Tusky.SqlTypes;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NodaTime;
using Npgsql;
using NpgsqlTypes;

namespace Tusky.Types
{
    public class LocalDateTimeType : ImmutableType
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Timestamp)
        };

        public override Type ReturnedType => typeof(LocalDateTime);

        public override object Get(object value, ISessionImplementor session, object owner) => ((Instant)value).InUtc().LocalDateTime;

        public override void Set(DbParameter parameter, object value, ISessionImplementor session) => parameter.Value = value;
    }
}
