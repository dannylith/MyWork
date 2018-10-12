using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreBucketsMoreFun
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare ALL THE THINGS
            // (Usually it's a good idea to declare them at the beginning of the program)
            int butterflies, beetles, bugs;
            String color, size, shape, thing;
            double number;

            // Now give a couple of them some values
            butterflies = 2;
            beetles = 4;

            bugs = butterflies + beetles;
            Console.WriteLine("There are only " + butterflies + " butterflies,");
            Console.WriteLine("but " + bugs + " bugs total.");

            Console.WriteLine("Uh oh, my dog ate one.");
            butterflies--;// The "--" operator is being used to show the dog ate the butterfly
            Console.WriteLine("Now there are only " + butterflies + " butterflies left.");
            Console.WriteLine("But still " + bugs + " bugs left, wait a minute!!!"); //bugs value doesn't change since no calculations was done on it
            Console.WriteLine("Maybe I just counted wrong the first time...");

            Console.ReadKey();
        }
    }
}
