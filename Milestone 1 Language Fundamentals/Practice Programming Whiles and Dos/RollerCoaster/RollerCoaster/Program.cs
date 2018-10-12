using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We're going to go on a roller coaster...");
            Console.WriteLine("Let me know when you want to get off...!");

            String keepRiding = "y";
            int loopsLooped = 0;
            //while (keepRiding.Equals("y"))
            //{
            //    Console.WriteLine("WHEEEEEEEEEEEEEeEeEEEEeEeeee.....!!!");
            //    Console.Write("Want to keep going? (y/n) :");
            //    keepRiding = Console.ReadLine();
            //    loopsLooped++;// there is no int here because it was already declared at the top of the code and adding it again will override what the current value is
            //}

            while (keepRiding.Equals("n")) //this will not run because the value is false; keepRiding is equal to y
            {
                Console.WriteLine("WHEEEEEEEEEEEEEeEeEEEEeEeeee.....!!!");
                Console.Write("Want to keep going? (y/n) :");
                keepRiding = Console.ReadLine();
                loopsLooped++;// there is no int here because it was already declared at the top of the code and adding it again will override what the current value is
            }

            Console.WriteLine("Wow, that was FUN!");
            Console.WriteLine("We looped that loop " + loopsLooped + " times!!");

            Console.ReadKey();
        }
    }
}
