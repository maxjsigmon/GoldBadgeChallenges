using _02_KIClaims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02_KIClaimsUI
{
    class ProgramUI
    {
        private ClaimRepo _repository = new ClaimRepo();
        
        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void SeedContent()
        {
            Claims claimId1 = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00, new DateTime (2018, 4, 25), new DateTime (2018, 4, 27));

            Claims claimId2 = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00, new DateTime(2018, 4,11), new DateTime(2018, 4, 12));

            Claims claimId3 = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));

            _repository.EnqueueNewClaim(claimId1);
            _repository.EnqueueNewClaim(claimId2);
            _repository.EnqueueNewClaim(claimId3);
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Insurance Claims Menu\n"+
                    "-----------------------------\n"+
                    "Please select an option\n"+
                    "1. See all claims\n"+
                    "2. Take care of next claim\n"+
                    "3. Enter a new claim");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    //case "2":
                    //    GetNextClaim();
                    //    break;
                    case "3":
                        EnterNewClaim();
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
            }
        }

        public void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claims> listOfClaims = _repository.GetClaims();

            foreach(Claims claim in listOfClaims)
            {
                DisplayClaims(claim);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayClaims(Claims claim)
        {

            Console.WriteLine($"Claim ID: {claim.ClaimID}");
            Console.WriteLine($"Type: {claim.ClaimType}");
            Console.WriteLine($"Description: {claim.Description}");
            Console.WriteLine($"Amount: {claim.ClaimAmount.ToString("C2")}");
            Console.WriteLine($"Date of Incident: {claim.DateOfIncident.ToString("MM/dd/yy")}");
            Console.WriteLine($"Date of Claim: {claim.DateOfClaim.ToString("MM/dd/yy")}");
            Console.WriteLine($"IsValid {claim.IsValid}");
            Console.WriteLine("---------------------------------------------");
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Enter a claim number");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);
            newClaim.ClaimAmount = idAsInt;

            bool stopRunning = false;
            while (!stopRunning)
            {
                Console.WriteLine("Enter a Claim Type");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Home");
                Console.WriteLine("3. Theft");

                string claimType = Console.ReadLine();

                switch (claimType)
                {
                    case "1":
                    newClaim.ClaimType = ClaimType.Car;
                        stopRunning = true;
                        break;
                    case "2":
                        newClaim.ClaimType = ClaimType.Home;
                        stopRunning = true;
                        break;
                    case "3":
                        newClaim.ClaimType = ClaimType.Theft;
                        stopRunning = true;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
            }

            Console.WriteLine("Enter a description");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter a claim amount");
            string amountAsString = Console.ReadLine();
            double amountAsDouble = double.Parse(amountAsString);
            newClaim.ClaimAmount = amountAsDouble;

            Console.WriteLine("Enter a date for the incident");
            string dateAsString = Console.ReadLine();
            DateTime dateAsDateTime = DateTime.Parse(dateAsString);
            newClaim.DateOfIncident = dateAsDateTime;

            Console.WriteLine("Enter a date for the claim");
            string claimDateAsString = Console.ReadLine();
            DateTime claimDateAsDateTime = DateTime.Parse(claimDateAsString).Date;
            newClaim.DateOfClaim = claimDateAsDateTime;

            bool wasAdded = _repository.EnqueueNewClaim(newClaim);
            if (wasAdded == true)
            {
                Console.WriteLine("Your claim was added");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
