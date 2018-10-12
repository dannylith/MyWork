using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Data
{
    public interface IVendingItemsRepository
    {
        Dictionary<string, VendingItem> GetAll();
        void UpdateVending(Dictionary<string, VendingItem> newProducts);
    }
}
