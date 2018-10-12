using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ConsoleIO
    {
        public static int SelectFromMenu()
        {
            Console.WriteLine("1. Add More Money");
            Console.WriteLine("2. Vend Item");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Exit");
            Console.ResetColor();
            return ReadIntInRange("Select 1-3: ", 1, 3);
        }

        public static int ReadIntInRange(string prompt, int min, int max)
        {
            int result = 0;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                int.TryParse(input, out result);
                if (result < min || result > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                }
            } while (result < min || result > max);

            return result;

        }
        public static decimal ReadDecimailInRange(string prompt, decimal min, decimal max)
        {
            decimal result = 0;
            bool valid = true;
            do
            {
                
                Console.Write(prompt);
                string input = Console.ReadLine();
                valid = decimal.TryParse(input, out result);
                if (valid)
                {
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"Please enter a number between {min} and {max}.");
                        valid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Not a number. Try again.");
                }
            } while (!valid);

            return result;

        }
    }
}
