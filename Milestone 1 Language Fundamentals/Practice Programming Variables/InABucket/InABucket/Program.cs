using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InABucket
{
    class Program
    {
        static void Main(string[] args)
        {
            // You can declare all KINDS of variables.
            String walrus;
            double piesEaten;
            float weightOfTeacupPig;
            int grainsOfSand;

            // But declaring them just sets up the space for data
            // to use the variable, you have to put data IN it first!
            walrus = "Sir Leroy Jenkins III";
            piesEaten = 42.1;
            weightOfTeacupPig = 10;
            grainsOfSand = 20;

            Console.WriteLine("Meet my pet Walrus, " + walrus);
            Console.Write("He was a bit hungry today, and ate this many pies : ");
            Console.WriteLine(piesEaten);
            Console.WriteLine("The weight of the teacup is {0} pounds.", weightOfTeacupPig);
            Console.WriteLine("There are {0} grains of sands.", grainsOfSand);

            Console.ReadKey();
        }
    }
}
