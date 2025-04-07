using MachineCalculator;

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
            Assert.Throws<ArgumentException>(() => _powerCalculator.GetPowerConsumption(machineType, duration, isEnergySaving));
        }

        [Fact]
        public void GetPowerConsumption_WithDurationLessThenZero_ShouldTroughException()
        {
            // Arrange
            var machineType = "aa";
            var duration = -1;
            var isEnergySaving = false;

            // Act and assert           
            Exception ex =  Assert.Throws<ArgumentException>(() => _powerCalculator.GetPowerConsumption(machineType, duration, isEnergySaving));
            Assert.Equal("Duration must be greater than zero", ex.Message);
        }




    }
}