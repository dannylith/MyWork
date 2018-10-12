using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRustlers
{
    class Program
    {
        static void Main(string[] args)
        {
            int spaceships = 10;
            int aliens = 25;
            int cows = 100;

            //the if statement is comparing the values and depending on the result, it will run either the if or else statement code block
            if (aliens > spaceships)
            {
                Console.WriteLine("Vrroom, vroom! Let's get going!");
            }
            else
            {
                Console.WriteLine("There aren't enough green guys to drive these ships!");
            }

            //the else if statement will compare multiple conditions until one of them is true or reach the last else and run that block of code
            if (cows == spaceships)
            {
                Console.WriteLine("Wow, way to plan ahead! JUST enough room for all these walking hamburgers!");
            }
            else if (cows > spaceships) //if the else is removed from the else if, then it will be treated as it's own if statement and won't be chained to any other if statements and will just run on it's own
            {
                Console.WriteLine("Dangit! I don't how we're going to fit all these cows in here!");
            }
            else
            {
                Console.WriteLine("Too many ships! Not enough cows.");
            }

            if (aliens > cows)
            {
                Console.WriteLine("Hurrah, we've got the grub! Hamburger party on AlphaCentauri!");
            }
            else if (cows >= aliens)
            {
                Console.WriteLine("Oh no! The herds got restless and took over! Looks like _we're_ hamburger now!!");
            }

            Console.ReadKey();
        }
    }
}
