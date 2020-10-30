using System;
using _03_KomodoGreen_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KomodoGreen_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddVehicleToEngineType_ShouldReturnTrue()
        {
            ElectricType eVehicle = new ElectricType();
            HybridType hVehicle = new HybridType();
            GasType gVehicle = new GasType();
            VehicleRepository repository = new VehicleRepository();

            bool addEVehicle = repository.AddElectricCarToDirectories(eVehicle);
            bool addHVehicle = repository.AddHybridCarToDirectories(hVehicle);
            bool addGVehicle = repository.AddGasCarToDirectories(gVehicle);

            Assert.IsTrue(addEVehicle);
            Assert.IsTrue(addHVehicle);
            Assert.IsTrue(addGVehicle);
        }

        [TestMethod]
        public void DeleteCarInfo_ShouldReturnTrue()
        {
            VehicleRepository repo = new VehicleRepository();
            ElectricType eVehicle = new ElectricType("Tesla", "Model X", 2020, EngineType.Electric, 300, 90);
            repo.AddElectricCarToDirectories(eVehicle);

            ElectricType oldEVehicle = repo.GetElectricCarByModel("Model X");

            bool removeEVehicle = repo.DeleteElectricVehicleInfo(oldEVehicle);

            Assert.IsTrue(removeEVehicle);

            GasType gVehicle = new GasType("Ford", "Mustang", 2020, EngineType.Gas, 19);
            repo.AddGasCarToDirectories(gVehicle);

            GasType oldGVehicle = repo.GetGasCarByModel("Mustang");
            bool removeGVehicle = repo.DeleteGasVehicleInfo(oldGVehicle);

            Assert.IsTrue(removeGVehicle);
        }

        [TestMethod]
        public void GetCarByModel_ShouldReturnCorrectName()
        {
            VehicleRepository repo = new VehicleRepository();
            GasType vehicle = new GasType("Ford", "Mustang", 1999, EngineType.Gas, 15);
            repo.AddGasCarToDirectories(vehicle);
            string model = "Mustang";

            GasType searchResult = repo.GetGasCarByModel(model);

            Assert.AreEqual(searchResult.Model, model);

        }
    }
}
