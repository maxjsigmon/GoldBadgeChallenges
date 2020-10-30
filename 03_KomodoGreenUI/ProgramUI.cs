﻿using _03_KomodoGreen_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _03_KomodoGreenUI
{
    class ProgramUI
    {
        private VehicleRepository _repo = new VehicleRepository();
        
        public void Run()
        {
            SeedVehicle();
            Menu();
        }

        private void SeedVehicle()
        {
            ElectricType teslaS = new ElectricType(
                "Tesla",
                "Model S",
                2020,
                EngineType.Electric,
                340,
                20);
            GasType mustang = new GasType(
                "Ford",
                "Mustang",
                2021,
                EngineType.Gas,
                19);
            HybridType prius = new HybridType(
                "Toyota",
                "Prius",
                2019,
                EngineType.Hybrid,
                55);

            _repo.AddCarToMainDirectory(teslaS);
            _repo.AddCarToElectricDirectory(teslaS);
            _repo.AddCarToMainDirectory(mustang);
            _repo.AddCarToMainDirectory(prius);
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please select an option:\n" +
                    "1. Show all vehicles\n" +
                    "2. Go to the Electric Vehicle menu\n" +
                    "3. Go to the Hybrid Vehicle Menu\n" +
                    "4. Go to the Gas Vehicle Menu\n" +
                    "5. Exit\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllVehicles();
                        break;
                    case "2":
                        ElectricVehicleMenu();
                        break;
                    //case "3":
                    //    HybridVehicleMenu();
                    //    break;
                    //case "4":
                    //    GasVehicleMenu();
                    //    break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }

            }
        }
        private void ShowAllVehicles()
        {
            List<Vehicle> listOfVehicles = _repo.GetVehicles();
            foreach (Vehicle vehicle in listOfVehicles)
            {
                DisplayVehicle(vehicle);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void DisplayVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"Make: {vehicle.Make}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Year: {vehicle.Year}");
            Console.WriteLine($"Engine Type: {vehicle.EngineType}");

            if (vehicle.EngineType == EngineType.Electric)
            {
                ElectricType electric = (ElectricType)vehicle;
                Console.WriteLine($"Driving Range: {electric.DrivingRange}\n" +
                                  $"Charging Time (Minutes): {electric.ChargingTime}");
                Console.WriteLine("------------------------------------");
            }
            if (vehicle.EngineType == EngineType.Hybrid)
            {
                HybridType hybrid = (HybridType)vehicle;
                Console.WriteLine($"Gas Milage: {hybrid.MilesPerGallon}mpg");
                Console.WriteLine("------------------------------------");
            }
            if (vehicle.EngineType == EngineType.Gas)
            {

                GasType gas = (GasType)vehicle;
                Console.WriteLine($"Gas Milage: {gas.MilesPerGallon}mpg");
                Console.WriteLine("------------------------------------");
            }
        }

        public void ElectricVehicleMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Electric Vehicle Menu.\n" +
                    "Please select an option:\n" +
                    "1. See all Electric Vehicles\n" +
                    "2. Add an Electric Vehicle\n" +
                    "3. Update an Electric Vehicle\n" +
                    "4. Delete an Electric Vehicle\n" +
                    "5. Return to main menu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowElectricVehicles();
                        break;
                    case "2":
                        AddAnElectricVehicle();
                        break;
                    case "3":
                        UpdateAnElectricVehicle();
                        break;
                    case "4":
                        DeleteElectricVehicle();
                        break;
                    case "5":
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }
        }
        private void ShowElectricVehicles()
        {
            List<ElectricType> electricTypes = _repo.GetElectricTypes();
            foreach (ElectricType vehicle in electricTypes)
            {
                DisplayElectricVehicle(vehicle);
            }
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
        }

        private void DisplayElectricVehicle(ElectricType vehicle)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Make: {vehicle.Make}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Year: {vehicle.Year}");
            Console.WriteLine($"Engine Type: {vehicle.EngineType}");
            Console.WriteLine($"Driving Range: {vehicle.DrivingRange}");
            Console.WriteLine($"Charging Time (Minutes): {vehicle.ChargingTime}");                 
        }

        private void AddAnElectricVehicle()
        {
            ElectricType newEVehicle = new ElectricType();

            Console.WriteLine("Please enter a make for the car");
            newEVehicle.Make = Console.ReadLine();

            Console.WriteLine("Please enter a model for the car");
            newEVehicle.Model = Console.ReadLine();

            Console.WriteLine("Please enter a year for the car");
            string yearAsString = Console.ReadLine();
            int yearAsInt = int.Parse(yearAsString);
            newEVehicle.Year = yearAsInt;

            Console.WriteLine("Please select an engine type for the car");
            Console.WriteLine("1. Electric");
            Console.WriteLine("2. Hybrid");
            Console.WriteLine("3. Gas");
            string engineTypeInput = Console.ReadLine();
            int engineTypeAsInt = int.Parse(engineTypeInput);
            newEVehicle.EngineType = (EngineType)engineTypeAsInt;

            Console.WriteLine("Please enter a driving range");
            string distanceInput = Console.ReadLine();
            int distanceAsInt = int.Parse(distanceInput);
            newEVehicle.DrivingRange = distanceAsInt;

            Console.WriteLine("Please enter a charging time (in minutes)");
            string timeInput = Console.ReadLine();
            int timeAnInt = int.Parse(timeInput);
            newEVehicle.ChargingTime = timeAnInt;

            bool wasAdded = _repo.AddCarToElectricDirectory(newEVehicle);
            if (wasAdded == true)
            {
                Console.WriteLine("Your car was added");
            }
            else
            {
                Console.WriteLine("Add unsuccessful");
            }

        }
        private void UpdateAnElectricVehicle()
        {
            ShowElectricVehicles();
            Console.WriteLine("Select a model you would like to update");
            string modelToUpdate = Console.ReadLine();

            ElectricType vehicleToUpdate = _repo.GetElectricCarByModel(modelToUpdate);

            ElectricType updatedVehicle = new ElectricType();

            Console.WriteLine("Please enter a make");
            updatedVehicle.Make = Console.ReadLine();

            Console.WriteLine("Please enter a model");
            updatedVehicle.Model = Console.ReadLine();

            Console.WriteLine("Please enter a year");
            string yearAsString = Console.ReadLine();
            int yearAsInt = int.Parse(yearAsString);
            updatedVehicle.Year = yearAsInt;

            Console.WriteLine("Please enter a driving range");
            string distanceInput = Console.ReadLine();
            int distanceAsInt = int.Parse(distanceInput);
            updatedVehicle.DrivingRange = distanceAsInt;

            Console.WriteLine("Please enter a charging time");
            string timeInput = Console.ReadLine();
            int timeAnInt = int.Parse(timeInput);
            updatedVehicle.ChargingTime = timeAnInt;

            bool oldInfoRemoved = _repo.DeleteElectricVehicleInfo(vehicleToUpdate);
            if (oldInfoRemoved == true)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

            bool wasUpdated = _repo.AddCarToElectricDirectory(updatedVehicle);
            if (wasUpdated == true)
            {
                Console.WriteLine("Your car was updated");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        private void DeleteElectricVehicle()
        {
            ShowElectricVehicles();
            Console.WriteLine("Which vehicle would you like to remove? Please enter the model name");
            string modelToRemove = Console.ReadLine();

            ElectricType vehicleToRemove = _repo.GetElectricCarByModel(modelToRemove);

            bool carRemoved = _repo.DeleteElectricVehicleInfo(vehicleToRemove);
            if (carRemoved == true)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
