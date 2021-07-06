﻿using _02_Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsUI
{
    public class ProgramUI
    {
        private ClaimsRepo _contentRepo = new ClaimsRepo();
        public void Run()
        {
            SeedClaimsQueue();
            DisplayMenu();
        }
        //Menu
        private void DisplayMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select a menu option:\n" +
                    "1.See all Claims\n" +
                    "2.Take Care of the Next Claim:\n" +
                    "3.Enter a new Claim.\n" +
                    "6.Exit");

                //Get Agents input
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //See all claims
                        ViewAllClaims();
                        break;
                    case "2":
                        //Take care of the next claim
                        NextClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        EnterANewClaim();
                        break;
                    case "4":
                        //exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a number between 1 and 4");
                        break;                        
                }
                Console.WriteLine("Please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }                            
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _contentRepo.GetClaimsContentQueue();
            //Loop through the claims
            foreach (Claims content in queueOfClaims)
            {
                Console.WriteLine($"ClaimID:{content.ClaimsId}\n" +
                    $"Type:{content.ClaimType}\n" +
                    $"Description:{content.Description}\n" +
                    $"Amount:{content.ClaimAmount}\n" +
                    $"DateOFAccident{content.DateOfIncident}\n" +
                    $"DateOfClaim:{content.DateOfClaim}");                    
            }
        }
        private void NextClaim()
        {
            Queue<Claims> queueOfClaims = _contentRepo.GetClaimsContentQueue();
            Claims nextClaim = queueOfClaims.Peek();                       
                Console.WriteLine($"ClaimID    :     {nextClaim.ClaimsId}\n" +
                    $"Type:{nextClaim.ClaimType}\n" +
                    $"Description:{nextClaim.Description}\n" +
                    $"Amount:{nextClaim.ClaimAmount}\n" +
                    $"DateOFAccident{nextClaim.DateOfIncident}\n" +
                    $"DateOfClaim:{nextClaim.DateOfClaim}\n" +
                    $"IsValid:{nextClaim.IsValid}");
                Console.WriteLine("Do you want to deal with this claim now(y / n)?");
            string input =Console.ReadLine();
            if (input.ToLower() == "y")
            {
                 _contentRepo.RemoveClaimsFromQueue();
                Console.WriteLine("Claim successfully removed. \n Press any key to continue");
            }
            else
            {
                Console.WriteLine("Something went wrong while processing this claim. Press any key to return to the main menu.");
            }
            Console.ReadKey();
        }
        private void EnterANewClaim()
        {
        Claims newClaim = new Claims();           
        Console.Clear();
        //Claim ID
        Console.WriteLine("Please enter a claim ID:");
        newClaim.ClaimsId = int.Parse(Console.ReadLine());
         //ClaimType
        Console.WriteLine("Please enter a claim Type:");
        newClaim.ClaimType = Console.ReadLine();                                         
        //Claim Description
        Console.WriteLine("Please enter a description:");
        newClaim.Description = Console.ReadLine();
        //Claims Damage
        Console.WriteLine("Please enter the damage amount:");
        newClaim.ClaimAmount = double.Parse(Console.ReadLine());
        //Date of Incident
        Console.WriteLine("Please enter the date of the accident:(Enter the following format when entering the date: year,month,date)");
        newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
        //Date of Claim
        Console.WriteLine("Please enter the date the claim was made: (Enter the following format when entering the date: year,month,date)");
        newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
         _contentRepo.AddClaimsToQueue(newClaim);            
        }
        //Seed Method
        private void SeedClaimsQueue()
        {
            DateTime accident = new DateTime(2021, 03, 16);
            DateTime claim = new DateTime(2021, 03, 26);

            Claims car = new Claims(3, "Car", "Car Accident", 1233,accident,claim);
            Claims home = new Claims(4, "Home", "Car Accident", 1233, accident, claim);
            Claims theft = new Claims(5, "Theft", "Car Accident", 1233, accident, claim);
            _contentRepo.AddClaimsToQueue(car);
            _contentRepo.AddClaimsToQueue(home);
            _contentRepo.AddClaimsToQueue(theft);
        }
    }
}
