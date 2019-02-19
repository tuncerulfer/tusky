using System;
using System.Data;
using System.Data.Common;
using System.Net.NetworkInformation;
using Tusky.SqlTypes;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NpgsqlTypes;

namespace Tusky.Types
{
    [Serializable]
    public class MacAddrType : MutableType
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.MacAddr)
        };

        public override Type ReturnedType => typeof(PhysicalAddress);

        public override object Copy(object value) => new PhysicalAddress(((PhysicalAddress)value).GetAddressBytes());

        public override object Get(object value, ISessionImplementor session, object owner) => value;

        public override void Set(DbParameter parameter, object value, ISessionImplementor session) => parameter.Value = value;
    }
}
