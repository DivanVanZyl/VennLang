using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VennLang
{
    public class Parser
    {
        private List<Token> _tokens;
        private int _position = 0;
        public Node Parse(List<Token>? tokens)
        {
            if (tokens is not null && tokens.Count > 0)
                _tokens = tokens;
            else
                throw new InvalidDataException("You cannot create a parser with zero tokens.");

            var result = Expression();  //This Node would be the "root" node of the tree.

            if (_position < _tokens.Count - 1)  //In this case, not all nodes have been processed, and is caused by invalid syntax/expression
            {
                throw new Exception("Invalid syntax. " + (_tokens.Count - 1 - _position) + "tokens unparsed.");
            }

            return result;
        }

        private Node Expression()
        {
            var result = Set();

            while (_position < _tokens.Count && (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect
                            || _tokens[_position].TokenType == TokenTypes.TokenType.Union
                            || _tokens[_position].TokenType == TokenTypes.TokenType.SetDifference
                            || _tokens[_position].TokenType == TokenTypes.TokenType.SymmetricSetDifference))
            {
                if (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect)
                {
                    _position++;
                    result = new IntersectNode(result, Set());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.Union)
                {
                    _position++;
                    result = new UnionNode(result, Set());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.SetDifference)
                {
                    _position++;
                    result = new SetDifferenceNode(result, Set());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.SymmetricSetDifference)
                {
                    _position++;
                    result = new SymmertricSetDifferenceNode(result, Set());
                }
            }
            return result;
        }

        //Set is conceptually equivelant to a term in a simple math parser.
        private Node Set()
        {
            if (_tokens[_position].TokenType != TokenTypes.TokenType.OpenBrace)
                throw new Exception("Invalid Syntax: Expected { at the start of the set, but received: " + _tokens[_position].Value + " of type: " + _tokens[_position].TokenType);

            _position++;
            SetNode result = new SetNode(new List<object> { });
            if (_tokens[_position].TokenType != TokenTypes.TokenType.Element)
            {
                if (_tokens[_position].TokenType == TokenTypes.TokenType.OpenBrace)
                {
                    result.AddElement(Set().ToString());
                }
            }
            else
            {
                result = new SetNode(new List<object> { Element() });
            }

            while (_position < _tokens.Count && (_tokens[_position].TokenType == TokenTypes.TokenType.Comma))
            {
                _position++;
                result.AddElement(Element());
            }

            if (_tokens[_position].TokenType == TokenTypes.TokenType.CloseBrace)
            {
                _position++;
                if (result.Values.Count == 0)
                    return new SetNode(new List<object> { "" });
                return result;
            }
            else
            {
                throw new Exception("Invalid Syntax: Expected } at the end of the set, but received: '" + _tokens[_position].Value + "' of type: " + _tokens[_position].TokenType);
            }
        }

        //Element is conceptually equivelant to an factor in a simple math parser.
        private string Element()
        {
            var token = _tokens[_position];
            if (token.TokenType == TokenTypes.TokenType.Element)
            {
                return _tokens[_position++].Value;
            }
            else if (token.TokenType == TokenTypes.TokenType.OpenBrace)
            {
                return Set().ToString();
            }

            throw new Exception("Invalid Element");
        }
    }
}
