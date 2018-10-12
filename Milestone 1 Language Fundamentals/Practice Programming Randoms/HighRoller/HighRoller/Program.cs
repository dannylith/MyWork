using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Random diceRoller = new Random();

            int intDiceSides, rollResult;

            Console.WriteLine("How sides does the dice have? ");
            intDiceSides = int.Parse(Console.ReadLine());

            rollResult = diceRoller.Next(intDiceSides) + 1;

            Console.WriteLine("TIME TO ROOOOOOLL THE DICE!");
            Console.WriteLine("I rolled a " + rollResult);

            if (rollResult == 1)
            {
                Console.WriteLine("You rolled a critical failure! Ouch.");
            }
            else if (rollResult == intDiceSides)
            {
                Console.WriteLine("You rolled a critical! Nice Job!");
            }

            Console.ReadLine();
        }
    }
}
