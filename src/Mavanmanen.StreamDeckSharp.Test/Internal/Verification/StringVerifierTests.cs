using System;
using Mavanmanen.StreamDeckSharp.Internal.Verification;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.Verification
{
    [Trait("Category", "Unit Tests")]
    public class StringVerifierTests
    {
        private static StringVerifier<VerificationTestClass> CreateStringVerifier(VerificationTestClass instance)
        {
            return new StringVerifier<VerificationTestClass>(instance, x => x.StringProperty);
        }

        [Fact]
        public void NotNull_PropertyIsNull_Fails()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                StringProperty = null
            };

            StringVerifier<VerificationTestClass> sut = CreateStringVerifier(testClass);

            // Act & Assert
            Assert.Throws<Exception>(() => sut.NotNull());
        }

        [Fact]
        public void NotEmpty_PropertyIsEmpty_Fails()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                StringProperty = string.Empty
            };

            StringVerifier<VerificationTestClass> sut = CreateStringVerifier(testClass);

            // Act & Assert
            Assert.Throws<Exception>(() => sut.NotEmpty());
        }

        [Fact]
        public void NotEmpty_PropertyIsNull_Passes()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                StringProperty = null
            };

            StringVerifier<VerificationTestClass> sut = CreateStringVerifier(testClass);

            // Act
            Exception exception = Record.Exception(() => sut.NotEmpty());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Regex_PropertyDoesntMatchPattern_Fails()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                StringProperty = "blabla"
            };

            StringVerifier<VerificationTestClass> sut = CreateStringVerifier(testClass);

            // Act & Assert
            Assert.Throws<Exception>(() => sut.Regex(@"\d+"));
        }

        [Fact]
        public void Regex_PropertyMatchesPattern_Passes()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                StringProperty = "123"
            };

            StringVerifier<VerificationTestClass> sut = CreateStringVerifier(testClass);

            // Act
            Exception exception = Record.Exception(() => sut.Regex(@"\d+"));

            // Assert
            Assert.Null(exception);
        }
    }
}