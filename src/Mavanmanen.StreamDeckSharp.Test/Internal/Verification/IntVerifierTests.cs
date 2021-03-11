using System;
using Mavanmanen.StreamDeckSharp.Internal.Verification;
using Xunit;

namespace Mavanmanen.StreamDeckSharp.Test.Internal.Verification
{
    [Trait("Category", "Unit Tests")]
    public class IntVerifierTests
    {
        private static IntVerifier<VerificationTestClass> CreateIntVerifier(VerificationTestClass instance)
        {
            return new IntVerifier<VerificationTestClass>(instance, x => x.IntProperty);
        }

        [Fact]
        public void Min_PropertyLowerThanMin_Fails()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                IntProperty = -1
            };

            IntVerifier<VerificationTestClass> sut = CreateIntVerifier(testClass);

            // Act & Assert
            Assert.Throws<Exception>(() => sut.Min(0));
        }

        [Fact]
        public void Min_PropertyHigherThanMin_Passes()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                IntProperty = 1
            };

            IntVerifier<VerificationTestClass> sut = CreateIntVerifier(testClass);

            // Act
            Exception exception = Record.Exception(() => sut.Min(0));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Max_PropertyHigherThanMax_Fails()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                IntProperty = 5
            };

            IntVerifier<VerificationTestClass> sut = CreateIntVerifier(testClass);

            // Act & Assert
            Assert.Throws<Exception>(() => sut.Max(1));
        }

        [Fact]
        public void Max_PropertyLowerThanMax_Passes()
        {
            // Arrange
            var testClass = new VerificationTestClass
            {
                IntProperty = 5
            };

            IntVerifier<VerificationTestClass> sut = CreateIntVerifier(testClass);

            // Act
            Exception exception = Record.Exception(() => sut.Max(10));

            // Assert
            Assert.Null(exception);
        }
    }
}
