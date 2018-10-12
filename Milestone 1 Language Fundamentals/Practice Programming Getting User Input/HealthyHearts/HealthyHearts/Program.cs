using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            double age, maxHeart, hrZoneMin, hrZoneMax;

            Console.Write("What is your age? ");
            age = float.Parse(Console.ReadLine());

            maxHeart = 220 - age;
            hrZoneMin = maxHeart * 0.50;
            hrZoneMax = maxHeart * 0.85;

            Console.WriteLine($"Your maximum heart rate should be {maxHeart} beats per minute");
            Console.WriteLine($"Your target HR Zone is {hrZoneMin: 0} - {hrZoneMax: 0} beats per minute");

            Console.ReadKey();
        }
    }
}
