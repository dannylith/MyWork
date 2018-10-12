using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthStones
{
    class Program
    {
        static void Main(string[] args)
        {
            string strMonthInput;
            int intMonthInput;
            bool boolMonthInput;

            Console.Write("What month's birthstone are you wanting to know?[1-12]: ");
            strMonthInput = Console.ReadLine();
            boolMonthInput = int.TryParse(strMonthInput, out intMonthInput);

            if (boolMonthInput && intMonthInput >= 1 && intMonthInput <= 12)
            {
                if (intMonthInput == 1)
                {
                    Console.WriteLine("January - Garnet");
                } else if (intMonthInput == 2)
                {
                    Console.WriteLine("February - Amethyst");
                }
                else if (intMonthInput == 3)
                {
                    Console.WriteLine("March - Aquamarine");
                }
                else if (intMonthInput == 4)
                {
                    Console.WriteLine("April - Diamond");
                }
                else if (intMonthInput == 5)
                {
                    Console.WriteLine("May - Emerald");
                }
                else if (intMonthInput == 6)
                {
                    Console.WriteLine("June - Pearl");
                }
                else if (intMonthInput == 7)
                {
                    Console.WriteLine("July - Ruby");
                }
                else if (intMonthInput == 8)
                {
                    Console.WriteLine("August - Peridot");
                }
                else if (intMonthInput == 9)
                {
                    Console.WriteLine("September - Sapphire");
                }
                else if (intMonthInput == 10)
                {
                    Console.WriteLine("October - Opal");
                }
                else if (intMonthInput == 11)
                {
                    Console.WriteLine("November - Topaz");
                }
                else
                {
                    Console.WriteLine("December - Turquoise");
                }
            }
            else
            {
                Console.WriteLine("I think you must be confused, {0} doesn't match a month.", strMonthInput);
            }

            Console.ReadKey();
        }
    }
}
