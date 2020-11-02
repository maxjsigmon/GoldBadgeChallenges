using _04_KomodoOutings_Repo;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _04_KomodoOutingsUI
{
    class ProgramUI
    {
        private OutingsRepo outingsRepo = new OutingsRepo();
        public void Run()
        {
            SeedEvents();
            Menu();
        }

        private void SeedEvents()
        {
            Outings outing1 = new Outings(EventType.Bowling, 25, new DateTime(2020, 10, 26), 9.75);
            outingsRepo.AddOuting(outing1);
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please select an option\n" +
                "1. See all outings\n" +
                "2. Add an outing\n" +
                "3. Calculations");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        AddNewOuting();
                        break;
                    case "3":
                        CalculationsMenu();
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllOutings()
        {
            Console.Clear();
            List<Outings> listOfOutings = outingsRepo.SeeAllOutings();
            foreach (Outings outings in listOfOutings)
            {
                DisplayOutings(outings);
            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }

        private void DisplayOutings(Outings outings)
        {
            Console.WriteLine($"Event Type: {outings.EventType}");
            Console.WriteLine($"Number of Attendees: {outings.NumberOfAttendees}");
            Console.WriteLine($"Date: {outings.Date.ToString("MM/dd/yy")}");
            Console.WriteLine($"Cost per person: {outings.CostPerPerson.ToString("C2")}");
            Console.WriteLine($"Total Cost: {outings.TotalCost.ToString("C2")}");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
        }

        private void AddNewOuting()
        {
            Console.Clear();
            Outings newOuting = new Outings();
            Console.WriteLine("Select an event type");
            Console.WriteLine("1. Golf");
            Console.WriteLine("2. Bowling");
            Console.WriteLine("3. Amusement Park");
            Console.WriteLine("4. Concert");
            string outingTypeInput = Console.ReadLine();
            int outingTypeAsInt = int.Parse(outingTypeInput);
            newOuting.EventType = (EventType)outingTypeAsInt;

            Console.WriteLine("Enter the number of attendees");
            string attendeeInput = Console.ReadLine();
            int attendeesAsInt = int.Parse(attendeeInput);
            newOuting.NumberOfAttendees = attendeesAsInt;

            Console.WriteLine("Enter a date for the event");
            string dateAsString = Console.ReadLine();
            DateTime dateAsDateTime = DateTime.Parse(dateAsString);
            newOuting.Date = dateAsDateTime;

            Console.WriteLine("Enter a cost per person");
            string amountAsString = Console.ReadLine();
            double amountAsDouble = double.Parse(amountAsString);
            newOuting.CostPerPerson = amountAsDouble;

            bool wasAdded = outingsRepo.AddOuting(newOuting);
            if (wasAdded == true)
            {
                Console.WriteLine("Your event was added");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }


        private void CalculationsMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select an option\n" +
               "1. Calculate total for all events\n" +
               "2. Calculate total for golf outings\n" +
               "3. Calculate total for bowling outings\n" +
               "4. Calculate total for amusement park outings\n" +
               "5. Calculate total for concert outings\n" +
               "6. Exit\n");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AllEventsTotal();
                    break;
                //case "2":
                //    ??;
                //    break;
                //case "3":
                //    ??;
                //    break;
                //case "4":
                //    ??;
                //    break;
                //case "5":
                //    ??;
                //    break;
                //case "6":
                //    ??;
                //    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    break;

            }
        }
        private void DisplayAllCosts(Outings outings)
        {
            Console.WriteLine($"Total: {outings.TotalCost}");
        }

        private void AllEventsTotal()
        {
            Console.Clear();
            List<Outings> totalCosts = outingsRepo.GetAllOutingsTotal();
            foreach (Outings costs in totalCosts)
            {
                DisplayAllCosts(costs);
            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
    }
}
