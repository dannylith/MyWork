using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewareTheKraken
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alrighty! Get those flippers and wetsuit on - we're going diving!");
            Console.WriteLine("Here we goooOOooOooo.....! *SPLASH*");

            int depthDivedInFt = 0;
            string end = "";

            // Turns out the ocean is only so deep, 36200 at the deepest survey,
            // so if we reach the bottom ... we should probably stop.
            while (depthDivedInFt < 36200) // channging this to true will still do the same thing, the break will still end the loop.
            {
                Console.WriteLine("So far, we've swam " + depthDivedInFt + " feet");

                if(end == "yes")
                {
                    Console.WriteLine("TIME TO GO!");
                    break;
                }

                if(depthDivedInFt == 5000)
                {
                    Console.WriteLine("You see a JellyFish");
                }
                if (depthDivedInFt == 10000)
                {
                    Console.WriteLine("You see a Shark");
                }
                if (depthDivedInFt == 15000)
                {
                    Console.WriteLine("You see a Whale");
                }

                if (depthDivedInFt >= 20000)
                {
                    Console.WriteLine("Uhhh, I think I see a Kraken, guys ....");
                    Console.WriteLine("TIME TO GO!");
                    break;
                }

                // I can swim, really fast! 500ft at a time!
                depthDivedInFt += 1000;

                Console.Write("Do you want to stop? [yes or no]: ");
                end = Console.ReadLine();
            }
            Console.WriteLine("");
            Console.WriteLine("We ended up swimming " + depthDivedInFt + " feet down.");
            Console.WriteLine("I bet we can do better next time!");

            Console.ReadKey();
        }
    }
}
