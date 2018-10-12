using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int intUserInput;

            Console.Write("Which times table shall I recite? ");
            intUserInput = int.Parse(Console.ReadLine());

            for (int i = 1; i<16; i++)
            {
                Console.WriteLine($"{i} * {intUserInput} = {i*intUserInput}");
            }

            Console.ReadKey();
        }
    }
}
