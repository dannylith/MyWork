using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Models;
using NUnit.Framework;
using System.IO;

namespace FlooringOrderingSystem.Tests
{
    [TestFixture]
    public class ServiceTests
    {
        private const string filePath = @"Orders_06012030.txt";



        [Test]
        public void CanAddAndCreateFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }


            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");
            Order order = new Order
            {
                CustomerName = "Test",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M
            };

            var actual = service.AddOrder(order, date);
            Assert.IsTrue(actual.Success);
            actual = service.AddOrder(order, date);
            Assert.IsTrue(actual.Success);
            actual = service.AddOrder(order, date);
            Assert.IsTrue(actual.Success);






        }

        [Test]
        public void CanGetFileFromDate()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");

            var actual = service.GetFileFromDate(date);

            Assert.IsTrue(actual.Success);
        }

        [Test]
        public void NoFileToGetFromGetFileFromDate()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2025");

            var actual = service.GetFileFromDate(date);

            Assert.IsFalse(actual.Success);
        }



        [Test]
        public void CanGetOrder()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");



            var actual = service.GetOrder(1, date);

            Assert.IsTrue(actual.Success);
        }

        [Test]
        public void CanNotGetOrder()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");

            var actual = service.GetOrder(10, date);

            Assert.IsFalse(actual.Success);
        }
        [Test]
        public void CanRemoveOrderFromFile()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");

            var actual = service.RemoveOrder(2, date);

            Assert.IsTrue(actual.Success);
        }

        [Test]
        public void CanNotRemoveOrderFromFile()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");

            var actual = service.RemoveOrder(100, date);

            Assert.IsFalse(actual.Success);
        }

        [Test]
        public void CanNotAddToFile()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");
            Order order = new Order
            {
                CustomerName = "",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M
            };

            var actual = service.AddOrder(order, date);

            Assert.IsFalse(actual.Success);
        }

        [Test]
        public void CalculateOrder()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            Order order = new Order
            {
                CustomerName = "Test",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            };

            var actual = service.CalculateOrder(order);

            Assert.AreEqual(515.00M, actual.MaterialCost);
            Assert.AreEqual(475.00M, actual.LaborCost);
            Assert.AreEqual(61.88M, actual.Tax);
            Assert.AreEqual(1051.88M, actual.Total);
        }

        [Test]
        public void CanEditOrder()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");
            Order order = new Order
            {
                OrderNumber = 1,
                CustomerName = "Test",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M
            };

            var actual = service.EditOrder(order, date);

            Assert.IsTrue(actual.Success);
        }

        [Test]
        public void CanNotEditOrder()
        {
            Service service = new Service(new OrdersFileRepository(), new TaxFileRepository(), new ProductsFileRepository());
            DateTime date = DateTime.Parse("June 1, 2030");
            Order order = new Order
            {
                CustomerName = "",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M
            };

            var actual = service.EditOrder(order, date);

            Assert.IsFalse(actual.Success);
        }
    }
}
