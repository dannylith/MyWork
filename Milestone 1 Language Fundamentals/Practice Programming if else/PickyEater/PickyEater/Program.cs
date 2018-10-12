using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickyEater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many times has it been fried? (#) ");
            int timesFried = Convert.ToInt32(Console.ReadLine());



            Console.Write("Does it have any spinach in it? (y/n) ");
            String hasSpinach = Console.ReadLine();



            Console.Write("Is it covered in cheese? (y/n) ");
            String cheeseCovered = Console.ReadLine();



            Console.Write("How many pats of butter are on top? (#) ");
            int butterPats = Convert.ToInt32(Console.ReadLine());


            Console.Write("Is it covered in chocolate? (y/n) ");
            String chocolatedCovered = Console.ReadLine();



            Console.Write("Does it have a funny name? (y/n) ");
            String funnyName = Console.ReadLine();



            Console.Write("Is it broccoli? (y/n) ");
            String isBroccoli = Console.ReadLine();



            // Conditionals should go here! Here's the first one for FREE!

            if (hasSpinach.Equals("y") || funnyName.Equals("y"))
            {

                Console.WriteLine("There's no way that'll get eaten.");
            }

            if (timesFried > 2 && timesFried < 4 && chocolatedCovered.Equals("y"))
            {
                Console.WriteLine("Oh, it's like a deep fried snickers. That'll be a hit!");
            }

            if (timesFried == 2 && cheeseCovered.Equals("y"))
            {
                Console.WriteLine("Mmm. Yeah, fried cheesy doodles will get et.");
            }

            if (isBroccoli.Equals("y") && butterPats > 6 && cheeseCovered.Equals("y"))
            {
                Console.WriteLine("As long as the green is hidden by cheddar, it'll happen!");
            }

            if (isBroccoli.Equals("y"))
            {
                Console.WriteLine("Oh, green stuff like that might as well go in the bin.");
            }

            Console.ReadKey();
        }
    }
}
