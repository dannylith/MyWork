using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTimesFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int intUserInput, intPoints = 0;

            Console.Write("Which times table shall I recite? ");
            intUserInput = int.Parse(Console.ReadLine());

            for (int i = 1; i < 16; i++)
            {
                Console.Write($"{i} * {intUserInput} is: ");
                if (int.Parse(Console.ReadLine()) == i * intUserInput)
                {
                    Console.WriteLine("Correct!");
                    intPoints += 1;
                }
                else
                {
                    Console.WriteLine($"Sorry no, the answer is: {i * intUserInput}");
                }
            }
            Console.WriteLine($"You got {intPoints} correct.");
            Console.ReadKey();
        }
    }
}
