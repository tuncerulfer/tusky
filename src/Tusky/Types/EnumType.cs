using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using Npgsql;

namespace Tusky.Types
{
    [Serializable]
    public class EnumType<TEnum> : ImmutableType, IParameterizedType where TEnum : struct, Enum
    {
        public override SqlType[] SqlTypes => new SqlType[]
        {
            new SqlType(DbType.Object)
        };

        public override Type ReturnedType => typeof(TEnum);

        public override object Get(object value, ISessionImplementor session, object owner) => value;

        public override void Set(DbParameter parameter, object value, ISessionImplementor session) => parameter.Value = value;

        public void SetParameterValues(IDictionary<string, string> parameters)
        {
            string name = null;
            INpgsqlNameTranslator translator = null;

            if (parameters != null)
            {
                parameters.TryGetValue("name", out name);
                parameters.TryGetValue("translator", out var translatorTypeName);

                if (!string.IsNullOrEmpty(translatorTypeName))
                {
                    var translatorType = Type.GetType(translatorTypeName);
                    translator = Activator.CreateInstance(translatorType) as INpgsqlNameTranslator;
                }
            }

            NpgsqlConnection.GlobalTypeMapper.MapEnum<TEnum>(name, translator);
        }
    }
}
