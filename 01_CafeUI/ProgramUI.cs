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
        private FoodMenu _foodMenu = new FoodMenu();

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
                    "1. Display entire menu \n" +
                    "2. Add a food item \n" +
                    "3. Update an item \n" +
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
            List<FoodItems> listOfFood = _foodMenu.SeeAllFood();

            foreach (FoodItems foodItems in listOfFood)
            {
                DisplayAllFood(foodItems);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void AddAFoodItem()
        {
            Console.Clear();

            FoodItems newFood = new FoodItems(_foodMenu.GetNewFoodNumber());

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

            bool wasAdded = _foodMenu.AddFoodToMenu(newFood);
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

            FoodItems itemsToUpdate = _foodMenu.GetFoodItemsByName(foodToUpdate);
            FoodItems updatedFood = new FoodItems();

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

            bool wasUpdated = _foodMenu.AddFoodToMenu(updatedFood);
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

            FoodItems foodToDelete = _foodMenu.GetFoodItemsByName(itemToDelete);
            bool wasDeleted = _foodMenu.DeleteExistingFoodItems(foodToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("This item could not be deleted.");
            }

        }

        private void DisplayAllFood(FoodItems foodItems)
        {
            Console.WriteLine($"Menu Item: {foodItems.MealName}");
            Console.WriteLine($"Menu Number: {foodItems.MealNumber}");
            Console.WriteLine($"Description: {foodItems.Description}");
            Console.WriteLine($"Price: {foodItems.Price}");
            Console.WriteLine($"Ingredients: {foodItems.Ingredients}");
        }
    }
}


