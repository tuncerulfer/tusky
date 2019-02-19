using System;
using System.Collections.Generic;
using System.Linq;
using Tusky.Types;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;

namespace Tusky.Criterion
{
    [Serializable]
    public class CompareExpression : AbstractCriterion
    {
        private readonly IProjection _projection;
        private readonly string _propertyName;
        private readonly object _value;
        private readonly string _op;
        private bool _inverse;

        public string PropertyName => _propertyName;

        public object Value => _value;

        protected virtual string Op => _op;

        public CompareExpression(string propertyName, object value, string op)
        {
            _propertyName = propertyName;
            _value = value;
            _op = op;
        }

        public CompareExpression(string propertyName, object value, string op, bool inverse)
            : this(propertyName, value, op)
        {
            _inverse = inverse;
        }

        protected internal CompareExpression(IProjection projection, object value, string op)
        {
            _projection = projection;
            _value = value;
            _op = op;
        }

        protected internal CompareExpression(IProjection projection, object value, string op, bool inverse)
            : this(projection, value, op)
        {
            _inverse = inverse;
        }

        public override string ToString()
        {
            if (_inverse)
            {
                return _value.ToString() + Op + (_projection ?? (object)_propertyName);
            }
            else
            {
                return (_projection ?? (object)_propertyName) + Op + _value.ToString();
            }
        }

        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            var columnNames = GetColumnNames(_propertyName, _projection, criteriaQuery, criteria, this, _value);

            var typedValue = GetParameterTypedValue(criteria, criteriaQuery);
            var parameters = criteriaQuery.NewQueryParameter(typedValue).ToArray();

            var sqlBuilder = new SqlStringBuilder(4 * columnNames.Length);
            var columnNullness = typedValue.Type.ToColumnNullness(typedValue.Value, criteriaQuery.Factory);

            if (columnNullness.Length != columnNames.Length)
            {
                throw new AssertionFailure("Column nullness length doesn't match number of columns.");
            }

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (i > 0)
                {
                    sqlBuilder.Add(" and ");
                }

                if (columnNullness[i])
                {
                    if (_inverse)
                    {
                        sqlBuilder.Add(parameters[i]).Add(Op).Add(columnNames[i]);
                    }
                    else
                    {
                        sqlBuilder.Add(columnNames[i]).Add(Op).Add(parameters[i]);
                    }
                }
                else
                {
                    sqlBuilder.Add(columnNames[i]).Add(" is null ");
                }
            }

            return sqlBuilder.ToSqlString();
        }

        public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            var typedValues = new List<TypedValue>();

            if (_projection != null)
            {
                typedValues.AddRange(_projection.GetTypedValues(criteria, criteriaQuery));
            }

            typedValues.Add(GetParameterTypedValue(criteria, criteriaQuery));

            return typedValues.ToArray();
        }

        public TypedValue GetParameterTypedValue(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            if (_projection != null)
            {
                return GetTypedValues(criteriaQuery, criteria, _projection, null, _value).Single();
            }

            return new TypedValue(TypeUtil.GuessType(_value), _value);
        }

        public override IProjection[] GetProjections()
        {
            if (_projection != null)
            {
                return new IProjection[] { _projection };
            }

            return null;
        }

        private static SqlString[] GetColumnNames(
            string propertyName, IProjection projection, ICriteriaQuery criteriaQuery,
            ICriteria criteria, ICriterion criterion, object value)
        {
            if (projection == null)
            {
                return GetColumnNamesUsingPropertyName(criteriaQuery, criteria, propertyName, value, criterion);
            }
            else
            {
                return GetColumnNamesUsingProjection(projection, criteriaQuery, criteria);
            }
        }

        private static SqlString[] GetColumnNamesUsingPropertyName(
            ICriteriaQuery criteriaQuery, ICriteria criteria,
            string propertyName, object value, ICriterion critertion)
        {
            var columnNames = criteriaQuery.GetColumnsUsingProjection(criteria, propertyName);
            var propertyType = criteriaQuery.GetTypeUsingProjection(criteria, propertyName);

            var type = propertyType.ReturnedClass;
            var elementTypes = type.GetGenericArguments();
            var elementType = (elementTypes.Length > 0) ? elementTypes[0] : null;

            if (value != null)
            {
                if (!type.IsInstanceOfType(value) && elementType == null)
                {
                    throw new QueryException(string.Format(
                        "Type mismatch in {0}: {1} expected type {2}, actual type {3}",
                        critertion.GetType(), propertyName, type, value.GetType()));
                }
                else if (!type.IsInstanceOfType(value) && !elementType.IsInstanceOfType(value))
                {
                    throw new QueryException(string.Format(
                        "Type mismatch in {0}: {1} expected types {2} or {3}, actual type {4}",
                        critertion.GetType(), propertyName, type, elementType, value.GetType()));
                }
            }

            return Array.ConvertAll(columnNames, (col) => new SqlString(col));
        }

        private static SqlString[] GetColumnNamesUsingProjection(
            IProjection projection, ICriteriaQuery criteriaQuery, ICriteria criteria)
        {
            var sqlString = projection.ToSqlString(criteria, criteriaQuery.GetIndexForAlias(), criteriaQuery);
            return new SqlString[] { SqlStringHelper.RemoveAsAliasesFromSql(sqlString) };
        }

        public static TypedValue[] GetTypedValues(
            ICriteriaQuery criteriaQuery, ICriteria criteria,
            IProjection projection, string propertyName, params object[] values)
        {
            var types = new List<TypedValue>();

            var propertyProjection = projection as IPropertyProjection;
            if (projection == null || propertyProjection != null)
            {
                var propertyPath = propertyProjection != null ? propertyProjection.PropertyName : propertyName;
                foreach (object value in values)
                {
                    var typedValue = criteriaQuery.GetTypedValue(criteria, propertyPath, value);
                    types.Add(typedValue);
                }
            }
            else
            {
                foreach (var value in values)
                {
                    types.Add(new TypedValue(TypeUtil.GuessType(value), value));
                }
            }

            return types.ToArray();
        }
    }
}
