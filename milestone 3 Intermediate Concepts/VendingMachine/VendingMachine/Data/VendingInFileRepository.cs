using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VendingMachine.Data
{
    public class VendingInFileRepository : IVendingItemsRepository
    {
        private string path = @".\VendingItems.txt";
        private Dictionary<string, VendingItem> products;

        public VendingInFileRepository(string filePath)
        {
            this.path = filePath;
        }

        public Dictionary<string, VendingItem> GetAll()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                products = new Dictionary<string, VendingItem>();


                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    products.Add(columns[0], new VendingItem(columns[0], columns[1], decimal.Parse(columns[2]), int.Parse(columns[3])));
                }
            }
            return products;
        }

        public void UpdateVending(Dictionary<string, VendingItem> newProducts)
        {

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var product in newProducts)
                {
                    writer.WriteLine($"{product.Value.VendingPosition},{product.Value.ItemName},{product.Value.Price},{product.Value.Inventory}");
                }
            }
        }
    }
}
