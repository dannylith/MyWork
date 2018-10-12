using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMenu vending = new VendingMenu();
            vending.DisplayMenu();
        }
    }
}
