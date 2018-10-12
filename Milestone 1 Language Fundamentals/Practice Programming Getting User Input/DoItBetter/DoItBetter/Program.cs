using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoItBetter
{
    class Program
    {
        static void Main(string[] args)
        {
            int miles, hotdogs, languages;

            Console.Write("How many miles can you run? ");
            miles = (int.Parse(Console.ReadLine()) * 2) + 1;
            Console.WriteLine($"I can run more. I can do {miles} miles");

            Console.Write("How many hotdogs can you eat? ");
            hotdogs = (int.Parse(Console.ReadLine()) * 2) + 1;
            Console.WriteLine($"I can eat more. I can eat {hotdogs} hotdogs");

            Console.Write("How many languages do you know? ");
            languages = (int.Parse(Console.ReadLine()) * 2) + 1;
            Console.WriteLine($"I know a lot more. I know {languages} languages");

            Console.ReadKey();

        }
    }
}
