using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Workflow
{
    public class CheckInventory
    {
        private IVendingItemsRepository fileRepo;

        public CheckInventory(IVendingItemsRepository fileRepo)
        {
            this.fileRepo = fileRepo;
        }

        public bool CheckAvailableInventory(string key)
        {
            Dictionary<string, VendingItem> products = fileRepo.GetAll();

            int currentProductInv = products[key].Inventory;

            if(currentProductInv > 0)
            {
                return true;
            }
            return false;

            
        }
    }
}
