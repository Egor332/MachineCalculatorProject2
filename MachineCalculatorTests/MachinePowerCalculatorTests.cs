using MachineCalculator;
using System.ComponentModel.DataAnnotations;

namespace MachineCalculatorTests
{
    public class MachinePowerCalculatorTests
    {
        private readonly MachinePowerCalculator _powerCalculator;

        public MachinePowerCalculatorTests()
        {
            _powerCalculator = new MachinePowerCalculator();
        }

        [Fact]
        public void GetPowerConsumption_WithMachineTypeNullOrEmpty_ShouldTroughArgumentException()
        {
            // Arrange
            var machineType = "";
            var duration = 2;
            var isEnergySaving = false;

            // Act and assert           
            ArgumentException ex = Assert.Throws<ArgumentException>(() => _powerCalculator.GetPowerConsumption(machineType, duration, isEnergySaving));
            Assert.Equal("Machine type cannot be empty", ex.Message);
        }

        [Fact]
        public void GetPowerConsumption_WithDurationLessThenZero_ShouldTroughException()
        {
            // Arrange
            var machineType = "Press";
            var duration = -1;
            var isEnergySaving = false;

            // Act and assert           
            Exception ex =  Assert.Throws<Exception>(() => _powerCalculator.GetPowerConsumption(machineType, duration, isEnergySaving));
            Assert.Equal("Duration must be greater than zero", ex.Message);
        }

        [Fact]
        public void GetPowerConsumption_WithUnknownMachine_ShouldTroughException()
        {
            // Arrange
            var machineType = "Unknown";
            var duration = 1;
            var isEnergySaving = false;

            // Act and assert           
            ArgumentException ex = Assert.Throws<ArgumentException>(() => _powerCalculator.GetPowerConsumption(machineType, duration, isEnergySaving));
            Assert.Equal("Invalid machine type", ex.Message);
        }

        [Fact]
        public void GetPowerConsumption_ForPress_ShouldReturnLinearResult()
        {
            // Arrange
            var machineType = "Press";
            var duration1 = 5;
            var duration2 = duration1 * 2;
            var isEnergySaving = false;

            // Act 
            var result1 = _powerCalculator.GetPowerConsumption(machineType, duration1, isEnergySaving);
            var result2 = _powerCalculator.GetPowerConsumption(machineType, duration2, isEnergySaving);

            // Assert
            Assert.Equal(result1 * 2, result2);
        }

        [Fact]
        public void GetPowerConsumption_ForMillingMachine_ShouldReturnLinearResult()
        {
            // Arrange
            var machineType = "Press";
            var duration1 = 5;
            var duration2 = duration1 * 2;
            var isEnergySaving = false;

            // Act 
            var result1 = _powerCalculator.GetPowerConsumption(machineType, duration1, isEnergySaving);
            var result2 = _powerCalculator.GetPowerConsumption(machineType, duration2, isEnergySaving);

            // Assert
            Assert.Equal(result1 * 2, result2);
        }

        [Fact]
        public void GetPowerConsumption_ForLathe_ShouldBeLogarithmic()
        {
            // Arrange
            var machineType = "Lathe";
            var duration = 5;
            var isEnergySaving = false;
            var expected = 3.5 * Math.Log10(duration + 1);

            // Act 
            var result = _powerCalculator.GetPowerConsumption(machineType, duration, isEnergySaving);

            // Assert
            Assert.Equal(result, duration);
        }

        [Theory]
        [InlineData("Press")]
        [InlineData("Lathe")]
        public void GetPowerConsumption_WithEnergySaving_ShouldReduceConsumptionBy80(string machineType)
        {
            // Arrange
            var duration = 10;

            // Act 
            var result1 = _powerCalculator.GetPowerConsumption(machineType, duration, true);
            var result2 = _powerCalculator.GetPowerConsumption(machineType, duration, false);

            // Assert
            Assert.Equal(result1, result2 * 0.8);
        }


    }
}