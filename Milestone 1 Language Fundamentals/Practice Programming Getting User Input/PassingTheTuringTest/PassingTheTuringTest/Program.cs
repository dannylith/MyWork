using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingTheTuringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string strName, strColor, strFavFood, strNum;

            Console.Write("What is your name? ");
            strName = Console.ReadLine();

            Console.WriteLine($"Hi {strName}, my name is Danny.");

            Console.Write("What is your favorite Color? ");
            strColor = Console.ReadLine();

            Console.WriteLine($"Huh, {strColor}, I like that too.");

            Console.Write("What is your favorite Food? ");
            strFavFood = Console.ReadLine();

            Console.WriteLine($"{strFavFood} sounds delicious");

            Console.Write("What is your favorite Number? ");
            strNum = Console.ReadLine();

            Console.WriteLine($"{strNum} is a good number.");

            Console.ReadKey();
        }
    }
}
