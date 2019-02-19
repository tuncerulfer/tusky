using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Tusky.SqlTypes;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NpgsqlTypes;

namespace Tusky.Types
{
    public abstract class ListType<T> : MutableType
    {
        protected Type _elementType;

        public Type ElementType => _elementType;
        public override Type ReturnedType => typeof(IList<T>);

        public ListType()
        {
            _elementType = typeof(T);
        }

        public override object Copy(object value)
        {
            return ((IList<T>)value).ToList();
        }

        public override object Get(object value, ISessionImplementor session, object owner)
        {
            return ((T[])value).ToList();
        }

        public override void Set(DbParameter parameter, object value, ISessionImplementor session)
        {
            parameter.Value = value;
        }
    }

    [Serializable]
    public class Int16ListType : ListType<short>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Smallint)
        };

        public Int16ListType() : base() { }
    }

    [Serializable]
    public class Int32ListType : ListType<int>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Integer)
        };

        public Int32ListType() : base() { }
    }

    [Serializable]
    public class Int64ListType : ListType<long>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Bigint)
        };

        public Int64ListType() : base() { }
    }

    [Serializable]
    public class DecimalListType : ListType<decimal>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Numeric)
        };

        public DecimalListType() : base() { }
    }

    [Serializable]
    public class SingleListType : ListType<float>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Real)
        };

        public SingleListType() : base() { }
    }

    [Serializable]
    public class DoubleListType : ListType<double>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Double)
        };

        public DoubleListType() : base() { }
    }

    [Serializable]
    public class StringListType : ListType<string>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Varchar)
        };

        public StringListType() : base() { }
    }

    [Serializable]
    public class BooleanListType : ListType<bool>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Boolean)
        };

        public BooleanListType() : base() { }
    }

    [Serializable]
    public class DateTimeListType : ListType<DateTime>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Timestamp)
        };

        public DateTimeListType() : base() { }
    }

    [Serializable]
    public class DateTimeOffsetListType : ListType<DateTimeOffset>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.TimestampTz)
        };

        public DateTimeOffsetListType() : base() { }
    }
}
