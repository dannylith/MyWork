using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingItem
    {
        public string VendingPosition{get;set;}
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }

        public VendingItem(string position, string itemName, decimal price, int inventory)
        {
            VendingPosition = position;
            ItemName = itemName;
            Price = price;
            Inventory = inventory;
        }
    }
}
