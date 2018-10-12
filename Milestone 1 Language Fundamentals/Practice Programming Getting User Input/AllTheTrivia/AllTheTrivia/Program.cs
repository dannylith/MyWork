using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllTheTrivia
{
    class Program
    {
        static void Main(string[] args)
        {
            string first, second, third, forth;

            Console.Write("1,024 Gigabytes is equal to one what? ");
            first = Console.ReadLine();
            Console.Write("In our solar system which is the only planet that rotates clockwise? ");
            second = Console.ReadLine();
            Console.Write("The largest volcano ever discovered in our solar system is located on which planet? ");
            third = Console.ReadLine();
            Console.Write("What is the most abundant element in the earth's atmosphere?");
            forth = Console.ReadLine();

            Console.WriteLine($"Wow, 1,024 Gigabytes is a {second}!");
            Console.WriteLine($"I didn't know that the largest ever volcano was discovered on {first}!");
            Console.WriteLine($"That's amazing that {forth} is the most abundant element in the atmosphere...");
            Console.WriteLine($"{second} is the only planet that rotates clockwise, neat! ");

            Console.ReadKey();
        }
    }
}
