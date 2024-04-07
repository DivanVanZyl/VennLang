using VennLang.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VennLang.TokenTypes;

namespace VennLang
{
    public class Lexer
    {
        private string _text;
        private int _position = 0;
        public IEnumerable<Token> GenerateTokens(string? text)
        {
            if (text is not null)
                _text = text;

            while (_position < _text.Length)
            {
                if (_text[_position].IsWhitespace())
                {
                    _position++;
                }
                else
                {
                    //Elements. Simliar to "Number" in "Simple Math Parser" terms, in the sense that it is the most atomic contruct of a set theory expression.
                    if (Char.IsDigit(_text[_position]) || _text[_position] == '.')
                    {
                        yield return GenerateNumber();
                    }
                    else if (_text[_position].IsLetter())
                    {
                        yield return GenerateElement();
                    }
                    //Operators
                    else if (_text[_position] == '\\')
                    {
                        yield return GenerateOperator();
                    }
                    else if (_text[_position] == '{')
                    {
                        yield return new Token(TokenType.OpenBrace, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '}')
                    {
                        yield return new Token(TokenType.CloseBrace, _text[_position++].ToString());
                    }
                    else if (_text[_position] == ',')
                    {
                        yield return new Token(TokenType.Comma, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '=')
                    {
                        yield return new Token(TokenType.Equals, _text[_position++].ToString());
                    }
                    /*else if (_text[_position].IsLetter())
                    {
                        yield return new Token(TokenType.Variable, _text[_position++].ToString());
                    }*/
                    else if (_text[_position] == '∩')
                    {
                        yield return new Token(TokenType.Intersect, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '∪')
                    {
                        yield return new Token(TokenType.Union, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '(')
                    {
                        yield return new Token(TokenType.OpenParenthesis, _text[_position++].ToString());
                    }
                    else if (_text[_position] == ')')
                    {
                        yield return new Token(TokenType.CloseParenthesis, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '∅')
                    {
                        yield return new Token(TokenType.EmptySet, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '-')
                    {
                        yield return new Token(TokenType.Minus, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '+')
                    {
                        yield return new Token(TokenType.Plus, _text[_position++].ToString());
                    }
                    else
                    {
                        throw new Exception("Illegal character: " + _text[_position++]);
                    }
                }
            }
        }

        private Token GenerateNumber()
        {
            string number = "";
            while (_position < _text.Length && _text[_position].IsNumber())
            {
                number += _text[_position++].ToString();
            }
            return new Token(TokenType.Element, number);
        }

        private Token GenerateElement()
        {
            string element = "";
            while (_position < _text.Length && (_text[_position].IsLetter() || _text[_position].IsNumber()))
            {
                element += _text[_position++].ToString();
            }
            return new Token(TokenType.Element, element);
        }

        //This method is needed because it is more conveniet to type \union than ∪ for example. 
        //This method changes that "\union" into "∪".
        private Token GenerateOperator()
        {
            string operatorText = "";
            while (_position < _text.Length && (_text[_position].IsLetter() || _text[_position] == '\\'))
            {
                operatorText += _text[_position++].ToString();
            }
            if (operatorText.ToLower() == @"\int" || operatorText.ToLower() == @"\intersect")
            {
                return new Token(TokenType.Intersect, "∩");
            }
            else if (operatorText.ToLower() == @"\un" || operatorText.ToLower() == @"\union")
            {
                return new Token(TokenType.Union, "∪");
            }
            else if (operatorText.ToLower() == @"\diff" || operatorText.ToLower() == @"\difference")
            {
                return new Token(TokenType.SetDifference, "-");
            }
            else if (operatorText.ToLower() == @"\sym" || operatorText.ToLower() == @"\symdiff" || operatorText.ToLower() == @"\symmetricdifference")
            {
                return new Token(TokenType.SymmetricSetDifference, "+");
            }
            else
            {
                throw new Exception("Illegal set theory operator: " + operatorText);
            }
        }
    }
}
