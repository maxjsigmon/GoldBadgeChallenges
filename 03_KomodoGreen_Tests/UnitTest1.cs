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
            ElectricType vehicle = new ElectricType();
            VehicleRepository repository = new VehicleRepository();

            bool addVehicle = repository.AddElectricCarToDirectories(vehicle);

            Assert.IsTrue(addVehicle);
        }
    }
}
