using ExpressionParser.Lexer;
using ExpressionParser.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public class Parser
    {
        private List<Token> expression;

        public Parser(List<Token> expression)
        {
            this.expression = expression;
        }

        private void EvaluateTopOperands(Stack<Operand> operandStack, Stack<Token> evaluationStack, IOperator? topOperator)
        {
            if (operandStack.Count >= 2 && topOperator != null)
            {
                Operand operand2 = operandStack.Pop();
                Operand operand1 = operandStack.Pop();
                evaluationStack.Pop();

                operandStack.Push(topOperator.Execute(operand1, operand2));
            }
        }

        public Operand? EvaluateExpression()
        {
            Stack<Operand> operandStack = new Stack<Operand>();
            Stack<Token> evaluationStack = new Stack<Token>();

            OperatorFactory factory = new OperatorFactory();

            foreach (Token expressionToken in expression)
            {
                if (expressionToken.TokenType == TokenType.Number)
                {
                    operandStack.Push(new Operand(expressionToken.Value));
                }

                else if (expressionToken.TokenType == TokenType.Operator)
                {
                    if (evaluationStack.Count == 0)
                    {
                        evaluationStack.Push(expressionToken);
                        continue;
                    }

                    IOperator? expressionOperator = factory.CreateOperator(expressionToken);

                    if (expressionOperator == null)
                    {
                        continue;
                    }

                    while (evaluationStack.Count != 0)
                    {
                        IOperator? stackOperator = factory.CreateOperator(evaluationStack.Peek());

                        if (stackOperator == null || expressionOperator.Priority >= stackOperator.Priority)
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
                }
            
                else if (expressionToken.TokenType == TokenType.OpenBracket)
                {
                    evaluationStack.Push(expressionToken);
                }

                else if (expressionToken.TokenType == TokenType.ClosingBracket)
                {
                    while (evaluationStack.Count != 0)
                    {
                        if (evaluationStack.Peek().TokenType == TokenType.OpenBracket)
                        {
                            evaluationStack.Pop();
                            break;
                        }

                        IOperator? stackOperator = factory.CreateOperator(evaluationStack.Peek());

                        EvaluateTopOperands(operandStack, evaluationStack, stackOperator);
                    }
                }
            }

            while (evaluationStack.Count != 0)
            {
                IOperator? stackOperator = factory.CreateOperator(evaluationStack.Peek());

                EvaluateTopOperands(operandStack, evaluationStack, stackOperator);
            }

            if (evaluationStack.Count == 0 && operandStack.Count == 1)
            {
                return operandStack.Peek();
            }

            return null;
        }
    }
}
