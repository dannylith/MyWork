using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortuneCookie
{
    class Program
    {
        static void Main(string[] args)
        {

            Random r = new Random();


            int x = r.Next(1, 11);

            switch (x)
            {
                case 1:
                    Console.WriteLine("Those aren’t the droids you’re looking for.");
                    break;
                case 2:
                    Console.WriteLine("Never go in against a Sicilian when death is on the line!");
                    break;
                case 3:
                    Console.WriteLine("Goonies never say die.");
                    break;
                case 4:
                    Console.WriteLine("With great power there must also come — great responsibility.");
                    break;
                case 5:
                    Console.WriteLine("Never argue with the data.");
                    break;
                case 6:
                    Console.WriteLine("Try not. Do, or do not. There is no try.");
                    break;
                case 7:
                    Console.WriteLine("You are a leaf on the wind, watch how you soar.");
                    break;
                case 8:
                    Console.WriteLine("Do absolutely nothing, and it will be everything that you thought it could be.");
                    break;
                case 9:
                    Console.WriteLine("neel before Zod.");
                    break;
                case 10:
                    Console.WriteLine("Make it so.");
                    break;
                default:
                    Console.WriteLine("An Error Occurred");
                    break;
            }

            Console.ReadKey();
        }
    }
}
