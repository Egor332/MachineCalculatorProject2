using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MachineCalculator
{
    public class MachinePowerCalculator
    {
        public double GetPowerConsumption(string machineType, int duration, bool isEnergySaving)
        {
            if (string.IsNullOrEmpty(machineType)) throw new ArgumentException("Machine type cannot be empty");
            if (duration < 0) throw new Exception("Duration must be greater than zero");
            double res = 0;
            switch (machineType)
            {
                case "Press":
                    res = 7.2 * duration;
                    break;
                case "MillingMachine":
                    res = 5.0 * duration;
                    break;
                case "Lathe":
                    res = 3.5 * Math.Log10(duration + 1);
                    break;
                default:
                    throw new ArgumentException("Invalid machine type");
                    break;
            }

            if (isEnergySaving) return res * 0.8;
            return res;
        }
    }
}
