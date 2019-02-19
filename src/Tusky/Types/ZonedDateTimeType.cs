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
    public class ZonedDateTimeType : ImmutableType
    {
        private readonly IDateTimeZoneProvider _dateTimeZoneProvider;

        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.TimestampTz)
        };

        public override Type ReturnedType => typeof(ZonedDateTime);

        public ZonedDateTimeType() : base()
        {
            _dateTimeZoneProvider = DateTimeZoneProviders.Tzdb;
        }

        public override object Get(object value, ISessionImplementor session, object owner)
        {
            var connection = session.Connection as NpgsqlConnection;
            var zone = _dateTimeZoneProvider[connection.Timezone];
            return ((Instant)value).InZone(zone);
        }

        public override void Set(DbParameter parameter, object value, ISessionImplementor session)
        {
            parameter.Value = value;
        }
    }
}
