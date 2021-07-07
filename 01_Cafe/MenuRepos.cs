using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepos
    {
        //Create
        private List<Menu> _listOfMeals = new List<Menu>();
        public void AddMealsToList(Menu meals)
        {
            _listOfMeals.Add(meals);
        }
        //Read
        public List<Menu> GetMealList()
        {
            return _listOfMeals;
        }
        //Delete
        public bool RemoveMealsFromList(string mealName)
        {
            Menu meals = GetMealsByName(mealName);

            if (meals == null)
            {
                return false;
            }

            int initialCount = _listOfMeals.Count;
            _listOfMeals.Remove(meals);

            if (initialCount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper method
        public Menu GetMealsByName(string mealName)
        {
            foreach (Menu meals in _listOfMeals)
            {
                if (meals.MealName.ToLower() == mealName.ToLower())
                {
                    return meals;
                }
            }
            return null;
        }
    }
}
