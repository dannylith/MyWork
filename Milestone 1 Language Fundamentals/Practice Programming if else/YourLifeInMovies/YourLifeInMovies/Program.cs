using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLifeInMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            string strName;
            int intBorn;

            Console.Write("Hey, let's play a game! What's your name? ");
            strName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Ok, {0}, when were you born? ", strName);
            intBorn = int.Parse(Console.ReadLine());

            if (intBorn <= 2005)
            {
                Console.WriteLine("Pixar's 'Up' came out half a decade ago.");
            }
            if (intBorn <= 1995)
            {
                Console.WriteLine("The first Harry Potter came out over 15 years ago.");
            }
            if (intBorn <= 1985)
            {
                Console.WriteLine("Space Jam came out not last decade, but the one before THAT.");
            }
            if (intBorn <= 1975)
            {
                Console.WriteLine("The original Jurassic Park release is closer to the lunar landing, than today.");
            }
            if (intBorn <= 1965)
            {
                Console.WriteLine("The MASH has been around for almost half a century!");
            }

            Console.ReadKey();
        }
    }
}
