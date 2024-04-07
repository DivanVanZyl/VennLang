using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VennLang;

namespace Venn.InterpreterTests
{
    public  class ExpressionTests
    {        
        [Test]
        public void EmptySetDifferenceNode()
        {
            //Arrange
            string testData = "{1,2,3} \\diff {1,2,3}";
            Lexer lexer = new Lexer();
            Parser parser = new Parser();
            Interpreter interpreter = new Interpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var result = interpreter.Visit(tree);

            //Assert
            Assert.That(result, Is.EqualTo("{}"));
        }
        [Test]
        public void DifferenceNode()
        {
            //Arrange
            string testData = "{1,2,3} \\diff {3,4,5}";
            Lexer lexer = new Lexer();
            Parser parser = new Parser();
            Interpreter interpreter = new Interpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var result = interpreter.Visit(tree);

            //Assert
            Assert.That(result, Is.EqualTo("{1,2}"));
        }
    }
}
