using ExpressionParser;
using ExpressionParser.Lexer;

string expression = "30 - (2 ^ 3 + 1)";

Console.WriteLine(expression);

Lexer lexer = new Lexer(expression);
List<Token> tokens = lexer.GetAllTokens();

lexer.PrintTokens();

Parser parser = new Parser(tokens);

Operand? result = parser.EvaluateExpression();
if (result != null)
{
    Console.WriteLine(result.Value);
}