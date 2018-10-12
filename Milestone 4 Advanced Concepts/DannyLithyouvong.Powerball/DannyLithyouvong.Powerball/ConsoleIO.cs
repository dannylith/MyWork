using DannyLithyouvong.Powerball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball
{
    public class ConsoleIO
    {
        public static void DisplayHeader()
        {
            Console.WriteLine("ID  Name");
            LineSeparator();
        }
        public static void LineSeparator()
        {
            Console.WriteLine("=================================");
        }

        public static void DisplayPickInfo(Pick pick)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{pick.ID,-5}" +
                $"{pick.Name,-10}" +
                $"{pick.NumberOne,-3}" +
                $"{pick.NumberTwo,-3}" +
                $"{pick.NumberThree,-3}" +
                $"{pick.NumberFour,-3}" +
                $"{pick.NumberFive,-3}" +
                $"{pick.Powerball,-3}");
            Console.ResetColor();
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

        public static void DisplayWinningPicksInfo(Pick pick, int[] winningNumber)
        {
            Console.Write($"{pick.ID,-5}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{pick.Name,-10}");
            Console.ResetColor();

            if (winningNumber.Contains(pick.NumberOne))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{pick.NumberOne,-3}");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{pick.NumberOne,-3}");
            }            

            if (winningNumber.Contains(pick.NumberTwo))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{pick.NumberTwo,-3}");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{pick.NumberTwo,-3}");
            }

            if (winningNumber.Contains(pick.NumberThree))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{pick.NumberThree,-3}");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{pick.NumberThree,-3}");
            }

            if (winningNumber.Contains(pick.NumberFour))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{pick.NumberFour,-3}");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{pick.NumberFour,-3}");
            }

            if (winningNumber.Contains(pick.NumberFive))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{pick.NumberFive,-3}");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{pick.NumberFive,-3}");
            }

            Console.Write(pick.Powerball);
        }

    }
}
