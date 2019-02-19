using System.Data.Common;
using Tusky.SqlTypes;
using NHibernate;
using NHibernate.Driver;
using NHibernate.SqlTypes;
using Npgsql;

namespace Tusky
{
    public class TuskyDriver : NpgsqlDriver
    {
        protected override void InitializeParameter(DbParameter dbParam, string name, SqlType sqlType)
        {
            if (sqlType is NpgsqlSqlType && dbParam is NpgsqlParameter)
            {
                InitializeParameter(dbParam as NpgsqlParameter, name, sqlType as NpgsqlSqlType);
            }
            else
            {
                base.InitializeParameter(dbParam, name, sqlType);
            }
        }

        protected virtual void InitializeParameter(NpgsqlParameter dbParam, string name, NpgsqlSqlType sqlType)
        {
            if (sqlType == null)
            {
                throw new QueryException(string.Format("No type assigned to parameter '{0}'", name));
            }

            dbParam.ParameterName = FormatNameForParameter(name);
            dbParam.DbType = sqlType.DbType;
            dbParam.NpgsqlDbType = sqlType.NpgDbType;
        }
    }
}
