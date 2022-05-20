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
        public Func<Operand, Operand, Operand> Evaluate { get; }
    }
}
