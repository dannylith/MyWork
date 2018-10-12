using BattleShip.BLL.Requests;
using System;

namespace BattleShip.UI
{
    public class ConsoleInput
    {

        public Coordinate GetUserCoord(string prompt)
        {
            //convert user input into coordinate
            int x = 0, y;
            string UserInput;
            char convertLetter = '0';
            while (true)
            {
                Console.Write(prompt);
                UserInput = Console.ReadLine();//get user input
                if (!string.IsNullOrWhiteSpace(UserInput))
                {//conver to char as long as the input isn't an empty space or null
                    convertLetter = Convert.ToChar(UserInput.ToLower().Substring(0, 1));
                }
                if (string.IsNullOrWhiteSpace(UserInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No input.");
                    Console.ResetColor();
                }
                else if (convertLetter >= (char)97 && convertLetter <= (char)106 && int.TryParse(UserInput.Substring(1), out y))
                {//convert user input into coordinate

                    x = ((int)convertLetter) - 96;
                    return new Coordinate(x, int.Parse(UserInput.Substring(1)));
                }
                else if (convertLetter >= (char)97 && convertLetter <= (char)122 && int.TryParse(UserInput.Substring(1), out y))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That letter is not on the board. Try again.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid input. Please use the format letter and number ex. B6.");
                    Console.ResetColor();
                }



            }


        }


        public ShipDirection GetShipDirection()
        {
            while (true)
            {
                Console.Write("Which direction do you want the ship to face[left, right, up, down]: ");
                string userInput = Console.ReadLine();

                if (userInput == "left")
                {
                    return ShipDirection.Left;
                }
                else if (userInput == "right")
                {
                    return ShipDirection.Right;
                }
                else if (userInput == "down")
                {
                    return ShipDirection.Down;
                }
                else if (userInput == "up")
                {
                    return ShipDirection.Up;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.ResetColor();
                }
            }

        }



    }
}
