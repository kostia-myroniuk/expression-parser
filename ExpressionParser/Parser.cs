using ExpressionParser.Lexer;
using ExpressionParser.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    class ParserException : Exception
    {
        public ParserException(string message)
        : base(message) { }
    }

    public class Parser
    {
        private List<Token> expression;
        private readonly Dictionary<string, IOperator> tokenValueOperators =
            new Dictionary<string, IOperator>()
            {
                { "+", new AdditionOperator() },
                { "-", new SubtractionOperator() },
                { "/", new DivisionOperator() },
                { "*", new MultiplicationOperator() },
                { "^", new ExponentiationOperator() }
            };

        public Parser(List<Token> expression)
        {
            this.expression = expression;
        }

        public Operand EvaluateExpression()
        {
            if (!TokenValuesHaveOperators() || !BracketsAreValid())
            {
                throw new ParserException("Bad expression");
            }

            Stack<Operand> operandStack = new Stack<Operand>();
            Stack<Token> evaluationStack = new Stack<Token>();

            foreach (Token expressionToken in expression)
            {
                switch (expressionToken.TokenType)
                {
                    case TokenType.Number:
                        operandStack.Push(new Operand(expressionToken.Value));
                        break;

                    case TokenType.Operator:
                        IOperator expressionOperator = tokenValueOperators[expressionToken.Value];

                        while (evaluationStack.Count != 0)
                        {
                            if  (evaluationStack.Peek().TokenType == TokenType.OpenBracket ||
                                evaluationStack.Peek().TokenType == TokenType.ClosingBracket)
                            {
                                evaluationStack.Push(expressionToken);
                                break;
                            }

                            IOperator stackOperator = tokenValueOperators[evaluationStack.Peek().Value];
                            
                            if (expressionOperator.Priority >= stackOperator.Priority)
                            {
                                evaluationStack.Push(expressionToken);
                                break;
                            }

                            EvaluateTopOperands(operandStack, evaluationStack, stackOperator);
                        }

                        if (evaluationStack.Count == 0)
                        {
                            evaluationStack.Push(expressionToken);
                        }

                        break;

                    case TokenType.OpenBracket:
                        evaluationStack.Push(expressionToken);
                        break;

                    case TokenType.ClosingBracket:
                        while (evaluationStack.Count != 0)
                        {
                            if (evaluationStack.Peek().TokenType == TokenType.OpenBracket)
                            {
                                evaluationStack.Pop();
                                break;
                            }

                            IOperator stackOperator = tokenValueOperators[evaluationStack.Peek().Value];
                            EvaluateTopOperands(operandStack, evaluationStack, stackOperator);
                        }

                        break;
                }
            }

            while (evaluationStack.Count != 0)
            {
                IOperator stackOperator = tokenValueOperators[evaluationStack.Peek().Value];
                EvaluateTopOperands(operandStack, evaluationStack, stackOperator);
            }

            if (evaluationStack.Count != 0 || operandStack.Count != 1)
            {
                throw new ParserException("Bad expression");
            }
            
            return operandStack.Peek();
        }

        private void EvaluateTopOperands(Stack<Operand> operandStack, Stack<Token> evaluationStack, IOperator topOperator)
        {
            if (operandStack.Count < 2)
            {
                throw new ParserException("Bad expression");
            }

            Operand operand2 = operandStack.Pop();
            Operand operand1 = operandStack.Pop();
            evaluationStack.Pop();
            operandStack.Push(topOperator.Evaluate(operand1, operand2));
        }

        private bool TokenValuesHaveOperators()
        {
            foreach (Token expressionToken in expression)
            {
                if (expressionToken.TokenType == TokenType.Operator &&
                    !tokenValueOperators.ContainsKey(expressionToken.Value))
                {
                    return false;
                }
            }
            return true;
        }

        private bool BracketsAreValid()
        {
            int counter = 0;

            foreach (Token expressionToken in expression)
            {
                if (expressionToken.TokenType == TokenType.OpenBracket)
                {
                    counter++;
                }
                else if (expressionToken.TokenType == TokenType.ClosingBracket)
                {
                    counter--;
                }

                if (counter < 0)
                {
                    return false;
                }
            }

            return counter == 0;
        }
    }
}
