using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAndTwentyBlackbirds
{
    class Program
    {
        static void Main(string[] args)
        {
            int birdsInPie = 0;
            for (int i = 1; i < 25; i++)
            {
                Console.WriteLine("Blackbird #" + i + " goes into the pie!");
                birdsInPie++;
            }

            Console.WriteLine("There are " + birdsInPie + " birds in there!");
            Console.WriteLine("Quite the pie full!");

            Console.ReadKey();
        }
    }
}
