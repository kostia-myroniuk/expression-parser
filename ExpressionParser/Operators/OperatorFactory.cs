using ExpressionParser.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Operators
{
    public class OperatorFactory
    {
        public IOperator? CreateOperator(Token token)
        {
            if (token.TokenType != TokenType.Operator)
            {
                return null;
            }

            switch (token.Value)
            {
                case "+":
                    return new AdditionOperator();
                case "-":
                    return new SubtractionOperator();
                case "*":
                    return new MultiplicationOperator();
                case "/":
                    return new DivisionOperator();
                case "^":
                    return new ExponentiationOperator();
            }

            return null;
            // fun<double,double,double> = (a,b)=>a - a
        }
    }
}
