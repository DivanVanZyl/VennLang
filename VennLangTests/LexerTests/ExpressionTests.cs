using VennLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VennLang.TokenTypes;

namespace Venn.LexerTests
{
    public class ExpressionTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SimpleExpression()
        {
            //Arrange
            string testData = "{1,2,3}";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);

            List<Token> results = new List<Token>();
            foreach (var token in tokens)
            {
                results.Add(token);
            }

            //Assert
            Assert.That(results[0].TokenType, Is.EqualTo(TokenType.OpenBrace));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[3].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[4].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[5].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[6].TokenType, Is.EqualTo(TokenType.CloseBrace));
        }

        [Test]
        public void UnionExpression()
        {
            //Arrange
            string testData = @"{1,2,3} \union {4,5,6}";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);

            List<Token> results = new List<Token>();
            foreach (var token in tokens)
            {
                results.Add(token);
            }

            //Assert
            Assert.That(results[0].TokenType, Is.EqualTo(TokenType.OpenBrace));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[3].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[4].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[5].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[6].TokenType, Is.EqualTo(TokenType.CloseBrace));

            Assert.That(results[7].TokenType, Is.EqualTo(TokenTypes.TokenType.Union));

            Assert.That(results[8].TokenType, Is.EqualTo(TokenType.OpenBrace));
            Assert.That(results[9].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[10].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[11].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[12].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[13].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[14].TokenType, Is.EqualTo(TokenType.CloseBrace));
        }

        [Test]
        public void IntersectExpression()
        {
            //Arrange
            string testData = @"{1,2,3} \intersect {3,4,5,6}";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);

            List<Token> results = new List<Token>();
            foreach (var token in tokens)
            {
                results.Add(token);
            }

            //Assert
            Assert.That(results[0].TokenType, Is.EqualTo(TokenType.OpenBrace));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[3].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[4].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[5].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[6].TokenType, Is.EqualTo(TokenType.CloseBrace));

            Assert.That(results[7].TokenType, Is.EqualTo(TokenTypes.TokenType.Intersect));

            Assert.That(results[8].TokenType, Is.EqualTo(TokenType.OpenBrace));
            Assert.That(results[9].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[10].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[11].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[12].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[13].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[14].TokenType, Is.EqualTo(TokenType.Comma));
            Assert.That(results[15].TokenType, Is.EqualTo(TokenType.Element));
            Assert.That(results[16].TokenType, Is.EqualTo(TokenType.CloseBrace));
        }
        /*
         * Assignment expressions like this, I will leave as a future feature
         * [Test]
        public void AssignmentExpression()
        {
            //Arrange
            string testData = "A = {1,2,3}";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);

            List<Token> results = new List<Token>();
            foreach (var token in tokens)
            {
                results.Add(token);
            }

            //Assert
            Assert.That(results[0].TokenType, Is.EqualTo(TokenTypes.TokenType.Variable));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenTypes.TokenType.Equals));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenTypes.TokenType.Set));

            var testDataTrimmed = testData.Replace(" ", "");
            Assert.That(results[0].Value, Is.EqualTo("A"));
            Assert.That(results[1].Value, Is.EqualTo("="));
            Assert.That(results[2].Value, Is.EqualTo("{1,2,3}"));
        }
*/

    }
}
