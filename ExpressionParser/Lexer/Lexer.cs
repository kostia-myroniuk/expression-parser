using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Lexer
{
    public class Lexer
    {
        private readonly string expression;
        private int position;

        private readonly List<char> operatorCharacters =
            new List<char> {
                '+', '-', '*', '/', '^'
            };

        public List<Token> Tokens { get; private set; } = new List<Token>();

        public Lexer(string expression)
        {
            this.expression = expression;
        }

        public List<Token> GetAllTokens()
        {
            Tokens = new List<Token>();
            position = 0;

            Token? nextToken = GetNextToken();
            while (nextToken != null)
            {
                Tokens.Add(nextToken);
                nextToken = GetNextToken();
            }

            return Tokens;
        }

        public void PrintTokens()
        {
            foreach (var token in Tokens)
            {
                Console.WriteLine(token);
            }
        }

        private void IncrementPosition()
        {
            position++;
        }

        private Token? GetNextToken()
        {
            while (position < expression.Length)
            {
                char currentCharacter = expression[position];

                if (char.IsDigit(currentCharacter))
                {
                    string tokenValue = "";
                    while (position < expression.Length && char.IsDigit(expression[position]))
                    {
                        tokenValue += expression[position];
                        IncrementPosition();
                    }
                    return new Token(TokenType.Number, tokenValue);
                }

                else if (operatorCharacters.Contains(currentCharacter))
                {
                    IncrementPosition();
                    return new Token(TokenType.Operator, currentCharacter.ToString());
                }

                else if (currentCharacter == '(')
                {
                    IncrementPosition();
                    return new Token(TokenType.OpenBracket, currentCharacter.ToString());
                }

                else if (currentCharacter == ')')
                {
                    IncrementPosition();
                    return new Token(TokenType.ClosingBracket, currentCharacter.ToString());
                }

                IncrementPosition();
            }

            return null;
        }
    }
}
