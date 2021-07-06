using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        private MenuRepos _mealRepo = new MenuRepos();
        public void Run()
        {
            SeedMealList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                //Display Our Menu Options
                Console.WriteLine("Please select an option from the list below:\n" +
                    "1.Create a new meal\n" +
                    "2.View all menu items\n" +
                    "3.View meals by MealName\n" +
                    "4 Delete meals from menu\n" +
                    "5. Exit");

                //Getting the users inputs
                string input = Console.ReadLine();

                //Evaluate the users Input and act
                switch (input)
                {
                    case "1":
                        //Create New meals
                        CreateNewMeals();
                        break;
                    case "2":
                        //view all meals
                        ViewAllMeals();
                        break;
                    case "3":
                        //view meals by name
                        ViewMealsByName();
                        break;
                    case "4":
                        //Delete meals from the menu
                        DeleteExistingMeals();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5");
                        break;
                }
                Console.WriteLine("Please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewMeals()
        {
            Console.Clear();
            Menu newMeals = new Menu();
            //MealName
            Console.WriteLine("Please enter the Name of the Meal you want to add:");
            newMeals.MealName = Console.ReadLine();
            //Description
            Console.WriteLine("Please enter the description of the meal you are adding:");
            newMeals.Description = Console.ReadLine();
            //MealNumber
            Console.WriteLine("Please enter the number that will be associated with this meal on the menu");
            newMeals.MealNumber = int.Parse(Console.ReadLine());
            //Meal Price
            Console.WriteLine("Please enter the price for this meal:");
            newMeals.Price = double.Parse(Console.ReadLine());
            //Ingredients List
            Console.WriteLine("Select an ingredient from the list:\n" +
                "1.Pasta\n" +
                "2.Spaghetti Sauce\n" +
                "3.Cheese\n" +
                "4.Spices");
            string ingredientsAsString = Console.ReadLine();
            int ingredientsAsInt = int.Parse(ingredientsAsString);            
            newMeals.ListOfIngredients = (IngredientsList)ingredientsAsInt;

            _mealRepo.AddMealsToList(newMeals);
        }
        //View current saved Meals on the menu.
        private void ViewAllMeals()
        {
            Console.Clear();

            List<Menu> ListOfMeals = _mealRepo.GetMealList();
            //Loop through meals on the menu
            foreach (Menu meals in ListOfMeals)
            {
                Console.WriteLine($"MealName: {meals.MealName}\n" +
                    $"Description: {meals.Description}\n" +
                    $"Meal Number: {meals.MealNumber}\n" +
                    $"Price: {meals.Price}\n" +
                    $"Ingredient list: {meals.ListOfIngredients}");                    
            }
        }
        //View existing  by meals
        private void ViewMealsByName()
        {
            Console.Clear();
            ViewAllMeals();                      
            //Prompt the user to give me a title
            Console.WriteLine("Enter the title of the Meal you would like to see:");
            //Get the user input
            string meal = Console.ReadLine();
            //Find content by title
            Menu meals = _mealRepo.GetMealsByName(meal);
            //Display said content if it isnt null
            if (meals != null)
            {
                Console.WriteLine($"MealName: {meals.MealName}\n" +
                     $"Description: {meals.Description}\n" +
                     $"Meal Number: {meals.MealNumber}\n" +
                     $"Price: {meals.Price}\n" +
                     $"Ingredient list: {meals.ListOfIngredients}");
            }
            else
            {
                Console.WriteLine("There are no meals by that name.");

            }
        }
        //Delete Existing Meals from the menu
        private void DeleteExistingMeals()
        {
            Console.Clear();
            ViewAllMeals();
            //Get the meal they want to remove
            Console.WriteLine("\nEnter the name of the meal you would like to remove:");

            string input = Console.ReadLine();

            //call the delete method
            bool wasRemoved = _mealRepo.RemoveMealsFromList(input);
            //if the content was deleted, say so
            //Otherwise state it could not be deleted
            if (wasRemoved)
            {
                Console.WriteLine("The meal was succesfully removed from the menu.");
            }
            else
            {
                Console.WriteLine("The meal was not succesfully removed from the menu.");
            }
        }
        //Seed Method
        private void SeedMealList()
        {
            Menu ravioli = new Menu(2,"Ravioli", "An Italian dumpling that's typically stuffed with ricotta, meat, cheese, and vegetables.",25.99,IngredientsList.Cheese);
            Menu pasta = new Menu(2, "Pasta", "An Italian dumpling that's typically stuffed with ricotta, meat, cheese, and vegetables.", 25.99, IngredientsList.Cheese);
            Menu lasagna = new Menu(2, "Lasagna", "An Italian dumpling that's typically stuffed with ricotta, meat, cheese, and vegetables.", 25.99, IngredientsList.Cheese);

            _mealRepo.AddMealsToList(ravioli);
            _mealRepo.AddMealsToList(pasta);
            _mealRepo.AddMealsToList(lasagna);
        }
    }
}
