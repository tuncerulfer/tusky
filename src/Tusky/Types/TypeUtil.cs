using Tusky.Entities;
using NHibernate;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tusky.Types
{
    public static class TypeUtil
    {
        public static IType CreateType<T>(IDictionary<string, string> paramMap = null)
        {
            return new CustomType(typeof(T), paramMap);
        }

        public static IType GuessType(object value)
        {
            return NHibernateUtil.GuessType(value);
        }

        public static void RegisterType(Type systemType, Type userType, IDictionary<string, string> paramMap = null, IEnumerable<string> aliases = null)
        {
            var customType = new CustomType(userType, paramMap);
            TypeFactory.RegisterType(systemType, customType, aliases ?? new string[] { });
        }

        public static void RegisterType<T1, T2>(IDictionary<string, string> paramMap = null, IEnumerable<string> aliases = null)
        {
            RegisterType(typeof(T1), typeof(T2), paramMap, aliases);
        }

        public static void RegisterDefaultArrayTypes(int maxRank)
        {
            foreach (var rank in Enumerable.Range(1, maxRank))
            {
                RegisterType(typeof(int).MakeArrayType(rank), typeof(Int32ArrayType));
                RegisterType(typeof(short).MakeArrayType(rank), typeof(Int16ArrayType));
                RegisterType(typeof(int).MakeArrayType(rank), typeof(Int32ArrayType));
                RegisterType(typeof(long).MakeArrayType(rank), typeof(Int64ArrayType));
                RegisterType(typeof(decimal).MakeArrayType(rank), typeof(DecimalArrayType));
                RegisterType(typeof(float).MakeArrayType(rank), typeof(SingleArrayType));
                RegisterType(typeof(double).MakeArrayType(rank), typeof(DoubleArrayType));
                RegisterType(typeof(string).MakeArrayType(rank), typeof(StringArrayType));
                RegisterType(typeof(bool).MakeArrayType(rank), typeof(BooleanArrayType));
                RegisterType(typeof(DateTime).MakeArrayType(rank), typeof(DateTimeArrayType));
            }
        }

        public static void RegisterDefaultListTypes()
        {
            RegisterType(typeof(List<int>), typeof(Int32ListType));
            RegisterType(typeof(List<short>), typeof(Int16ListType));
            RegisterType(typeof(List<int>), typeof(Int32ListType));
            RegisterType(typeof(List<long>), typeof(Int64ListType));
            RegisterType(typeof(List<decimal>), typeof(DecimalListType));
            RegisterType(typeof(List<float>), typeof(SingleListType));
            RegisterType(typeof(List<double>), typeof(DoubleListType));
            RegisterType(typeof(List<string>), typeof(StringListType));
            RegisterType(typeof(List<bool>), typeof(BooleanListType));
            RegisterType(typeof(List<DateTime>), typeof(DateTimeListType));
        }

        public static void RegisterDefaultRangeTypes()
        {
            RegisterType(typeof(Range<int>), typeof(Int32RangeType));
            RegisterType(typeof(Range<long>), typeof(Int64RangeType));
            RegisterType(typeof(Range<decimal>), typeof(DecimalRangeType));
        }

        public static void RegisterNodaTimeTypes()
        {
            RegisterType(typeof(Instant), typeof(InstantType));
            RegisterType(typeof(LocalDateTime), typeof(LocalDateTimeType));
            RegisterType(typeof(LocalDate), typeof(LocalDateType));
            RegisterType(typeof(LocalTime), typeof(LocalTimeType));
            RegisterType(typeof(ZonedDateTime), typeof(ZonedDateTimeType));
            RegisterType(typeof(OffsetDateTime), typeof(OffsetDateTimeType));
            RegisterType(typeof(OffsetTime), typeof(OffsetTimeType));
            RegisterType(typeof(Period), typeof(PeriodType));
        }

        public static void RegisterNodaTimeRangeTypes()
        {
            RegisterType(typeof(Range<LocalDate>), typeof(LocalDateRangeType));
            RegisterType(typeof(Range<LocalDateTime>), typeof(LocalDateTimeRangeType));
            RegisterType(typeof(Range<OffsetDateTime>), typeof(OffsetDateTimeRangeType));
        }
    }
}
