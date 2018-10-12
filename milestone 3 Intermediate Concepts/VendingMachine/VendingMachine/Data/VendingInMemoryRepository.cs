using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Data
{
    public class VendingInMemoryRepository : IVendingItemsRepository
    {
        private Dictionary<string, VendingItem> products = new Dictionary<string, VendingItem>();
        public VendingInMemoryRepository()
        {
            products.Add("A1", new VendingItem("A1", "Snickers", 2.00M, 10));
            products.Add("A2", new VendingItem("A2", "Twix", 1.50M, 5));
            products.Add("A3", new VendingItem("A3", "Water", 1.00M, 4));
            products.Add("B1", new VendingItem("B1", "Coke", 1.50M, 10));
            products.Add("B2", new VendingItem("B2", "Gum", 2.50M, 6));
            products.Add("B3", new VendingItem("B3", "Headphones", 10.50M, 4));
        }

        public Dictionary<string, VendingItem> GetAll()
        {
            return products;
        }

        public void UpdateVending(Dictionary<string, VendingItem> newProducts)
        {
            products = newProducts;
        }
    }
}
