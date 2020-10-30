using _01_KomodoCafe_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    class ProgramUI
    {
        //private MenuRepository _foodMenu = new MenuRepository();
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Please select an option:\n" +
                    "1. Display entire menu\n" +
                    "2. Add a food item\n" +
                    "3. Update an item\n" +
                    "4. Delete an item\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllFood();
                        break;
                    case "2":
                        AddAFoodItem();
                        break;
                        case "3":
                            UpdateAnItem();
                            break;
                        case "4":
                            DeleteAnItem();
                            break;
                        case "5":
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please select a valid option");
                            break;
                }
            }
        }
        public void ShowAllFood()
        {
            Console.Clear();
            List<Menu> listOfFood = _repo.SeeAllFood();

            foreach (Menu foodItems in listOfFood)
            {
                DisplayAllFood(foodItems);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void AddAFoodItem()
        {
            Console.Clear();

            Menu newFood = new Menu(_repo.GetNewFoodNumber());

            Console.WriteLine("Please, enter a name for the item.");
            newFood.MealName = Console.ReadLine();

            Console.WriteLine("Please, enter a description for the item.");
            newFood.Description = Console.ReadLine();

            Console.WriteLine("Please, enter a price for the item.");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = double.Parse(priceAsString);
            newFood.Price = priceAsDouble;

            Console.WriteLine("Please, enter the ingredients for the item.");
            newFood.Ingredients = Console.ReadLine();

            bool wasAdded = _repo.AddFoodToMenu(newFood);
            if (wasAdded == true)
            {
                Console.WriteLine("Your food was added to the menu.");
            }
            else
            {
                Console.WriteLine("Something went wrong. You food was not added.");
            }
        }

        private void UpdateAnItem()
        {
            ShowAllFood();
            Console.WriteLine("Select which item you would like to update:");
            string foodToUpdate = Console.ReadLine();

            Menu itemsToUpdate = _repo.GetFoodItemsByName(foodToUpdate);
            Menu updatedFood = new Menu();

            Console.WriteLine("Please enter a new name.");
            updatedFood.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a new description.");
            updatedFood.Description = Console.ReadLine();

            Console.WriteLine("Please enter a new price.");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = double.Parse(priceAsString);
            updatedFood.Price = priceAsDouble;
            

            Console.WriteLine("Please enter a new list of ingredients.");
            updatedFood.Ingredients = Console.ReadLine();

            bool oldInfoRemoved = _repo.DeleteExistingFoodItems(itemsToUpdate);
            if (oldInfoRemoved == true)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

            bool wasUpdated = _repo.AddFoodToMenu(updatedFood);
            if (wasUpdated == true)
            {
                Console.WriteLine("Your item was updated.");
            }
            else
            {
                Console.WriteLine("Your item was not updated. Please try again.");
            }

        }

        private void DeleteAnItem()
        {
            ShowAllFood();

            Console.WriteLine("Please, select an item to remove:");
            string itemToDelete = Console.ReadLine();

            Menu foodToDelete = _repo.GetFoodItemsByName(itemToDelete);
            bool wasDeleted = _repo.DeleteExistingFoodItems(foodToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("This item could not be deleted.");
            }

        }

        private void DisplayAllFood(Menu foodItems)
        {
            Console.WriteLine($"Menu Item: {foodItems.MealName}");
            Console.WriteLine($"Menu Number: {foodItems.MealNumber}");
            Console.WriteLine($"Description: {foodItems.Description}");
            Console.WriteLine($"Price: {foodItems.Price}");
            Console.WriteLine($"Ingredients: {foodItems.Ingredients}");
        }
    }
}


