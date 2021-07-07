using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public enum IngredientsList
    {
        Pasta = 1,
        Spagetti_Sauce,
        Cheese,
        Spices,
        potatoes        
    }
    public class Menu
    {
        //Properties
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }                
        public IngredientsList ListOfIngredients { get; set; }

        //Constructors
        public Menu() { }
        public Menu(int mealNumber, string mealName, string description, double price,IngredientsList ingredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
            ListOfIngredients = ingredients;
        }
    }    
}
