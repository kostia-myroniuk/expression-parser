namespace ExpressionParser
{
    public enum TokenType
    {
        WhiteSpace,
        BadToken,
        EndOfInput,
        Number,
        AdditionOperator,
        SubtractionOperator,
        MultiplicationOperator,
        DivisionOperator,
        ExponentiationOperator,
        OpenBracket,
        ClosingBracket
    }
}
