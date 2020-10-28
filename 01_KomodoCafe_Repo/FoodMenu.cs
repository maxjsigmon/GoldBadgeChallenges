using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repo
{
    public class FoodMenu
    {
        public List<FoodItems> _repo = new List<FoodItems>();
        private int _highestFoodNumber = 1;

        public bool AddFoodToMenu(FoodItems food)
        {
            int startingCount = _repo.Count;
            _repo.Add(food);
            bool wasAdded = (_repo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public int GetNewFoodNumber()
        {
            return _highestFoodNumber++;
        }

        public List<FoodItems> SeeAllFood()
        {
            return _repo;
        }

        public FoodItems GetFoodItemsByName(string foodItemName)
        {
            foreach (FoodItems food in _repo)
            {
                if (food.MealName.ToLower() == foodItemName.ToLower())
                {
                    return food;
                }
            }
            return null;
        }

        public bool UpdateFoodItems(string originalFood, FoodItems updatedFood)
        {
            FoodItems oldItem = GetFoodItemsByName(originalFood);

            if (oldItem != null)
            {
                oldItem.MealName = updatedFood.MealName;
                oldItem.Description = updatedFood.Description;
                oldItem.Price = updatedFood.Price;
                oldItem.Ingredients = updatedFood.Ingredients;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingFoodItems(FoodItems existingFood)
        {
            bool deleteFood = _repo.Remove(existingFood);
            return deleteFood;
        }
    }
}
