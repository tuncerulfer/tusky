namespace Tusky.Criterion
{
    public static class RangeOperator
    {
        public const string Equal = " = ";
        public const string NotEqual = " <> ";
        public const string GreaterThan = " > ";
        public const string LessThan = " < ";
        public const string GreaterThanOrEqual = " >= ";
        public const string LessThanOrEqual = " <= ";
        public const string Contains = " @> ";
        public const string ContainedBy = " <@ ";
        public const string Overlaps = " && ";
        public const string StrictlyLeftOf = " << ";
        public const string StrictlyRightOf = " >> ";
        public const string NotExtendRightOf = " &< ";
        public const string NotExtendLeftOf = " &> ";
        public const string AdjacentTo = " -|- ";
        public const string Union = " + ";
        public const string Intersect = " * ";
        public const string Diff = " - ";
    }
}
