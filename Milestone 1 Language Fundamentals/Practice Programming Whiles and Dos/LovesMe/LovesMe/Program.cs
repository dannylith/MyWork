using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovesMe
{
    class Program
    {
        static void Main(string[] args)
        {
            //I wrote it in a for loop because I knew how long the loop needs to go for
            for(int i=1; i<=34; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("It LOVES me!");
                }
                else
                {
                    Console.WriteLine("It loves me NOT!");
                }
                
            }
            Console.WriteLine("I knew it! It LOVES ME!");
            Console.ReadKey();
        }
    }
}
