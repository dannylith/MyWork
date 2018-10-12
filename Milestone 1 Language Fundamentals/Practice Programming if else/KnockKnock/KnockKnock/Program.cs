using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Knock Knock! Guess who!! ");
            String nameGuess = Console.ReadLine();

            if (nameGuess.Equals("Marty McFly")) // the results is still the same when using == ; it is also case sensitive so using incorrect case will result in a false
            {
                Console.WriteLine("Hey! That's right! I'm back!");
                Console.WriteLine(".... from the Future."); // Sorry, had to!
            }
            else
            {
                Console.WriteLine("Dude, do I -look- like " + nameGuess);
            }

            Console.ReadKey();
        }
    }
}
