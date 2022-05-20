using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Operators
{
    public class ExponentiationOperator : IOperator
    {
        public int Priority => 3;

        public Func<Operand, Operand, Operand> Evaluate =>
            (a, b) => new Operand((int)Math.Pow(a.Value, b.Value));
    }
}
