using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe
{
    class Program
    {
        static void Main(string[] args)
        {
            string strGuess, strMyNumber;
            int intGuess;

            strMyNumber = "6";



            Console.Write("Guess my number: ");
            strGuess = Console.ReadLine();

            intGuess = int.Parse(strGuess);



            if (intGuess == 6)
            {
                Console.WriteLine("your guess: " + strGuess + ". Wow, nice guess! That was it!");
            }
            else if (intGuess < 6)
            {
                Console.WriteLine("your guess: " + strGuess + ". Ha, nice try - too low! I chose # " + strMyNumber);
            }
            else
            {
                Console.WriteLine("your guess: " + strGuess + ". Too bad, way too high. I chose # " + strMyNumber);
            }

            Console.ReadKey();
        }
    }
}
