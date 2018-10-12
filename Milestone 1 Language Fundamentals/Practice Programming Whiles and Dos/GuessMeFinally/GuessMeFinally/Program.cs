using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMeFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            string strGuess;
            int intGuess, intRandomNumber, counter = 0;
            Random r = new Random();
            bool boolEnd = false;


            intRandomNumber = r.Next(-100, 100);

            while (!boolEnd)
            {

                Console.Write("Guess my number: ");
                strGuess = Console.ReadLine();

                intGuess = int.Parse(strGuess);



                if (intGuess == intRandomNumber)
                {
                    counter++;
                    if (counter == 1)
                    {
                        Console.WriteLine("your guess: " + strGuess + ". Wow, nice guess! That was it!");
                    }
                    else
                    {
                        Console.WriteLine("your guess: " + strGuess + ". Finally, it's about time you got it!");
                    }
                    boolEnd = true;
                    
                }
                else if (intGuess < intRandomNumber)
                {
                    Console.WriteLine("your guess: " + strGuess + ". Ha, nice try - too low!");
                    counter++;
                }
                else
                {
                    Console.WriteLine("your guess: " + strGuess + ". Too bad, way too high.");
                    counter++;
                }
            }

            Console.ReadKey();
        }
    }
}
