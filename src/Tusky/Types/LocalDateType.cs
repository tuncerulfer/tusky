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
    public class LocalDateType : ImmutableType
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Date)
        };

        public override Type ReturnedType => typeof(LocalDate);

        public override object Get(object value, ISessionImplementor session, object owner) => value;

        public override void Set(DbParameter parameter, object value, ISessionImplementor session) => parameter.Value = value;
    }
}
