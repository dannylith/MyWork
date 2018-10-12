using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoOrDoNot
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Should I do it? (y/n) ");
            bool doIt;

            if (Console.ReadLine().Equals("y"))
            {
                doIt = true; // DO IT!
            }
            else
            {
                doIt = false; // DONT YOU DARE!
            }

            bool iDidIt = false;

            //do
            //{
            //    iDidIt = true;
            //    break;
            //} while (doIt);

            while (doIt)//yes will will run the if statement and no will run the else statement, else if will never run
            {
                iDidIt = true;
                break;
            }

            if (doIt && iDidIt)
            {
                Console.WriteLine("I did it!"); //typing in 'y' will run this block of code
            }
            else if (!doIt && iDidIt)
            {
                Console.WriteLine("I know you said not to ... but I totally did anyways."); //typing in 'n' will run this block of code
            }
            else
            {
                Console.WriteLine("Don't look at me, I didn't do anything!");
            }
            Console.ReadKey();
        }
    }
}
