using ExpressionParser;
using ExpressionParser.Lexer;

string expression = "13 * 2";

Console.WriteLine("Expression:");
Console.WriteLine(expression);
Console.WriteLine();

Lexer lexer = new Lexer(expression);
List<Token> tokens = lexer.GetAllTokens();
lexer.PrintTokens();
Console.WriteLine();

Parser parser = new Parser(tokens);
Operand? expressionResult = parser.EvaluateExpression();

Console.WriteLine("Evaluation result:");
if (expressionResult != null)
{
    Console.WriteLine(expressionResult.Value);
}
else
{
    Console.WriteLine("Bad expression");
}
