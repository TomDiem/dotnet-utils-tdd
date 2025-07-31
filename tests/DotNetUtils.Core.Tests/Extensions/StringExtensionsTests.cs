using FluentAssertions;
using DotNetUtils.Core.Extensions;
using Xunit;

namespace DotNetUtils.Core.Tests.Extensions
{
    /// <summary>
    /// Tests para StringExtensions desarrollados con TDD estricto.
    /// Cada test sigue el patrón Arrange-Act-Assert.
    /// </summary>
    public class StringExtensionsTests
    {
        #region IsValidEmail Tests

        [Fact]
        public void IsValidEmail_ValidEmail_ReturnsTrue()
        {
            // Arrange
            var email = "test@example.com";

            // Act
            var result = email!.IsValidEmail();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidEmail_NullEmail_ReturnsFalse()
        {
            // Arrange
            string? email = null;

            // Act
            var result = email!.IsValidEmail();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidEmail_EmptyEmail_ReturnsFalse()
        {
            // Arrange
            var email = "";

            // Act
            var result = email.IsValidEmail();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidEmail_WhitespaceEmail_ReturnsFalse()
        {
            // Arrange
            var email = "   ";

            // Act
            var result = email.IsValidEmail();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidEmail_EmailWithoutAtSymbol_ReturnsFalse()
        {
            // Arrange
            var email = "testexample.com";

            // Act
            var result = email.IsValidEmail();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidEmail_EmailWithoutDomain_ReturnsFalse()
        {
            // Arrange
            var email = "test@";

            // Act
            var result = email.IsValidEmail();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidEmail_ComplexValidEmail_ReturnsTrue()
        {
            // Arrange
            var email = "user.name+tag@example-domain.co.uk";

            // Act
            var result = email.IsValidEmail();

            // Assert
            result.Should().BeTrue();
        }

        #endregion

        #region IsValidUrl Tests

        [Fact]
        public void IsValidUrl_ValidHttpUrl_ReturnsTrue()
        {
            // Arrange
            var url = "http://example.com";

            // Act
            var result = url.IsValidUrl();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidUrl_ValidHttpsUrl_ReturnsTrue()
        {
            // Arrange
            var url = "https://www.example.com/path?query=value";

            // Act
            var result = url.IsValidUrl();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidUrl_NullUrl_ReturnsFalse()
        {
            // Arrange
            string? url = null;

            // Act
            var result = url!.IsValidUrl();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidUrl_InvalidUrl_ReturnsFalse()
        {
            // Arrange
            var url = "not-a-url";

            // Act
            var result = url.IsValidUrl();

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        #region ToTitleCase Tests

        [Fact]
        public void ToTitleCase_LowercaseWords_ReturnsProperCase()
        {
            // Arrange
            var input = "hello world";

            // Act
            var result = input.ToTitleCase();

            // Assert
            result.Should().Be("Hello World");
        }

        [Fact]
        public void ToTitleCase_MixedCase_ReturnsProperCase()
        {
            // Arrange
            var input = "hELLo WoRLd";

            // Act
            var result = input.ToTitleCase();

            // Assert
            result.Should().Be("Hello World");
        }

        [Fact]
        public void ToTitleCase_NullString_ReturnsNull()
        {
            // Arrange
            string? input = null;

            // Act
            var result = input.ToTitleCase();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void ToTitleCase_EmptyString_ReturnsEmpty()
        {
            // Arrange
            var input = "";

            // Act
            var result = input.ToTitleCase();

            // Assert
            result.Should().Be("");
        }

        [Fact]
        public void ToTitleCase_SingleWord_ReturnsCapitalized()
        {
            // Arrange
            var input = "hello";

            // Act
            var result = input.ToTitleCase();

            // Assert
            result.Should().Be("Hello");
        }

        #endregion

        #region RemoveSpecialCharacters Tests

        [Fact]
        public void RemoveSpecialCharacters_StringWithSpecialChars_ReturnsCleanString()
        {
            // Arrange
            var input = "Hello!@# World$%^";

            // Act
            var result = input.RemoveSpecialCharacters();

            // Assert
            result.Should().Be("Hello World");
        }

        [Fact]
        public void RemoveSpecialCharacters_OnlyLettersAndNumbers_ReturnsUnchanged()
        {
            // Arrange
            var input = "Hello123 World456";

            // Act
            var result = input.RemoveSpecialCharacters();

            // Assert
            result.Should().Be("Hello123 World456");
        }

        [Fact]
        public void RemoveSpecialCharacters_NullString_ReturnsNull()
        {
            // Arrange
            string? input = null;

            // Act
            var result = input.RemoveSpecialCharacters();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void RemoveSpecialCharacters_OnlySpecialChars_ReturnsEmpty()
        {
            // Arrange
            var input = "!@#$%^&*()";

            // Act
            var result = input.RemoveSpecialCharacters();

            // Assert
            result.Should().Be("");
        }

        #endregion

        #region IsNumeric Tests

        [Fact]
        public void IsNumeric_ValidInteger_ReturnsTrue()
        {
            // Arrange
            var input = "123";

            // Act
            var result = input.IsNumeric();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNumeric_ValidDecimal_ReturnsTrue()
        {
            // Arrange
            var input = "123.45";

            // Act
            var result = input.IsNumeric();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNumeric_NegativeNumber_ReturnsTrue()
        {
            // Arrange
            var input = "-123.45";

            // Act
            var result = input.IsNumeric();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNumeric_NonNumericString_ReturnsFalse()
        {
            // Arrange
            var input = "abc123";

            // Act
            var result = input.IsNumeric();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsNumeric_NullString_ReturnsFalse()
        {
            // Arrange
            string? input = null;

            // Act
            var result = input.IsNumeric();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsNumeric_EmptyString_ReturnsFalse()
        {
            // Arrange
            var input = "";

            // Act
            var result = input.IsNumeric();

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        #region Truncate Tests

        [Fact]
        public void Truncate_StringLongerThanMaxLength_ReturnsTruncatedString()
        {
            // Arrange
            var input = "This is a very long string that needs to be truncated";
            var maxLength = 20;

            // Act
            var result = input.Truncate(maxLength);

            // Assert
            result.Should().Be("This is a very long ");
            result!.Length.Should().Be(maxLength);
        }

        [Fact]
        public void Truncate_StringShorterThanMaxLength_ReturnsOriginalString()
        {
            // Arrange
            var input = "Short string";
            var maxLength = 50;

            // Act
            var result = input.Truncate(maxLength);

            // Assert
            result.Should().Be("Short string");
        }

        [Fact]
        public void Truncate_StringEqualToMaxLength_ReturnsOriginalString()
        {
            // Arrange
            var input = "Exact";
            var maxLength = 5;

            // Act
            var result = input.Truncate(maxLength);

            // Assert
            result.Should().Be("Exact");
        }

        [Fact]
        public void Truncate_NullString_ReturnsNull()
        {
            // Arrange
            string? input = null;
            var maxLength = 10;

            // Act
            var result = input.Truncate(maxLength);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Truncate_ZeroMaxLength_ReturnsEmptyString()
        {
            // Arrange
            var input = "Some string";
            var maxLength = 0;

            // Act
            var result = input.Truncate(maxLength);

            // Assert
            result.Should().Be("");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Truncate_NegativeMaxLength_ThrowsArgumentException(int maxLength)
        {
            // Arrange
            var input = "Some string";

            // Act & Assert
            input.Invoking(x => x.Truncate(maxLength))
                 .Should().Throw<ArgumentException>()
                 .WithMessage("Max length cannot be negative*");
        }

        #endregion

        #region TruncateWithEllipsis Tests

        [Fact]
        public void TruncateWithEllipsis_LongString_ReturnsStringWithEllipsis()
        {
            // Arrange
            var input = "This is a very long string that needs truncation";
            var maxLength = 20;

            // Act
            var result = input.TruncateWithEllipsis(maxLength);

            // Assert
            result.Should().Be("This is a very lo...");
            result!.Length.Should().Be(maxLength);
        }

        [Fact]
        public void TruncateWithEllipsis_ShortString_ReturnsOriginalString()
        {
            // Arrange
            var input = "Short";
            var maxLength = 20;

            // Act
            var result = input.TruncateWithEllipsis(maxLength);

            // Assert
            result.Should().Be("Short");
        }

        [Fact]
        public void TruncateWithEllipsis_MaxLengthTooSmall_ThrowsArgumentException()
        {
            // Arrange
            var input = "Some string";
            var maxLength = 2; // Menor que "..."

            // Act & Assert
            input.Invoking(x => x.TruncateWithEllipsis(maxLength))
                 .Should().Throw<ArgumentException>()
                 .WithMessage("Max length must be at least 3 to accommodate ellipsis*");
        }

        #endregion
    }
}