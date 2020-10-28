using System;
using System.Collections.Generic;
using _01_KomodoCafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void SetName_ShouldReturnCorrectString()
        {
            //Arrange
            Menu food = new Menu();
            //Act
            food.MealName = "Hamburger";
            //Assert
            Assert.AreEqual(food.MealName, "Hamburger");
        }

        [TestMethod]
        public void  AddToMenu_ShouldBeTrue()
        {
            Menu food = new Menu();
            MenuRepository repository = new MenuRepository();

            bool addFood = repository.AddFoodToMenu(food);

            Assert.IsTrue(addFood);
        }

        public void DeleteFoodItem_ShouldBeTrue()
        {
            MenuRepository repo = new MenuRepository();
            Menu item = new Menu("Hamburger", "It's a hamburger", 8.99, "Ground beef, bun");

            repo.AddFoodToMenu(item);

            Menu oldItems = repo.GetFoodItemsByName("Hamburger");

            bool removeItem = repo.DeleteExistingFoodItems(oldItems);

            Assert.IsTrue(removeItem);
        }


        [TestMethod]
        public void UpdateFoodItems_ShouldBeTrue()
        {
            MenuRepository repository = new MenuRepository();
            Menu oldItem = new Menu("Hamburger", "It's a hamburger", 8.99, "Ground Beef, bun");
            Menu updatedFood = new Menu("Hamburger", "It's a hamburger", 8.99, "Ground beef, sourdough bun");

            repository.AddFoodToMenu(oldItem);
            bool updateResult = repository.UpdateFoodItems(oldItem.Ingredients, updatedFood);

            Assert.IsTrue(updateResult);

        }
    }
}
