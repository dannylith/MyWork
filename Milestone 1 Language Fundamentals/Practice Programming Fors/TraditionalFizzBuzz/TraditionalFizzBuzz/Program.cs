using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraditionalFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int intUserInput, intCounter;
            Console.Write("How much units fizzing and buzzing do you need in your life? ");
            intUserInput = int.Parse(Console.ReadLine());
            intCounter = 0;

            for (int i = 0; i<100;i++)
            {
                if(i != 0 && i % 3 == 0 && i%5 != 0)
                {
                    Console.WriteLine("fizz");
                    intCounter++;
                    if(intCounter == intUserInput)
                    {
                        break;
                    }
                }
                else if (i != 0 && i % 5 == 0 && i%3 != 0)
                {
                    Console.WriteLine("buzz");
                    intCounter++;
                    if (intCounter == intUserInput)
                    {
                        break;
                    }
                }
                else if (i != 0 && i % 5 == 0 && i % 3 == 0)
                {
                    Console.WriteLine("fizz buzz");
                    intCounter++;
                    if (intCounter == intUserInput)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("TRADITION!!!!!");
            Console.ReadKey();
        }
    }
}
