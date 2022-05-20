using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Operators
{
    public interface IOperator
    {
        public int Priority { get; }
        public Operand Execute(Operand operand1, Operand operand2);
    }
}
