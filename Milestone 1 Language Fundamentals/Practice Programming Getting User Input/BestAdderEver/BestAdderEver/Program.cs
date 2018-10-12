using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestAdderEver
{
    class Program
    {
        static void Main(string[] args)
        {
            int intfirst, intSecond, intThird;

            Console.Write("What is your first number? ");
            intfirst = int.Parse(Console.ReadLine());
            Console.Write("What is your second number? ");
            intSecond = int.Parse(Console.ReadLine());
            Console.Write("What is your third number? ");
            intThird = int.Parse(Console.ReadLine());

            Console.WriteLine($"Your choices were {intfirst}, {intSecond}, and {intThird}.");
            Console.WriteLine("The sum of those numbers is: " + (intfirst + intSecond + intThird));
            Console.WriteLine("The sum of those numbers is: " + (intfirst + intSecond + intThird));

            Console.ReadKey();
        }
    }
}
