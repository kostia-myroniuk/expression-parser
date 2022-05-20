using ExpressionParser.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public static class TokenExtension
    {
        public static bool TokenTypeIsBracket(this TokenType tokenType)
        {
            return tokenType == TokenType.OpenBracket ||
                tokenType == TokenType.ClosingBracket;
        }

        public static bool TokenIsBracket(this Token token)
        {
            return TokenTypeIsBracket(token.TokenType);
        }
    }
}
