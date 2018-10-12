using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitAWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeNow = 5; //this determines what the current time is and will end the loop if it's greater than bed time
            int bedTime = 10;// this determines what time to go to sleep or end the loop

            while (timeNow < bedTime)
            {
                Console.WriteLine("It's only " + timeNow + " o'clock!");
                Console.WriteLine("I think I'll stay up just a liiiiittle longer....");
                timeNow++; // Time passes
            }

            Console.WriteLine("Oh. It's " + timeNow + " o'clock.");
            Console.WriteLine("Guess I should go to bed ...");

            Console.ReadKey();
        }
    }
}
