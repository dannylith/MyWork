using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            int intUserInput, counter = 0;
            Console.WriteLine("What number should I count down from? ");
            intUserInput = int.Parse(Console.ReadLine());
            
            for(int i = intUserInput; i>= 0; i--)
            {
                Console.Write(i + " ");
                counter++;
                if (counter == 10)
                {
                    Console.WriteLine();
                    counter = 0;
                }
                
            }
            Console.ReadKey();
        }
    }
}
