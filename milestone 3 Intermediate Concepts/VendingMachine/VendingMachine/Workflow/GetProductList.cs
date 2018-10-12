using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Workflow
{
    public class GetProductList
    {
        private IVendingItemsRepository fileRepo;

        public GetProductList(IVendingItemsRepository fileRepo)
        {
            this.fileRepo = fileRepo;
        }

        public Dictionary<string, VendingItem> GetProducts()
        {
            
            return new Dictionary<string, VendingItem>(fileRepo.GetAll());
        }
    }
}
