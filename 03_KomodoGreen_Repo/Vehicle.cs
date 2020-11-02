using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoGreen_Repo
{
    public enum EngineType { Electric = 1, Hybrid, Gas }
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public EngineType EngineType { get; set; }
        public Vehicle() { }
        public Vehicle(string make, string model, int year, EngineType engineType)
        {
            Make = make;
            Model = model;
            Year = year;
            EngineType = engineType;
        }
    }
}
