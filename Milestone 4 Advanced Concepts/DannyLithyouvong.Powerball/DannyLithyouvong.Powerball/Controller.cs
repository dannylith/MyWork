using DannyLithyouvong.Powerball.Data;
using DannyLithyouvong.Powerball.Domain;
using DannyLithyouvong.Powerball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball
{
    public class Controller
    {
        Service service;
        public Controller(IPickRepository repo, IPickGetter pickGetter)
        {
            service = new Service(repo, pickGetter);
        }

        public void Run()
        {

            //Menu options
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Powerball");
                ConsoleIO.LineSeparator();
                Console.WriteLine("1. Enter a Ticket");
                Console.WriteLine("2. QuickPick");
                Console.WriteLine("3. Show a Ticket");
                Console.WriteLine("4. Draw");
                Console.WriteLine("5. Show all Tickets");

                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        UserPick();
                        break;
                    case "2":
                        QuickPick();
                        break;
                    case "3":
                        LookupPick();
                        break;
                    case "4":
                        Draw();
                        break;
                    case "5":
                        GetPicksList();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Not a valid option. Try again.");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }


        }

        public void UserPick()
        {

            UserPickResponse response;
            Console.Clear();

            //user input for picks
            Console.WriteLine("Pick your Numbers");
            ConsoleIO.LineSeparator();
            string name;
            Console.Write("What is your name: ");
            name = Console.ReadLine();
            int pick1 = ConsoleIO.ReadIntInRange("What is your first choice: ", 1, 69);
            int pick2 = ConsoleIO.ReadIntInRange("What is your second choice: ", 1, 69);
            int pick3 = ConsoleIO.ReadIntInRange("What is your third choice: ", 1, 69);
            int pick4 = ConsoleIO.ReadIntInRange("What is your forth choice: ", 1, 69);
            int pick5 = ConsoleIO.ReadIntInRange("What is your fifth choice: ", 1, 69);
            int powerball = ConsoleIO.ReadIntInRange("What is your powerball choice: ", 1, 26);

            response = service.UserPick(name, pick1, pick2, pick3, pick4, pick5, powerball);

            if (response.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Picks Completed");
                Console.ResetColor();
                ConsoleIO.LineSeparator();
                ConsoleIO.DisplayHeader();        
                ConsoleIO.DisplayPickInfo(response.PickResponse);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("The picks were not submitted.");
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public void GetPicksList()
        {
            
            //display the picks on the console screen
            GetPickListResponse response = new GetPickListResponse();
            response = service.GetPicks();

            Console.Clear();

            Console.WriteLine("Ticket Lists");
            ConsoleIO.LineSeparator();
            ConsoleIO.DisplayHeader();
            if (response.Success)
            {
                foreach (var p in response.picks)
                {
                    ConsoleIO.DisplayPickInfo(p);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void QuickPick()
        {
            //Computer will generate the random pick then display what the picks were
            Console.Clear();

            Console.WriteLine("Quick Pick");
            ConsoleIO.LineSeparator();
            string name;
            Console.Write("What is your name: ");
            name = Console.ReadLine();
            Pick computerPick = service.QuickPick(name);
            Console.WriteLine("Your Ticket is: ");
            ConsoleIO.LineSeparator();
            ConsoleIO.DisplayHeader();
            ConsoleIO.DisplayPickInfo(computerPick);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Draw()
        {
            Console.Clear();
            DrawResponse response = new DrawResponse();
            response = service.Draw();
            if (response.Success)//Display list of winner(s) and the winning number
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Winning Numbers: " + string.Join(" ", response.WinningPickArray) + " " + response.Powerball);
                Console.ResetColor();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(response.Message);
                Console.WriteLine("      ID  Name  ");
                ConsoleIO.LineSeparator();
                foreach (var p in response.WinningPicksList)
                {
                    Console.Write("      ");
                    ConsoleIO.DisplayWinningPicksInfo(p, response.WinningPickArray);
                    Console.WriteLine();
                }

            }
            else//display no winner or no tickets if picks is empty
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Winning Numbers: " + string.Join(" ", response.WinningPickArray) + " " + response.Powerball);
                Console.ResetColor();
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(response.Message);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void LookupPick()
        {
            Console.Clear();
            UserPickResponse response = new UserPickResponse();

            Console.WriteLine("Pick Lookup:");
            ConsoleIO.LineSeparator();
            do
            {//get input from user
                Console.Write("What is the ID of the pick you want to lookup: ");
                int userInput;
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    response = service.LookupPick(userInput);
                    break;
                }
                else//make sure input is a number
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid input. Needs to be a number.");
                    Console.ResetColor();
                }
            } while (true);

            //display pick or no pick found
            if (response.Success)
            {
                ConsoleIO.DisplayHeader();
                ConsoleIO.DisplayPickInfo(response.PickResponse);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
