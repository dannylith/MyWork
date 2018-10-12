using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyTeenager
{
    class Program
    {
        static void Main(string[] args)
        {
            int intAskClean = 0, intRandomNum, intDraws = 5;
            Random r = new Random();
            bool boolIsClean = false;

            do
            {
                intAskClean++;
                Console.WriteLine($"Clean your room!! (x{intAskClean})");
                intDraws = intAskClean * 5;

                do
                {
                    intRandomNum = r.Next(0, 101);

                    if (intRandomNum == 50)
                    {
                        Console.WriteLine("FINE! I'LL CLEAN MY ROOM. BUT I REFUSE TO EAT MY PEAS.");
                        boolIsClean = true;
                        break;
                    }
                    intDraws--;
                } while (intDraws > 0);

                if(intAskClean >= 15)
                {
                    Console.WriteLine("That's IT, I'm doing it!!! YOU'RE GROUNDED AND I'M TAKING YOUR XBOX!");
                    break;
                }
               

            } while (!boolIsClean);

            Console.ReadKey();
        }
    }
}
