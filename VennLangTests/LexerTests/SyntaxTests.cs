using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VennLang;

namespace Venn.LexerTests
{
    public class SyntaxTests
    {
        [SetUp]
        public void Setup()
        {

        }
        
        [Test]
        public void CloseBrace()
        {
            //Arrange
            string testData = "}";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.CloseBrace));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Comma()
        {
            //Arrange
            string testData = ",";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Equals()
        {
            //Arrange
            string testData = "=";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Equals));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Element_SingleLetter()
        {
            //Arrange
            string testData = "a";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Element));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Element_Word()
        {
            //Arrange
            string testData = "someElement";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Element));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Element_Number()
        {
            //Arrange
            string testData = "1";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Element));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Element_LongerNumber()
        {
            //Arrange
            string testData = "123456";
            Lexer lexer = new Lexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Element));
            Assert.That(result.Value, Is.EqualTo(testData));
        }
    }
}