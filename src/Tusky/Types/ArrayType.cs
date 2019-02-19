using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Tusky.SqlTypes;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NpgsqlTypes;

namespace Tusky.Types
{
    public abstract class ArrayType<T> : MutableType, IParameterizedType
    {
        protected int _rank;
        protected Type _elementType;

        public int Rank => _rank;
        public Type ElementType => _elementType;

        public override Type ReturnedType => typeof(Array);

        public ArrayType()
        {
            _rank = 1;
            _elementType = typeof(T);
        }

        public override object Copy(object value)
        {
            return ((Array)value).Clone();
        }

        public override object Get(object value, ISessionImplementor session, object owner)
        {
            var array = (Array)value;
            var elementType = array.GetType().GetElementType();

            if (array.Length == 0 && (array.Rank != _rank || elementType != _elementType))
            {
                array = Array.CreateInstance(_elementType, new int[_rank]);
            }

            return array;
        }

        public override void Set(DbParameter parameter, object value, ISessionImplementor session)
        {
            parameter.Value = value;
        }

        public void SetParameterValues(IDictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return;
            }

            if (parameters.TryGetValue("rank", out var rank))
            {
                _rank = Convert.ToInt32(rank);
            }
        }
    }

    [Serializable]
    public class Int16ArrayType : ArrayType<short>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Smallint)
        };

        public Int16ArrayType() : base() { }
    }

    [Serializable]
    public class Int32ArrayType : ArrayType<int>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Integer)
        };

        public Int32ArrayType() : base() { }
    }

    [Serializable]
    public class Int64ArrayType : ArrayType<long>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Bigint)
        };

        public Int64ArrayType() : base() { }
    }

    [Serializable]
    public class DecimalArrayType : ArrayType<decimal>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Numeric)
        };

        public DecimalArrayType() : base() { }
    }

    [Serializable]
    public class SingleArrayType : ArrayType<float>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Real)
        };

        public SingleArrayType() : base() { }
    }

    [Serializable]
    public class DoubleArrayType : ArrayType<double>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Double)
        };

        public DoubleArrayType() : base() { }
    }

    [Serializable]
    public class StringArrayType : ArrayType<string>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Varchar)
        };

        public StringArrayType() : base() { }
    }

    [Serializable]
    public class BooleanArrayType : ArrayType<bool>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Boolean)
        };

        public BooleanArrayType() : base() { }
    }

    [Serializable]
    public class DateTimeArrayType : ArrayType<DateTime>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.Timestamp)
        };

        public DateTimeArrayType() : base() { }
    }

    [Serializable]
    public class DateTimeOffsetArrayType : ArrayType<DateTimeOffset>
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new NpgsqlSqlType(DbType.Object, NpgsqlDbType.Array | NpgsqlDbType.TimestampTz)
        };

        public DateTimeOffsetArrayType() : base() { }
    }
}
