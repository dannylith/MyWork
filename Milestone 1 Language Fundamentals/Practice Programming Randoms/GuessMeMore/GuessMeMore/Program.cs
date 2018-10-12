using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMeMore
{
    class Program
    {
        static void Main(string[] args)
        {
            string strGuess;
            int intGuess, intRandomNumber;
            Random r = new Random();
            bool boolEnd =  false;


            intRandomNumber = r.Next(-100, 100);

            while (!boolEnd)
            {
                
                Console.Write("Guess my number: ");
                strGuess = Console.ReadLine();

                intGuess = int.Parse(strGuess);



                if (intGuess == intRandomNumber)
                {
                    Console.WriteLine("your guess: " + strGuess + ". Wow, nice guess! That was it!");
                    boolEnd = true;
                }
                else if (intGuess < intRandomNumber)
                {
                    Console.WriteLine("your guess: " + strGuess + ". Ha, nice try - too low!");
                }
                else
                {
                    Console.WriteLine("your guess: " + strGuess + ". Too bad, way too high.");
                }
            }

            Console.ReadKey();
        }
    }
}
