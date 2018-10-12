using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int intStart, intStop, intCount;

            Console.Write("Start at : ");
            intStart = int.Parse(Console.ReadLine());
            Console.Write("Stop at : ");
            intStop = int.Parse(Console.ReadLine());
            Console.Write("Count by : ");
            intCount = int.Parse(Console.ReadLine());

            for (int i = intStart; i< intStop; i += intCount)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
