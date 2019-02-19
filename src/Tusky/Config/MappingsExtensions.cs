using Tusky.Types;
using NHibernate.Cfg;

namespace Tusky.Config
{
    public static class MappingsExtensions
    {
        public static void AddDefaultArrayTypes(this Mappings mappings)
        {
            mappings.AddTypeDef<Int16ArrayType>("Int16Array");
            mappings.AddTypeDef<Int32ArrayType>("Int32Array");
            mappings.AddTypeDef<Int64ArrayType>("Int64Array");
            mappings.AddTypeDef<DecimalArrayType>("DecimalArray");
            mappings.AddTypeDef<SingleArrayType>("SingleArray");
            mappings.AddTypeDef<DoubleArrayType>("DoubleArray");
            mappings.AddTypeDef<StringArrayType>("StringArray");
            mappings.AddTypeDef<BooleanArrayType>("BooleanArray");
            mappings.AddTypeDef<DateTimeArrayType>("DateTimeArray");
        }

        public static void AddDefaultListTypeDefs(this Mappings mappings)
        {
            mappings.AddTypeDef<Int16ListType>("Int16List");
            mappings.AddTypeDef<Int32ListType>("Int32List");
            mappings.AddTypeDef<Int64ListType>("Int64List");
            mappings.AddTypeDef<DecimalListType>("DecimalList");
            mappings.AddTypeDef<SingleListType>("SingleList");
            mappings.AddTypeDef<DoubleListType>("DoubleList");
            mappings.AddTypeDef<StringListType>("StringList");
            mappings.AddTypeDef<BooleanListType>("BooleanList");
            mappings.AddTypeDef<DateTimeListType>("DateTimeList");
        }

        public static void AddDefaultRangeTypeDefs(this Mappings mappings)
        {
            mappings.AddTypeDef<Int32RangeType>("Int32Range");
            mappings.AddTypeDef<Int64RangeType>("Int64Range");
            mappings.AddTypeDef<DecimalRangeType>("DecimalRange");
        }

        public static void AddDefaultDateTimeRangeTypeDefs(this Mappings mappings)
        {
            mappings.AddTypeDef<DateTimeRangeType>("DateTimeRange");
            mappings.AddTypeDef<DateTimeOffsetRangeType>("DateTimeOffsetRange");
        }

        public static void AddDefaultNetworkTypes(this Mappings mappings)
        {
            mappings.AddTypeDef<InetType>("Inet");
            mappings.AddTypeDef<MacAddrType>("MacAddr");
        }

        public static void AddNodaTimeTypeDefs(this Mappings mappings)
        {
            mappings.AddTypeDef<InstantType>("Instant");
            mappings.AddTypeDef<LocalDateTimeType>("LocalDateTime");
            mappings.AddTypeDef<LocalDateType>("LocalDate");
            mappings.AddTypeDef<LocalTimeType>("LocalTime");
            mappings.AddTypeDef<ZonedDateTimeType>("ZonedDateTime");
            mappings.AddTypeDef<OffsetDateTimeType>("OffsetDateTime");
            mappings.AddTypeDef<OffsetTimeType>("OffsetTime");
            mappings.AddTypeDef<PeriodType>("Period");
        }

        public static void AddNodaTimeRangeTypeDefs(this Mappings mappings)
        {
            mappings.AddTypeDef<LocalDateTimeRangeType>("LocalDateTimeRange");
            mappings.AddTypeDef<LocalDateRangeType>("LocalDateRange");
            mappings.AddTypeDef<OffsetDateTimeRangeType>("OffsetDateTimeRange");
        }
    }
}
