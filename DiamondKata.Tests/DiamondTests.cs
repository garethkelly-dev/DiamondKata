using System;
using Shouldly;
using Xunit;

namespace DiamondKata.Tests
{
    public class DiamondTests
    {
        private readonly Diamond _sut;

        public DiamondTests()
        {
            _sut = new Diamond();
        }

        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('z')]
        [InlineData(' ')]
        [InlineData('!')]
        [InlineData('/')]
        public void Create_Invalid_Input_Should_Throw_Exception(char character)
        {
            // Arrange
            Action action = () => _sut.Create(character);

            // Act
            // Assert
            action.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('Z')]
        public void Create_Valid_Input_Should_Not_Throw_Exception(char character)
        {
            // Arrange
            Action action = () => _sut.Create(character);

            // Act
            // Assert
            action.ShouldNotThrow();
        }

        [Fact]
        public void Create_Input_A_Should_Return_Diamond()
        {
            // Arrange
            var expected = "A";

            // Act
            var result = _sut.Create('A');

            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void Create_Input_B_Should_Return_Diamond()
        {
            // Arrange
            var expected = $" A {Environment.NewLine}" +
                                 $"B B{Environment.NewLine}" +
                                 $" A ";

            // Act
            var result = _sut.Create('B');

            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void Create_Input_C_Should_Return_Diamond()
        {
            // Arrange
            var expected = $"  A  {Environment.NewLine}" +
                                 $" B B {Environment.NewLine}"+
                                 $"C   C{Environment.NewLine}" +
                                 $" B B {Environment.NewLine}" +
                                 $"  A  ";

            // Act
            var result = _sut.Create('C');

            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void Create_Input_D_Should_Return_Diamond()
        {
            // Arrange
            var expected= $"   A   {Environment.NewLine}" +
                                $"  B B  {Environment.NewLine}" +
                                $" C   C {Environment.NewLine}" +
                                $"D     D{Environment.NewLine}" +
                                $" C   C {Environment.NewLine}" +
                                $"  B B  {Environment.NewLine}" +
                                $"   A   ";

            // Act
            var result = _sut.Create('D');

            // Assert
            result.ShouldBe(expected);
        }
    }
}
