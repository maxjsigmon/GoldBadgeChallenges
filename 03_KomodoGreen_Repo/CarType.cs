using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoGreen_Repo
{
    public class ElectricType : Vehicle
    {
        public int DrivingRange { get; set; }
        public int ChargingTime { get; set; }
        public ElectricType() { }
        public ElectricType(string make, string model, int year, EngineType engineType, int drivingRange, int chargingTime)
            : base(make, model, year, engineType)
        {
            DrivingRange = drivingRange;
            ChargingTime = chargingTime;
        }
    }

    public class HybridType : Vehicle
    {
        public int MilesPerGallon { get; set; }
        public HybridType() { }
        public HybridType(string make, string model, int year, EngineType engineType, int milesPerGallon)
            : base(make, model, year, engineType)
        {
            MilesPerGallon = milesPerGallon;
        }
    }

    public class GasType : Vehicle
    {
        public int MilesPerGallon { get; set; }
        public GasType() { }
        public GasType(string make, string model, int year, EngineType engineType, int milesPerGallon)
            : base(make, model, year, engineType)
        {
            MilesPerGallon = milesPerGallon;
        }
    }
}
