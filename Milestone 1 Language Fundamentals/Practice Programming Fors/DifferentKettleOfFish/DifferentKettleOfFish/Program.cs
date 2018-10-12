using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentKettleOfFish
{
    class Program
    {
        static void Main(string[] args)
        {
            int fish = 1;

            //while (fish < 10)
            //{
            //    if (fish == 3)
            //    {
            //        Console.WriteLine("RED fish!");
            //    }
            //    else if (fish == 4)
            //    {
            //        Console.WriteLine("BLUE fish!");
            //    }
            //    else
            //    {
            //        Console.WriteLine(fish + " fish!");
            //    }

            //    fish++;
            //}

            //Make the output look the same as it was in the while loop!What changed ? !(write in a comment): the top line of code changed to for loop
            for (int i = fish; i<= 10; i++)
            {
                if (fish == 3)
                {
                    Console.WriteLine("RED fish!");
                }
                else if (fish == 4)
                {
                    Console.WriteLine("BLUE fish!");
                }
                else
                {
                    Console.WriteLine(fish + " fish!");
                }

                fish++;
            }
            Console.ReadKey();
        }
    }
}
