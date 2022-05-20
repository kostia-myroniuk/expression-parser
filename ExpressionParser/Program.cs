using ExpressionParser;
using ExpressionParser.Lexer;

string expression = "13 ^ 2 * (2 + 3/3 + (15 - (2^3)))";

Console.WriteLine("Expression:");
Console.WriteLine(expression);
Console.WriteLine();

Lexer lexer = new Lexer(expression);
List<Token> tokens = lexer.GetAllTokens();

Console.WriteLine("Lexer tokens:");
foreach (var token in tokens)
{
    Console.WriteLine(token);
}
Console.WriteLine();

Parser parser = new Parser(tokens);
try
{
    Operand expressionResult = parser.EvaluateExpression();
    Console.WriteLine("Evaluation result:");
    Console.WriteLine(expressionResult.Value);
}
catch (ParserException exception)
{
    Console.WriteLine(exception.Message);
}
