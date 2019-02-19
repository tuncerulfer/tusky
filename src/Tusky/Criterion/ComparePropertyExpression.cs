using System;
using NHibernate.Criterion;

namespace Tusky.Criterion
{
    [Serializable]
    public class ComparePropertyExpression : PropertyExpression
    {
        private readonly string op;

        protected override string Op => op;

        public ComparePropertyExpression(IProjection leftProjection, string rightPropertyName, string op)
            : base(leftProjection, rightPropertyName)
        {
            this.op = op;
        }

        public ComparePropertyExpression(IProjection leftProjection, IProjection rightProjection, string op)
            : base(leftProjection, rightProjection)
        {
            this.op = op;
        }

        public ComparePropertyExpression(string leftPropertyName, string rightPropertyName, string op)
            : base(leftPropertyName, rightPropertyName)
        {
            this.op = op;
        }

        public ComparePropertyExpression(string leftPropertyName, IProjection rightProjection, string op)
            : base(leftPropertyName, rightProjection)
        {
            this.op = op;
        }
    }
}
