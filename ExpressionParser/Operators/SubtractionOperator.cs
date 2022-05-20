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

        public Operand Evaluate(Operand operand1, Operand operand2)
        {
            return new Operand(operand1.Value - operand2.Value);
        }
    }
}
