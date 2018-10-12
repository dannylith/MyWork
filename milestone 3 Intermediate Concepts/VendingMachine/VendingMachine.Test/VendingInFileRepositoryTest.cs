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
    public class VendingInFileRepositoryTest
    {
        private const string filePath = @"C:\Test\VendingItemsTest.txt";
        private const string originalData = @"C:\Test\VendingItemsTestSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Copy(originalData, filePath);
        }

        [Test]
        public void CanGetAllFromVendingInFile()
        {
            IVendingItemsRepository repo = new VendingInFileRepository(filePath);
            Dictionary<string, VendingItem> products = repo.GetAll();


            var result = products["A1"];
            Assert.AreEqual("Snickers", result.ItemName);

            Assert.AreEqual("A1", result.VendingPosition);

            Assert.AreEqual(2.00M, result.Price);

            Assert.AreEqual(10, result.Inventory);
        }

        [Test]
        public void CanUpdateVendingInFile()
        {
            IVendingItemsRepository repo = new VendingInFileRepository(filePath);
            Dictionary<string, VendingItem> products = repo.GetAll();

            products["A1"].Inventory = 5;

            repo.UpdateVending(products);
            var result = repo.GetAll();

            Assert.AreEqual(5, result["A1"].Inventory);

        }
    }
}
