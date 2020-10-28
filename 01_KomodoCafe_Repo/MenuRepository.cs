using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repo
{
    public class MenuRepository
    {
        public List<Menu> _repo = new List<Menu>();
        private int _highestFoodNumber = 1;

        public bool AddFoodToMenu(Menu food)
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

        public List<Menu> SeeAllFood()
        {
            return _repo;
        }

        public Menu GetFoodItemsByName(string foodItemName)
        {
            foreach (Menu food in _repo)
            {
                if (food.MealName.ToLower() == foodItemName.ToLower())
                {
                    return food;
                }
            }
            return null;
        }

        public bool UpdateFoodItems(string originalFood, Menu updatedFood)
        {
            Menu oldItem = GetFoodItemsByName(originalFood);

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

        public bool DeleteExistingFoodItems(Menu existingFood)
        {
            bool deleteFood = _repo.Remove(existingFood);
            return deleteFood;
        }
    }
}
