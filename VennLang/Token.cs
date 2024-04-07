using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VennLang
{
    public class TokenTypes
    {
        public enum TokenType
        {
            //Simple
            Number,
            Plus,
            Minus,
            Multiply,
            Divide,
            OpenBrace,
            CloseBrace,

            //Set Theory
            Intersect,  //∩
            Union,  //∪
            SetDifference,  //-
            SymmetricSetDifference, //+
            OpenParenthesis,
            CloseParenthesis,
            Comma,
            Equals,
            Variable,
            EmptySet,
            Element //Element of a set or "member" of a set.
        }
    }

    //This is a struct as I want to allocate it on the stack for performance reasons.
    public struct Token
    {
        private TokenTypes.TokenType _tokenType;
        private string? _value = null;

        public TokenTypes.TokenType TokenType => _tokenType;
        public string? Value => _value;

        public Token(TokenTypes.TokenType tokenType, string value)
        {
            _tokenType = tokenType;
            _value = value;
        }

        public override string ToString()
        {
            return this._tokenType.ToString() + (_value is not null ? " " + _value.ToString() : "");
        }
    }
}
