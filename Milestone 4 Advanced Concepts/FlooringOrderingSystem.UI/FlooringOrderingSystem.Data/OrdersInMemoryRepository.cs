using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public class OrdersInMemoryRepository
    {
        private Dictionary<string, List<Order>> ordersDictionary = new Dictionary<string, List<Order>>();
        List<Order> ordersList = new List<Order>();
        private int currentID;

        /// <summary>
        /// This class isn't being used. I was trying to make an in memory version but was taking longer than expected
        /// May or may not revisit.
        /// </summary>
        public OrdersInMemoryRepository()
        {
            ordersList.Add(new Order
            {
                OrderNumber = 1,
                CustomerName = "Wise",
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
            });
            ordersDictionary.Add("06012013", ordersList);
        }
        public List<Order> GetFileFromDate(string date)
        {
            if (ordersDictionary.ContainsKey(date))
            {
                currentID = ordersDictionary[date].Count() + 1;
                return ordersDictionary[date];
            }
            return null;

        }

        public void AddOrder(Order order, string date)
        {
            if (ordersDictionary.ContainsKey(date))
            {
                List<Order> newOrders = new List<Order>();
                newOrders = ordersDictionary[date];
                currentID = newOrders.Count() + 1;
                order.OrderNumber = currentID;
                newOrders.Add(order);
                ordersDictionary[date] = newOrders;
            }
            else
            {
                List<Order> newOrders = new List<Order>();
                order.OrderNumber = 1;
                newOrders.Add(order);
                ordersDictionary.Add(date, newOrders);
            }
        }
    }
}
