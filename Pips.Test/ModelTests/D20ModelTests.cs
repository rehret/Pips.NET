using System;
using System.Collections.Generic;
using System.Linq;
using Pips.Models;
using Pips.Test.Extensions;
using Xunit;

namespace Pips.Test.ModelTests
{
    public class D20ModelTests
    {
        readonly Type d20Type = typeof(D20);

        [Fact]
        public void ValidateD20ModelProperties()
        {
            Assert.Equal(3, d20Type.GetProperties().Length);

            Assert.True(d20Type.HasPropertyOfType<int>("NumDice"));
            Assert.True(d20Type.HasPropertyOfType<int>("NumSides"));
            Assert.True(d20Type.HasPropertyOfType<IEnumerable<int>>("Rolls"));
        }

        [Fact]
        public void ValidateThatIntConstructorSetsPropertiesCorrectly()
        {
            // Arrange
            var numDice = 3;
            var numSides = 6;

            // Act
            var d20 = new D20(numDice, numSides);

            // Assert
            Assert.Equal(numDice, d20.NumDice);
            Assert.Equal(numSides, d20.NumSides);
        }

        [Theory]
        [InlineData(-1, 6)]
        [InlineData(5, -1)]
        [InlineData(-5, -5)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void ValidateThatIntConstructorThrowsExceptionForInvalidParameters(int numDice, int numSides)
        {
            // Act & Assert
            Assert.Throws<Exception>(() => new D20(numDice, numSides));
        }

        [Fact]
        public void ValidateThatStringConstructorSetsPropertiesCorrectly()
        {
            // Arrange
            var d20string = "3d6";

            // Act
            var d20 = new D20(d20string);

            // Assert
            Assert.Equal(3, d20.NumDice);
            Assert.Equal(6, d20.NumSides);
        }

        [Theory]
        [InlineData("invalid")]
        [InlineData("1d")]
        [InlineData("d1")]
        [InlineData("1d1d")]
        [InlineData("d1d1")]
        [InlineData("-1d10")]
        [InlineData("1d-10")]
        [InlineData("0d5")]
        [InlineData("5d0")]
        public void ValidateThatStringConstructorThrowsExceptionWhenGivenInvalidD20String(string d20string)
        {
            // Act & Assert
            Assert.Throws<Exception>(() => new D20(d20string));
        }

        [Theory]
        [InlineData(1, 6)]
        [InlineData(2, 5)]
        [InlineData(10, 10)]
        [InlineData(1, 1)]
        public void ValidateThatRollsReturnsValidRolls(int numDice, int numSides)
        {
            // Arrange
            var d20 = new D20(numDice, numSides);

            // Act
            var rolls = d20.Rolls;

            // Assert
            Assert.Equal(numDice, rolls.Count());
            Assert.True(rolls.All(roll => roll >= 1 && roll <= numSides));
        }

        [Fact]
        public void ValidateThatRollsAreDifferentEachTime()
        {
            // Arrange
            var numDice = 100;
            var numSides = 100;
            var d20 = new D20(numDice, numSides);

            // Act
            var firstRolls = d20.Rolls;
            var secondRolls = d20.Rolls;

            // Assert
            Assert.False(firstRolls.SequenceEqual(secondRolls));
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(1, 1)]
        [InlineData(25, 1)]
        [InlineData(100, 5)]
        [InlineData(7, 2)]
        public void ValidateThatDiceIsRolledCorrectNumberOfTimes(int numDice, int numSides)
        {
            // Arange
            var d20 = new D20(numDice, numSides);

            // Act
            var rolls = d20.Rolls;

            //Assert
            Assert.Equal(numDice, rolls.Count());
        }
    }
}
