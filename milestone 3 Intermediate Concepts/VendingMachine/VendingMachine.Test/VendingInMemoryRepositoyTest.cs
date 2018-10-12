using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VendingMachine.Data;

namespace VendingMachine.Test
{
    [TestFixture]
    public class VendingInMemoryRepositoyTest
    {
        

        [Test]
        public void CanGetAllFromVendingInMemory()
        {
            IVendingItemsRepository repo = new VendingInMemoryRepository();
            Dictionary<string, VendingItem> products = repo.GetAll();


            var result = products["A1"];
            Assert.AreEqual("Snickers", result.ItemName);

            Assert.AreEqual("A1", result.VendingPosition);

            Assert.AreEqual(2.00M, result.Price);

            Assert.AreEqual(10, result.Inventory);
        }

        [Test]
        public void CanUpdateVendingInMemory()
        {
            IVendingItemsRepository repo = new VendingInMemoryRepository();
            Dictionary<string, VendingItem> products = repo.GetAll();

            products["A1"].Inventory = 3;

            repo.UpdateVending(products);
            var result = repo.GetAll();

            Assert.AreEqual(3, result["A1"].Inventory);

        }

        

    }
}
