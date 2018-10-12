using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaybeItLovesMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int x;
            int a = 0;
            x = r.Next(12, 90);
            for (int i = 1; i <= x; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("It LOVES me!");
                    a = 1;
                }
                else
                {
                    Console.WriteLine("It loves me NOT!");
                    a = 2;
                }

            }
            if (a == 1)
            {
                Console.WriteLine("I knew it! It LOVES ME!");
            }
            else if (a == 2)
            {
                Console.WriteLine("Awwww, bummer.");
            }
            Console.ReadKey();
        }
    }
}
