using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringForwardFallBack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It's Spring...!");
            for (int i = 10; i > 0; i--)//0-9 are the start and stop
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine("\nOh no, it's fall...");
            for (int i = 10; i > 0; i--) //10-1 are the start and stop
            {
                Console.Write(i + ", ");
            }

            Console.ReadKey();
        }
    }
}
