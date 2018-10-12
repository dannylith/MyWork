using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public interface IProductsFileRepository
    {
        IEnumerable<Product> GetAll();
        Product FindByProductType(string productType);
    }
}
