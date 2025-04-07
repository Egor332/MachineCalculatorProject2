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
            var duaration = 2;
            var isEnergySaving = false;

            // Act and assert           
            Assert.Throws<ArgumentException>(() => _powerCalculator.GetPowerConsumption(machineType, duaration, isEnergySaving));
        }


    
    }
}