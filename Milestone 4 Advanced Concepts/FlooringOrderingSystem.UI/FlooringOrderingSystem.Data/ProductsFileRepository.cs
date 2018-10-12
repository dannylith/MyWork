using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlooringOrderingSystem.Data
{
    public class ProductsFileRepository: IProductsFileRepository
    {
        private const string filePath = @".\Products.txt";

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    products.Add(new Product
                    {
                        ProductType = columns[0],
                        CostPerSquareFoot = decimal.Parse(columns[1]),
                        LaborCostPerSquareFoot = decimal.Parse(columns[2])

                    });
                }
            }
            return products;
        }

        public Product FindByProductType(string productType)
        {
            return GetAll().Where(p => p.ProductType.ToUpper() == productType.ToUpper()).FirstOrDefault();
        }
    }
}
