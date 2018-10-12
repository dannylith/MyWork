using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALittleChaos
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();

            Console.WriteLine("Random can make integers: " + randomizer.Next());
            Console.WriteLine("Or a double: " + randomizer.NextDouble());

            int num = randomizer.Next(100);

            Console.WriteLine("You can store a randomized result: " + num);
            Console.WriteLine("And use it over and over againL: " + num + num);

            Console.WriteLine("Or just keep generating new values");
            Console.WriteLine("Here's a bunch of numbers from 0 - 100: ");

            Console.WriteLine(randomizer.Next(101) + ", ");
            Console.WriteLine(randomizer.Next(101) + ", ");
            Console.WriteLine(randomizer.Next(101) + ", ");
            Console.WriteLine(randomizer.Next(101) + ", ");
            Console.WriteLine(randomizer.Next(101) + ", ");
            for (int i=0; i<25; i++)
                {
                Console.WriteLine(randomizer.Next(50) + 50); //this only prints out between 50 - 100
            }

            Console.ReadKey();
        }
    }
}
