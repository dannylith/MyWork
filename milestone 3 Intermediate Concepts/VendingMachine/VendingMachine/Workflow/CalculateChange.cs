using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine
{
    public class CalculateChange
    {

        public static decimal Money { get; private set; } = 0;

        public CalculateChange(decimal money)
        {
            Money = money;
        }


        public static void AddMoney()
        {
            decimal money = ConsoleIO.ReadDecimailInRange("How much Money do you want to add(1-100): ", 0, 100);
            Money += money;
        }

        public static bool SubtractMoney(string key, IVendingItemsRepository fileRepo)
        {
            Dictionary<string, VendingItem> products = fileRepo.GetAll();

            decimal productPrice = products[key].Price;

            if (Money >= productPrice)
            {
                Money -= productPrice;
                return true;
            }

            return false;

        }

        //converts the money into Quarters, Dimes, Nickels, and Pennies. Then Displays it.
        public static void GetQuartDimeNickPen()
        {
            decimal totalPennies = Money * 100;
            int quarters, dimes, nickels, pennies;
            string strQtr ="", strDime="", strNic="", strPen="";


            quarters = (int)(totalPennies / 25M);
            totalPennies %= 25M;
            if(quarters > 0)
            {
                strQtr = $"{quarters} Quarter(s)";
            }
            dimes = (int)(totalPennies / 10M);
            totalPennies %= 10M;
            if(dimes > 0)
            {
                strDime = $"{dimes} Dime(s)";
            }
            nickels = (int)(totalPennies / 5M);
            totalPennies %= 5M;
            if(nickels > 0)
            {
                strNic = $"{nickels} Nickel(s)";
            }
            pennies = (int)(totalPennies / 1M);
            if(pennies > 0)
            {
                strPen = $"{pennies} Pennies";
            }
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current Money: ${Money}");
            Console.ResetColor();
            if (quarters > 0 || dimes > 0 || nickels > 0 || pennies > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Your returned change is: {strQtr} {strDime} {strNic} {strPen}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("No change to return.");
            }
            Money = 0;

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }


    }
}
