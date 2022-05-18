using ExpressionParser;

string expression = "215 + 10 + 34 * (2 /  3)-4 #$%f";

Console.WriteLine(expression);

ExpressionTokenizer tokenizer = new ExpressionTokenizer(expression);
tokenizer.Tokenize();

foreach (var token in tokenizer.Tokens)
{
    Console.WriteLine(token);
}