﻿using NFluent;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Dynamic.Core.Tokenizer;
using Xunit;

namespace System.Linq.Dynamic.Core.Tests
{
    public class TextParserTests
    {
        [Fact]
        public void TextParser_Parse_Bar()
        {
            // Assign + Act
            var textParser = new TextParser(" | ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.Bar);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("|");
        }

        [Fact]
        public void TextParser_Parse_Colon()
        {
            // Assign + Act
            var textParser = new TextParser(" : ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.Colon);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals(":");
        }

        [Fact]
        public void TextParser_Parse_RealLiteral()
        {
            // Assign + Act
            var textParser = new TextParser(" 1.0E25 ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.RealLiteral);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("1.0E25");
        }

        [Fact]
        public void TextParser_Parse_RealLiteralMinus()
        {
            // Assign + Act
            var textParser = new TextParser(" 1.0E-25 ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.RealLiteral);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("1.0E-25");
        }

        [Fact]
        public void TextParser_Parse_RealLiteralPlus()
        {
            // Assign + Act
            var textParser = new TextParser(" 1.0E+25 ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.RealLiteral);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("1.0E+25");
        }

        [Fact]
        public void TextParser_Parse_Exclamation()
        {
            // Assign + Act
            var textParser = new TextParser(" !x");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.Exclamation);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("!");
        }

        [Fact]
        public void TextParser_Parse_ExclamationEqual()
        {
            // Assign + Act
            var textParser = new TextParser(" != 1");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.ExclamationEqual);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("!=");
        }

        [Fact]
        public void TextParser_Parse_GreaterThanEqual()
        {
            // Assign + Act
            var textParser = new TextParser(" >= ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.GreaterThanEqual);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals(">=");
        }

        [Fact]
        public void TextParser_Parse_LessGreater()
        {
            // Assign + Act
            var textParser = new TextParser(" <> ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.LessGreater);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("<>");
        }

        [Fact]
        public void TextParser_Parse_Percent()
        {
            // Assign + Act
            var textParser = new TextParser(" % ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.Percent);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("%");
        }

        [Fact]
        public void TextParser_Parse_Slash()
        {
            // Assign + Act
            var textParser = new TextParser(" / ");

            // Assert
            Check.That(textParser.CurrentToken.Id).Equals(TokenId.Slash);
            Check.That(textParser.CurrentToken.Pos).Equals(1);
            Check.That(textParser.CurrentToken.Text).Equals("/");
        }

        // [Fact]
        public void TextParser_Parse_ThrowsException()
        {
            // Assign + Act + Assert
            Check.ThatCode(() => { new TextParser("ಬಾ"); }).Throws<ParseException>();
        }
    }
}