using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_CafeTest
{
    [TestClass]
    public class CafeTests
    {
        private MenuRepos _repo;
        private Menu _meal;

        [TestInitialize]
        public void CafeRepositoryTests()
        {
            _repo = new MenuRepos();
            _meal = new Menu(2,"Lasagna","Delicious Italian Food",12.99, IngredientsList.Pasta);
            _repo.AddMealsToList(_meal);
        }
        //Add Method
        [TestMethod]

        public void AddToMenuList_ShouldGetNotNull()
        {
            //Arrange --> Setting up the playing field
            Menu meals = new Menu();
            meals.MealName = "Pasta";
            MenuRepos repository = new MenuRepos();

            //Act-- Get/run the code we want to test
            repository.AddMealsToList(meals);
            Menu mealsFromMenuList = repository.GetMealsByName("Pasta");

            //Assert--Use the assert class to verify the expected outcome  
            Assert.IsNotNull(mealsFromMenuList);

        }
        [TestMethod]
        public void DeleteMeals_ShouldReturnTrue()

        {
            //Arrange
            //Act
            bool removeResult = _repo.RemoveMealsFromList(_meal.MealName);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
