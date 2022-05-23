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

        private readonly Dictionary<char, TokenType> characterTokenTypes =
            new Dictionary<char, TokenType>()
            {
                { '+', TokenType.Operator },
                { '-', TokenType.Operator },
                { '*', TokenType.Operator },
                { '/', TokenType.Operator },
                { '^', TokenType.Operator },
                { '(', TokenType.OpenBracket },
                { ')', TokenType.ClosingBracket }
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
                    return new Token(TokenType.Operand, tokenValue);
                }

                else if (characterTokenTypes.ContainsKey(currentCharacter))
                {
                    IncrementPosition();
                    return new Token(characterTokenTypes[currentCharacter], currentCharacter.ToString());
                }

                IncrementPosition();
            }

            return null;
        }
    }
}
