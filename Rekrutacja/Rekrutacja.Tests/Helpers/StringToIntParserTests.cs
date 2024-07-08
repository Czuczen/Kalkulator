using NUnit.Framework;
using Rekrutacja.Helpers;
using System;

namespace Rekrutacja.Tests.Helpers
{
    [TestFixture]
    public class StringToIntParserTests
    {
        [TestCase("123", 123)]
        [TestCase("-123", -123)]
        [TestCase("0", 0)]
        [TestCase("  42", 42)]
        [TestCase("42  ", 42)]
        [TestCase("  42  ", 42)]
        [TestCase("2147483647", 2147483647)]
        [TestCase("-2147483648", -2147483648)]
        public void Parse_ValidInput_ReturnsExpectedResult(string input, int expected)
        {
            // Act
            var result = StringToIntParser.Parse(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Parse_InvalidInput_ThrowsFormatException()
        {
            // Act & Assert
            var ex = Assert.Throws<FormatException>(() => StringToIntParser.Parse("abc"));
            Assert.That(ex.Message, Is.EqualTo("Input string is not a valid number."));
        }

        [Test]
        public void Parse_NullOrEmptyInput_ThrowsArgumentException()
        {
            // Act & Assert
            var ex1 = Assert.Throws<ArgumentException>(() => StringToIntParser.Parse(null));
            Assert.That(ex1.Message, Is.EqualTo("Input string is null or empty."));

            var ex2 = Assert.Throws<ArgumentException>(() => StringToIntParser.Parse(""));
            Assert.That(ex2.Message, Is.EqualTo("Input string is null or empty."));
        }

        [Test]
        public void Parse_WhitespaceOnlyInput_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => StringToIntParser.Parse("   "));
            Assert.That(ex.Message, Is.EqualTo("Input string is null or empty."));
        }

        [Test]
        public void Parse_InputWithNonDigitCharacters_ThrowsFormatException()
        {
            // Act & Assert
            var ex = Assert.Throws<FormatException>(() => StringToIntParser.Parse("123abc"));
            Assert.That(ex.Message, Is.EqualTo("Input string is not a valid number."));
        }
    }
}
