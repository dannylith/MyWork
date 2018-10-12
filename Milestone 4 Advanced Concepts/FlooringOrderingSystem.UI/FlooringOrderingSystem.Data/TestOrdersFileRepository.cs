using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public class TestOrdersFileRepository : OrdersFileRepository
    {
        public override Order AddOrder(Order order, string date)
        {
            return order;
        }
        public override void RemoveOrder(int orderNumber, string date) { }
        public override void EditOrder(Order order, string date) { }
    }
}
