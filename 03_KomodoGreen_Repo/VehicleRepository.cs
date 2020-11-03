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

        public bool AddElectricCarToDirectories(ElectricType vehicle)
        {
            int startingCount = _electricDirectory.Count;
            _electricDirectory.Add(vehicle);

            int mainStart = _vehicleDirectory.Count;
            _vehicleDirectory.Add(vehicle);

            bool wasAdded = (_electricDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool AddHybridCarToDirectories(HybridType vehicle)
        {
            int startingCount = _hybridDirectory.Count;
            _hybridDirectory.Add(vehicle);

            int mainStart = _vehicleDirectory.Count;
            _vehicleDirectory.Add(vehicle);

            bool wasAdded = (_hybridDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool AddGasCarToDirectories(GasType vehicle)
        {
            int startingCount = _gasDirectory.Count;
            _gasDirectory.Add(vehicle);

            int mainStart = _vehicleDirectory.Count;
            _vehicleDirectory.Add(vehicle);

            bool wasAdded = (_gasDirectory.Count > startingCount) ? true : false;
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

        public ElectricType GetElectricCarByModel(string model)
        {
            foreach (ElectricType eVehicle in _electricDirectory)
            {
                if (eVehicle.Model == model)
                {
                    return eVehicle;
                }
            }
            return null;
        }

        public List<HybridType> GetHybridTypes()
        {
            return _hybridDirectory;
        }

        public HybridType GetHybridCarByModel(string model)
        {
            foreach (HybridType hVehicle in _hybridDirectory)
            {
                if (hVehicle.Model == model)
                {
                    return hVehicle;
                }
            }
            return null;
        }

        public List<GasType> GetGasTypes()
        {
            return _gasDirectory;
        }

        public GasType GetGasCarByModel(string model)
        {
            foreach (GasType gVehicle in _gasDirectory)
            {
                if (gVehicle.Model == model)
                {
                    return gVehicle;
                }
            }
            return null;
        }

        public bool DeleteVehicle(Vehicle modelToUpdate)
        {
            int startingCount = _vehicleDirectory.Count;
            _vehicleDirectory.Remove(modelToUpdate);

            bool wasDeleted = (_vehicleDirectory.Count < startingCount) ? true : false;
            return wasDeleted;
        }

        public bool DeleteElectricVehicleInfo(ElectricType modelToUpdate)
        {
            int startingCount = _electricDirectory.Count;
            _electricDirectory.Remove(modelToUpdate);

            bool wasDeleted = (_electricDirectory.Count < startingCount) ? true : false;
            return wasDeleted;
        }
        public bool DeleteHybridVehicleInfo(HybridType modelToUpdate)
        {
            int startingCount = _hybridDirectory.Count;
            _hybridDirectory.Remove(modelToUpdate);


            bool wasDeleted = (_hybridDirectory.Count < startingCount) ? true : false;
            return wasDeleted;

        }
        public bool DeleteGasVehicleInfo(GasType modelToUpdate)
        {
            int startingCount = _gasDirectory.Count;
            _gasDirectory.Remove(modelToUpdate);


            bool wasDeleted = (_gasDirectory.Count < startingCount) ? true : false;
            return wasDeleted;
        }
    }
}

