using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repo
{
    public class FoodItems
    {
        public int MealNumber { get; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }

        
        public FoodItems() { }
        public FoodItems(int mealNumber) 
        {
            MealNumber = mealNumber;
        }

        public FoodItems(string mealName, string description, double price, string ingredients)
        {
            MealName = mealName;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
