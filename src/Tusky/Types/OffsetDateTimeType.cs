using System;
using System.Data;
using System.Data.Common;
using Tusky.SqlTypes;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NodaTime;
using NpgsqlTypes;

namespace Tusky.Types
{
    public class OffsetDateTimeType : ImmutableType
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.TimestampTz)
        };

        public override Type ReturnedType => typeof(OffsetDateTime);

        public override object Get(object value, ISessionImplementor session, object owner) => ((Instant)value).InUtc().ToOffsetDateTime();

        public override void Set(DbParameter parameter, object value, ISessionImplementor session) => parameter.Value = value;
    }
}
