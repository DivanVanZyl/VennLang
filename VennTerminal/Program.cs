using VennLang;

Console.WriteLine("Hello! Please enter a set expression.");
string text = Console.ReadLine();

var lexer = new Lexer();
var parser = new Parser();
var interpreter = new Interpreter();

var result = interpreter.Visit(
parser.Parse(
    lexer.GenerateTokens(text).ToList()
    ));

Console.WriteLine(result);