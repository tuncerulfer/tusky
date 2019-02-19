using System;
using System.Data.Common;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace Tusky.Types
{
    public abstract class ImmutableType : IUserType
    {
        public abstract SqlType[] SqlTypes { get; }
        public abstract Type ReturnedType { get; }

        public abstract object Get(object value, ISessionImplementor session, object owner);

        public abstract void Set(DbParameter parameter, object value, ISessionImplementor session);

        public bool IsMutable => false;

        public virtual object Assemble(object cached, object owner)
        {
            return cached;
        }

        public virtual object DeepCopy(object value)
        {
            return value;
        }

        public virtual object Disassemble(object value)
        {
            return value;
        }

        public new bool Equals(object x, object y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public virtual int GetHashCode(object x)
        {
            if (x == null)
            {
                return 0;
            }

            return x.GetHashCode();
        }

        public virtual object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            if (names.Length != 1)
            {
                throw new InvalidOperationException("Only expecting one column.");
            }

            var value = rs[names[0]];
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            return Get(value, session, owner);
        }

        public virtual void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var parameter = cmd.Parameters[index];

            if (value == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                Set(parameter, value, session);
            }
        }

        public virtual object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
}
