using ChangeCalculatorService;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChangeCalculatorTest
{
    public class CalculatorServiceTest
    {
        [Fact]
        public void CalculateChange_EnterAmount_ReturnsTrue()
        {
            // Arrange
            string amount = "100.00";

            // Act
            CalculatorService service = new CalculatorService();
            List<string> changes = service.CalculateChange(amount);

            // Assert
            Assert.True(changes.Count > 0);
        }

        [Fact]
        public void CalculateChange_EnterCharacters_ThrowsException()
        {
            // Arrange
            string amount = "Test";
            CalculatorService service = new CalculatorService();

            // Assert
            Assert.Throws<FormatException>(() => service.CalculateChange(amount));
        }

        [Fact]
        public void CalculateChange_EnterAmount_ReturnsValidChange()
        {
            // Arrange
            string amount = "100.80";
            int expectedCount = 4;
            CalculatorService service = new CalculatorService();

            // Act
            List<string> changes = service.CalculateChange(amount);

            // Assert
            Assert.Equal(expectedCount, changes.Count);
        }
    }
}
