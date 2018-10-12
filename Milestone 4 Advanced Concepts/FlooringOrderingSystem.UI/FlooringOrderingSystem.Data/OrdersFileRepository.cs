using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Response;

namespace FlooringOrderingSystem.Data
{
    public class OrdersFileRepository : IOrdersFileRepository
    {
        private const string filePathBegin = @".\Orders_";
        private const string filePathEnd = ".txt";
        JsonRepository jsonRepo = new JsonRepository();
        public IEnumerable<Order> GetAll(string date)
        {
            List<Order> orders = new List<Order>();
            string lookUpPath = filePathBegin + date + filePathEnd;

            if (File.Exists(lookUpPath))
            {
                using (StreamReader sr = new StreamReader(lookUpPath))
                {
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        if (columns.Length == 13)
                        {
                            List<string> notes = columns[12].Split('%').ToList();

                            orders.Add(new Order
                            {
                                OrderNumber = int.Parse(columns[0]),
                                CustomerName = columns[1].Replace("|||", ","),
                                State = columns[2],
                                TaxRate = decimal.Parse(columns[3]),
                                ProductType = columns[4],
                                Area = decimal.Parse(columns[5]),
                                CostPerSquareFoot = decimal.Parse(columns[6]),
                                LaborCostPerSquareFoot = decimal.Parse(columns[7]),
                                MaterialCost = decimal.Parse(columns[8]),
                                LaborCost = decimal.Parse(columns[9]),
                                Tax = decimal.Parse(columns[10]),
                                Total = decimal.Parse(columns[11]),
                                Notes = notes
                            });
                        }
                    }
                }
                return orders;
            }
            return null;
        }

        public Order FindOrderByOrderNumber(int orderNumber, string date)
        {
            return GetAll(date).Where(o => o.OrderNumber == orderNumber).FirstOrDefault();
        }

        public virtual Order AddOrder(Order order, string date)
        {
            List<Order> orders = new List<Order>();
            if (GetAll(date) != null)
            {
                orders = GetAll(date).ToList();
            }
            

            if (orders == null || orders.Count() == 0)
            {
                order.OrderNumber = 1;
                orders.Add(order);
            }
            else
            {
                order.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
                orders.Add(order);
            }


            WriteAll(orders, date);
            return order;
        }

        public int GetCurrentOrderNumber(string date)
        {
            if (GetAll(date) != null && GetAll(date).Count() != 0)
            {
                return GetAll(date).Max(o => o.OrderNumber) + 1;
            }
            return 1;
        }

        public virtual void RemoveOrder(int orderNumber, string date)
        {
            List<Order> orders = GetAll(date).ToList();

            orders.Remove(orders.Where(o => o.OrderNumber == orderNumber).First());
            WriteAll(orders, date);


        }

        public virtual void EditOrder(Order order, string date)
        {
            List<Order> orders = new List<Order>();
            if (GetAll(date) != null)
            {
                orders = GetAll(date).ToList();
            }
            foreach(var o in orders)
            {
                if(o.OrderNumber == order.OrderNumber)
                {
                    o.CustomerName = order.CustomerName;
                    o.State = order.State;
                    o.TaxRate = order.TaxRate;
                    o.ProductType = order.ProductType;
                    o.Area = order.Area;
                    o.CostPerSquareFoot = order.CostPerSquareFoot;
                    o.LaborCostPerSquareFoot = order.LaborCostPerSquareFoot;
                    o.MaterialCost = order.MaterialCost;
                    o.LaborCost = order.LaborCost;
                    o.Tax = order.Tax;
                    o.Total = order.Total;
                }
            }

            WriteAll(orders, date);
        }

        private void WriteAll(List<Order> orders, string date)
        {
            using (StreamWriter sw = new StreamWriter(filePathBegin + date + filePathEnd))
            {

                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var o in orders)
                {
                    string strNotes = string.Join("%", o.Notes);
                    sw.WriteLine($"{o.OrderNumber}," +
                        $"{o.CustomerName.Replace(",", "|||")}," +
                        $"{o.State}," +
                        $"{o.TaxRate}," +
                        $"{o.ProductType}," +
                        $"{o.Area}," +
                        $"{o.CostPerSquareFoot}," +
                        $"{o.LaborCostPerSquareFoot}," +
                        $"{o.MaterialCost}," +
                        $"{o.LaborCost}," +
                        $"{o.Tax}," +
                        $"{o.Total}," +
                        $"{strNotes}");
                }

            }

            jsonRepo.CreateJson(orders, date);
        }

    }
}
