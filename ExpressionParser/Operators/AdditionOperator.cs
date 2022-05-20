using ExpressionParser.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Operators
{
    public class AdditionOperator : IOperator
    {
        public int Priority => 1;

        public Func<Operand, Operand, Operand> Evaluate => 
            (a, b) => new Operand(a.Value + b.Value);
    }
}
