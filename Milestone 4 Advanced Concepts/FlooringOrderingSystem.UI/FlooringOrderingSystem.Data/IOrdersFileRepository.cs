using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public interface IOrdersFileRepository
    {
        IEnumerable<Order> GetAll(string date);
        Order AddOrder(Order order, string date);
        int GetCurrentOrderNumber(string date);
        void RemoveOrder(int orderNumber, string date);
        void EditOrder(Order order, string date);
        Order FindOrderByOrderNumber(int orderNumber, string date);
    }
}
