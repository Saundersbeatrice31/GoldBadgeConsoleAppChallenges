using _03_Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InsuranceUI
{
    public class ProgramUI
    {
        private KInsuranceRepo _contentRepo = new KInsuranceRepo();
        public void Run()
        {
            SeedBadgesDict();
            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select a menu option:\n" + "1.Create a new badge\n" + "2.Update an Existing badge\n" + "3.Delete an Existing badge\n" + "4.Show a list with all badge numbers and door access:\n" +
                    "5.Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Create new Badges
                        CreateNewBadges();
                        break;
                    case "2":
                        //update Doors on existing badges
                        UpdateExistingBadges();
                        break;
                    case "3":
                        //Delete existing doors
                        DeleteExistingBadges();
                        break;
                    case "4":
                        //show a list of all badge numbers and door access
                        DisplayAllBadges();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 6");
                        break;
                }               
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> newBadges = new Dictionary<int, List<string>>();
            Console.WriteLine("What is the number on the badge:");
            int BadgeId = int.Parse(Console.ReadLine());
            if (_contentRepo.GetBadgeByID(BadgeId) != null)
            {
                Console.WriteLine("Badge number already exists. Try a updating instead of adding");
                Console.WriteLine("Please press any key to continue...");
            }
            else
            {
                KInsurance newBadge = new KInsurance(BadgeId);
                bool loop = true;
                List<string> doors = new List<string>();
                while (loop)
                {
                    Console.WriteLine("Enter a door that Badge #" + BadgeId + " needs access to: ");
                    doors.Add(Console.ReadLine());
                    Console.WriteLine("Any other doors (y/n)?");
                    string moreDoors = Console.ReadLine();
                    if (moreDoors.ToLower() == "n")
                    {
                        loop = false;
                    }
                }
                newBadge.DoorNames = doors;
                string doorResult = string.Join(",", doors);
                bool wasAdded = _contentRepo.AddBadge(newBadge);
                if (wasAdded == true)
                {
                    Console.WriteLine($"Badge #{newBadge.BadgeId} added Successfully with access to Doors: {doorResult}.");

                }
                else
                {
                    Console.WriteLine($"Something went wrong while adding this Badge #{newBadge.BadgeId}. Please try again.");
                }
                Console.WriteLine("Press any key to return to the main menu.");
            }
            Console.ReadKey();
        }
        public void UpdateExistingBadges()
        {
            Console.Clear();
            DisplayAllBadges();
            Console.WriteLine("What badge number do you want to update:");
            int badgeId = Convert.ToInt32(Console.ReadLine());
            KInsurance badgeToUpdate = _contentRepo.GetBadgeByID(badgeId);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                doorsOnBadge = badgeToUpdate.DoorNames;
                bool loop = true;
                while (loop)
                {
                    Console.Clear();                                        
                    string doorsResult = string.Join(",", badgeToUpdate.DoorNames);
                    Console.WriteLine($"Badge #{badgeToUpdate.BadgeId} has access to doors: {doorsResult}.");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("     1> Remove a door");
                    Console.WriteLine("     2> Add a door");
                    Console.WriteLine("     3> Finish Updating Badge");
                    string menu = Console.ReadLine();
                    switch (menu)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to remove?");
                            string doorToRemove = Console.ReadLine();
                            doorsOnBadge.Remove(doorToRemove);
                            badgeToUpdate.DoorNames = doorsOnBadge;
                            Console.WriteLine("Door Removed");
                            doorsResult = string.Join(",", badgeToUpdate.DoorNames);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeId} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Which door would you like to add?");
                            string doorToAdd = Console.ReadLine();
                            doorsOnBadge.Add(doorToAdd);
                            badgeToUpdate.DoorNames = doorsOnBadge;
                            Console.WriteLine("Door Added");
                            doorsResult = string.Join(",", badgeToUpdate.DoorNames);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeId} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "3":
                            loop = false;
                            break;
                    }
                }
                bool wasUpdate = _contentRepo.UpdateExistingBadge(badgeId, badgeToUpdate);
                if (wasUpdate == true)
                {
                    Console.WriteLine("Badge updated successfully");
                }
                else
                {
                    Console.WriteLine("Badge was not successfully updated.  Please try update again.");
                }
            }
            else
            {
                Console.WriteLine("Badge Id does not exist.");

            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
        public void DeleteExistingBadges()
        {
            Console.Clear();
            DisplayAllBadges();
            Console.WriteLine("What is the badge number to update:");
            int badgeId = Convert.ToInt32(Console.ReadLine());
            KInsurance badgeToUpdate = _contentRepo.GetBadgeByID(badgeId);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                string doorsResult = string.Join(",", badgeToUpdate.DoorNames);
                Console.WriteLine($"Badge #{badgeToUpdate.BadgeId} has access to doors: {doorsResult}.");
                Console.WriteLine($"Do you want to remove all doors from this Badge #{badgeToUpdate.BadgeId}? (y/n)");
                string deleteAll = Console.ReadLine();
                if (deleteAll.ToLower() == "y")
                {
                    badgeToUpdate.DoorNames.Clear();
                    bool wasUpdate = _contentRepo.UpdateExistingBadge(badgeId, badgeToUpdate);
                    if (wasUpdate == true)
                    {
                        Console.WriteLine($"All Doors have been removed from this Badge #{badgeId}");
                    }
                    else
                    {
                        Console.WriteLine("Badge was not removed.  Please try update again.");
                    }
                }
                else
                {
                    Console.WriteLine("You just canceled the deletion.");
                }
            }
            else
            {
                Console.WriteLine("Badge Id does not exist.");

            }
            Console.WriteLine("Press any key to return to the main menu");           
        }
        public void DisplayAllBadges()
        {
            Console.Clear();                        
            Console.WriteLine();
            Console.WriteLine("Badge#           Door Access:");
            Dictionary<int, List<string>> badges = _contentRepo.DisplayAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                string doorsResult = string.Join(",", badge.Value);
                Console.WriteLine($"{badge.Key}            {doorsResult}");

            }            
            Console.WriteLine("Press any key to continue...");            
        }
        public void SeedBadgesDict()
        {
            KInsurance badge1 = new KInsurance(145, new List<string> { "A9","A14" });
            KInsurance badge2 = new KInsurance(246, new List<string> { "A8", "A6", "B3", "B4" });
            KInsurance badge3 = new KInsurance(445, new List<string> { "A4", "A5" });
            KInsurance badge4 = new KInsurance(545, new List<string> { "A4", "A5" });
            KInsurance badge5 = new KInsurance(645, new List<string> { "A4", "A5" });

            _contentRepo.AddBadge(badge1);
            _contentRepo.AddBadge(badge2);
            _contentRepo.AddBadge(badge3);
            _contentRepo.AddBadge(badge4);
            _contentRepo.AddBadge(badge5);
        }
    }
}

