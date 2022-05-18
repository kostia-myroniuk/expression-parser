using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public class ExpressionTokenizer
    {
        private string expression;
        private int position;

        private readonly Dictionary<char, TokenType> singleCharacterTokenTypes = 
            new Dictionary<char, TokenType> {
                { '+', TokenType.AdditionOperator },
                { '-', TokenType.SubtractionOperator },
                { '*', TokenType.MultiplicationOperator },
                { '/', TokenType.DivisionOperator },
                { '(', TokenType.OpenBracket },
                { ')', TokenType.ClosingBracket }
            };

        public List<Token> Tokens { get; private set; } = new List<Token>(); 

        public ExpressionTokenizer(string expression)
        {
            this.expression = expression;
        }

        public void Tokenize()
        {
            Tokens = new List<Token>();
            position = 0;

            while (true)
            {
                Token nextToken = GetNextToken();
                if (nextToken.TokenType == TokenType.EndOfInput)
                {
                    break;
                }
                Tokens.Add(nextToken);
            }
        }

        private void IncrementPosition()
        {
            position++;
        }

        private Token GetNextToken()
        {
            if (position >= expression.Length)
            {
                return new Token(TokenType.EndOfInput);
            }

            char currentCharacter = expression[position];

            if (char.IsDigit(currentCharacter)) 
            {
                string tokenValue = "";

                while (position < expression.Length)
                {
                    currentCharacter = expression[position];
                    if (char.IsDigit(currentCharacter))
                    {
                        tokenValue += currentCharacter;
                        IncrementPosition();
                    }
                    else break;
                }

                return new Token(TokenType.Number, tokenValue);
            }
            
            else if (char.IsWhiteSpace(currentCharacter))
            {
                string tokenValue = "";

                while (position < expression.Length)
                {
                    currentCharacter = expression[position];
                    if (char.IsWhiteSpace(currentCharacter))
                    {
                        tokenValue += currentCharacter;
                        IncrementPosition();
                    }
                    else break;
                }

                return new Token(TokenType.WhiteSpace, tokenValue);
            }

            else if (singleCharacterTokenTypes.ContainsKey(currentCharacter)) 
            {
                TokenType tokenType = singleCharacterTokenTypes[currentCharacter];
                IncrementPosition();
                return new Token(tokenType, currentCharacter.ToString());
            }

            IncrementPosition();
            return new Token(TokenType.BadToken, currentCharacter.ToString());
        }
    }
}
