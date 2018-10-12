using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class Service
    {
        private IOrdersFileRepository repo;
        private ITaxFileRepository taxRepo;
        private IProductsFileRepository productRepo;
        public Service(IOrdersFileRepository repo, ITaxFileRepository taxRepo, IProductsFileRepository productRepo)
        {
            this.repo = repo;
            this.taxRepo = taxRepo;
            this. productRepo = productRepo;
        }

        public GetListFromRepoResponse GetFileFromDate(DateTime date)
        {
            GetListFromRepoResponse response = new GetListFromRepoResponse();
            var file = repo.GetAll(date.ToString("MMddyyyy"));

            if(file == null || file.Count() == 0)
            {
                response.Success = false;
                response.Message = "There was no orders found on that date.";
                return response;
            }

            response.Success = true;
            response.Orders = file.ToList();

            return response;
        }

        public OrderResponse AddOrder(Order order, DateTime date)
        {
            OrderResponse response = new OrderResponse();
            TaxResponse taxResponse = new TaxResponse();
            ProductResponse productRepsone = new ProductResponse();
            productRepsone.product = productRepo.FindByProductType(order.ProductType);
            taxResponse.tax = taxRepo.FindByState(order.State);

            if (date < DateTime.Today)
            {
                response.Success = false;
                response.Message = "Cannot add to past days.";
                return response;
            }
            if (string.IsNullOrWhiteSpace(order.CustomerName) || order.Area < 100 || taxResponse.tax == null || productRepsone.product == null)
            {
                response.Success = false;
                response.Message = "Missing some required fields or invalid inputs.";
                return response;
            }

            order = CalculateOrder(order);


            order.OrderNumber = repo.AddOrder(order, date.ToString("MMddyyyy")).OrderNumber;

            response.Success = true;
            response.order = order;
            return response;
        }

        public Order CalculateOrder(Order order)
        {
            order.MaterialCost = Math.Round(order.Area * order.CostPerSquareFoot, 2);
            order.LaborCost = Math.Round(order.Area * order.LaborCostPerSquareFoot, 2);
            order.Tax = Math.Round(((order.MaterialCost + order.LaborCost) * (order.TaxRate / 100)), 2);
            order.Total = Math.Round((order.MaterialCost + order.LaborCost + order.Tax), 2);

            return order;
        }

        public OrderResponse GetOrder(int orderNumber, DateTime date)
        {
            OrderResponse response = new OrderResponse();

            Order order = repo.FindOrderByOrderNumber(orderNumber, date.ToString("MMddyyyy"));

            if (order != null)
            {
                response.order = order;
                response.Success = true;
                return response;
            }
            response.Success = false;
            response.Message = "Order not found.";
            return response;
        }

        public OrderResponse RemoveOrder(int orderNumber, DateTime date)
        {
            OrderResponse response = new OrderResponse();
            Order order = repo.FindOrderByOrderNumber(orderNumber, date.ToString("MMddyyyy"));

            if (order == null)
            {
                response.Success = false;
                response.Message = "Order cannot be found.";
                return response;
            }

            repo.RemoveOrder(orderNumber, date.ToString("MMddyyyy"));
            response.Success = true;

            return response;
        }

        public TaxResponse GetTaxFromTaxFile(string state)
        {
            TaxResponse response = new TaxResponse();

            Tax tax = taxRepo.FindByState(state.ToUpper());
            if(tax == null)
            {
                response.Success = false;
                response.Message = "Not allowed to sell to that state.";
                return response;
            }
            response.tax = tax;
            response.Success = true;

            return response;

        }
        public ProductResponse GetProductByProductType(string productType)
        {
            ProductResponse response = new ProductResponse();

            response.Success = true;
            response.product = productRepo.FindByProductType(productType);

            if(response.product == null)
            {
                response.Success = false;
                response.Message = "That Product does not exist.";
                return response;
            }
            response.Success = true;

            return response;
        }

        public List<Product> GetProductsList()
        {
            return productRepo.GetAll().ToList();

        }

        public int GetCurrentOrderNumber(DateTime date)
        {
            return repo.GetCurrentOrderNumber(date.ToString("MMddyyy"));
        }

        public Response EditOrder(Order order, DateTime date)
        {
            Response response = new Response();
            TaxResponse taxResponse = new TaxResponse();
            ProductResponse productRepsone = new ProductResponse();
            OrderResponse orderResponse = new OrderResponse();
            orderResponse = GetOrder(order.OrderNumber, date);
            productRepsone.product = productRepo.FindByProductType(order.ProductType);
            taxResponse.tax = taxRepo.FindByState(order.State);
            if (!orderResponse.Success)
            {
                response.Success = false;
                response.Message = orderResponse.Message;
                return response;
            }
            if (string.IsNullOrWhiteSpace(order.CustomerName) || order.Area < 100 || taxResponse.tax ==null || productRepsone.product == null)
            {
                response.Success = false;
                response.Message = "Missing some required fields or invalid inputs.";
                return response;
            }
            response.Success = true;
            order = CalculateOrder(order);
            repo.EditOrder(order, date.ToString("MMddyyyy"));
            return response;
        }

        public Response removeOrder(int orderNumber, DateTime date)
        {
            Response response = new Response();
            var orderResponse = GetOrder(orderNumber, date);

            if (!orderResponse.Success)
            {
                response.Success = false;
                response.Message = "Order was not found.";
                return response;
            }

            response.Success = true;
            repo.RemoveOrder(orderNumber, date.ToString("MMddyyy"));

            return response;
        }
    }
}
