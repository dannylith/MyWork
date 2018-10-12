using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlipper
{
    class Program
    {
        static void Main(string[] args)
        {

            Random r = new Random();

            Console.WriteLine("Ready, Set, Flip....!!");

            int x = r.Next(2);
            string coinSide;

            if (x == 0)
            {
                coinSide = "Head";
            }
            else
            {
                coinSide = "Tail";
            }

            Console.WriteLine("You got {0}", coinSide);

            Console.ReadKey();
        }
    }
}
