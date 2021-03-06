namespace ExpressionParser.Lexer
{
    public class Token
    {
        public Token(TokenType tokenType, string value = "")
        {
            TokenType = tokenType;
            Value = value;
        }

        public TokenType TokenType { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{TokenType} token. Value = \"{Value}\"";
        }
    }
}
