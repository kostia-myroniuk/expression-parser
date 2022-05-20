using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Operators
{
    public class SubtractionOperator : IOperator
    {
        public int Priority => 1;

        public Func<Operand, Operand, Operand> Evaluate =>
            (a, b) => new Operand(a.Value - b.Value);
    }
}
