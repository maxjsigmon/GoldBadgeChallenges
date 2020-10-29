using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoGreen_Repo
{
    public class VehicleRepository
    {
        public List<Vehicle> _vehicleDirectory = new List<Vehicle>();
        public List<ElectricType> _electricDirectory = new List<ElectricType>();
        public List<HybridType> _hybridDirectory = new List<HybridType>();
        public List<GasType> _gasDirectory = new List<GasType>();


        public bool AddCarToMainDirectory(Vehicle vehicle)
        {
            int startingCount = _vehicleDirectory.Count;
            _vehicleDirectory.Add(vehicle);

            bool wasAdded = (_vehicleDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool AddCarToElectricDirectory(ElectricType vehicle)
        {
            int startingCount = _electricDirectory.Count;
            _electricDirectory.Add(vehicle);

            bool wasAdded = (_electricDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool AddCarToHybridDirectory(HybridType vehicle)
        {
            int startingCount = _hybridDirectory.Count;
            _hybridDirectory.Add(vehicle);

            bool wasAdded = (_hybridDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool AddCarToGasDirectory(GasType vehicle)
        {
            int startingCount = _vehicleDirectory.Count;
            _vehicleDirectory.Add(vehicle);

            bool wasAdded = (_vehicleDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Vehicle> GetVehicles()
        {
            return _vehicleDirectory;
        }
        public List<ElectricType> GetElectricTypes()
        {
            return _electricDirectory;
        }

        public List<HybridType> GetHybridTypes()
        {
            return _hybridDirectory;
        }

        public List<GasType> GetGasTypes()
        {
            return _gasDirectory;
        }
        //public void AddToEngineTypeDirectory(Vehicle vehicle)
        //{
        //    if (vehicle.EngineType == EngineType.Electric)
        //    {
        //        _electricDirectory.Add((ElectricType)vehicle);
        //    }
        //    else if (vehicle.EngineType == EngineType.Hybrid)
        //    {
        //        _hybridDirectory.Add((HybridType)vehicle);
        //    }
        //    else
        //    {
        //        _gasDirectory.Add((GasType)vehicle);
        //    }
    }
}

