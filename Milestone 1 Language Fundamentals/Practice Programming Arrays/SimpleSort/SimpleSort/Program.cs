using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstHalf = { 3, 7, 9, 10, 16, 19, 20, 34, 55, 67, 88, 99 };
            int[] secondHalf = { 1, 4, 8, 11, 15, 18, 21, 44, 54, 79, 89, 100 };

            int[] wholeNumbers = new int[24];

            int counter = 0;

            // Sorting code should go here!
            for (int i = 0; i < wholeNumbers.Length; i++)
            {
                if (i < firstHalf.Length)
                {
                    wholeNumbers[i] = firstHalf[i];
                }
                else
                {
                    wholeNumbers[i] = secondHalf[counter];
                    counter++;
                }
            }

            int temp;
            
            for (int i = 0; i < wholeNumbers.Length; i++)
            {
                for (int j = 0; j < wholeNumbers.Length - 1; j++)
                {
                    if (wholeNumbers[j] > wholeNumbers[j + 1])
                    {
                        temp = wholeNumbers[j];
                        wholeNumbers[j] = wholeNumbers[j + 1];
                        wholeNumbers[j + 1] = temp;
                    }
                }
            }



            for (int i = 0; i < wholeNumbers.Length; i++)
            {
                Console.Write(wholeNumbers[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
