using ExpressionParser.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public class Operand
    {
        public int Value { get; }

        public Operand(int value)
        {
            Value = value;
        }

        public Operand(string value)
            : this(Convert.ToInt32(value))
        {

        }
    }
}
