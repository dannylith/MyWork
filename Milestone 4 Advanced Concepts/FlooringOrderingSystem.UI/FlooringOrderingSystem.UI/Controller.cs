using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UI
{
    public class Controller
    {
        private Service service;
        Regex regex = new Regex(@"^[A-Za-z0-9.,]+[A-Za-z0-9.,\s]+$");
        private DateTime currentDate = DateTime.Today;

        public Controller(IOrdersFileRepository ordersRepo, ITaxFileRepository taxRepo, IProductsFileRepository productRepo)
        {
            this.service = new Service(ordersRepo, taxRepo, productRepo);
        }
        public void Run()
        {
            //string line;
            //List<string> linesList = new List<string>();
            //while((line = Console.ReadLine()) != "exit")
            //{
            //    if(line != "exit")
            //    {
            //        linesList.Add(line);
            //    }
            //}
            //Console.WriteLine();
            //foreach (var l in linesList)
            //{
            //    Console.WriteLine(l);
            //}
            //string x = string.Join("%", linesList);
            //Console.WriteLine(x);
            //List<string> newList = x.Split('%').ToList();
            //foreach (var l in newList)
            //{
            //    Console.WriteLine(l);
            //}
            //Console.ReadKey();

            //Menu options
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Program ");
                LineSeparator();
                Console.WriteLine("1. Display Orders ");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        DisplayOrdersFromDate();
                        break;
                    case "2":
                        AddOrder();
                        break;
                    case "3":
                        EditOrder();
                        break;
                    case "4":
                        RemoveOrder();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Not a valid option. Try again.");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void LineSeparator()
        {
            Console.WriteLine("==================================================");
        }

        public DateTime ValidateDate(string prompt)
        {
            DateTime date;
            do//keep looping unitl the date is valid
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Date format. Try again.");
                    Console.ResetColor();
                }
            } while (true);

            return date;
        }

        public string ValidateName(string prompt, bool allowEmptySpace = false)
        {
            string name;
            do
            {//validate name; only accepting a-z(,)(.) and spaces
                Console.Write(prompt);
                name = Console.ReadLine();
                if (allowEmptySpace && string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                if (!regex.IsMatch(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Name format. Try again.");
                    Console.ResetColor();
                }
            } while (!regex.IsMatch(name));

            return name;
        }

        public TaxResponse ValidateTaxUserInput(bool allowEmptySpace = false)
        {
            string state;
            TaxResponse taxResponse;
            do//get tax information and make sure data matches user's input or keep looping
            {
                Console.Write("State: ");
                state = Console.ReadLine();
                if (allowEmptySpace && string.IsNullOrWhiteSpace(state))
                {
                    taxResponse = new TaxResponse();
                    return taxResponse;
                }
                taxResponse = service.GetTaxFromTaxFile(state);
                if (!taxResponse.Success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(taxResponse.Message + " Try again.");
                    Console.ResetColor();
                }
            } while (!taxResponse.Success);
            return taxResponse;
        }

        public ProductResponse ValidateProductUserInput(bool allowEmptySpace = false)
        {
            DisplayProducts();
            ProductResponse productResponse;
            string productChoice;
            do//loop until valid product is choosen
            {
                Console.Write("Product Name: ");
                productChoice = Console.ReadLine();
                if (allowEmptySpace && string.IsNullOrWhiteSpace(productChoice))
                {
                    productResponse = new ProductResponse();
                    productResponse.product = null;
                    return productResponse;
                }
                productResponse = service.GetProductByProductType(productChoice);
                if (productResponse.Success)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(productResponse.Message + " Try again.");
                    Console.ResetColor();
                }
            } while (true);
            return productResponse;
        }

        public int ValidateAreaUserInput(bool allowEmptySpace = false)
        {
            int area;
            string input;
            do
            {//loop until a valid number over 100 is inputted
                Console.Write("What is the Area size: ");
                input = Console.ReadLine();
                if (allowEmptySpace && string.IsNullOrWhiteSpace(input))
                {
                    return 0;
                }
                if (int.TryParse(input, out area))
                {
                    if (area < 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Minimum order size is 100 square feet. Try again.");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.");
                    Console.ResetColor();
                }
            } while (true);

            return area;
        }

        public bool YesOrNo(string prompt)
        {
            do
            {//loop until user chooses yes or no
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.ResetColor();
                }
            } while (true);
        }

        public int ValidateIntegerUserInput(string prompt)
        {
            string input;
            int inputToInt;
            do
            {//loop unitl valid integer is chosen
                Console.Write(prompt);
                input = Console.ReadLine();
                if (int.TryParse(input, out inputToInt))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a number. Try again.");
                    Console.ResetColor();
                }
            } while (true);
            return inputToInt;

        }


        public void DisplayOrdersFromDate()
        {
            Console.Clear();
            GetListFromRepoResponse response;
            Console.WriteLine("Orders Lookup");
            LineSeparator();
            DateTime date = ValidateDate("What date do you want to lookup: ");

            response = service.GetFileFromDate(date);//get orders from repository

            if (response.Success)//display if any
            {

                foreach (var o in response.Orders)
                {
                    DisplayOrder(o, date);
                }

            }
            else//error message about no data
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ResetColor();
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public void DisplayOrder(Order o, DateTime date)
        {
            //display a single order information
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Order Number: {o.OrderNumber} | Date: {date.ToString("MM-dd-yyy")}\n");
            Console.WriteLine($"Name: {o.CustomerName}");
            Console.WriteLine($"State: {o.State}");
            Console.WriteLine($"Product: {o.ProductType}");
            Console.WriteLine($"Materials Cost: {o.MaterialCost:c}");
            Console.WriteLine($"Labor: {o.LaborCost:c}");
            Console.WriteLine($"Tax: {o.Tax:c}");
            Console.WriteLine($"Total: {o.Total:c}");
            Console.WriteLine("Notes: ");
            foreach (var l in o.Notes)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public void AddOrder()
        {
            Console.Clear();
            Console.WriteLine("Add an Order");
            LineSeparator();
            DateTime date;
            do
            {//loop until the date input is valid and is today or in the future
                Console.Write("What date is this order for: ");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    if (date < currentDate)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cannot add to past days. Try again.");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Date format. Try again.");
                    Console.ResetColor();
                }
            } while (true);

            //ask for input and validate it
            string name = ValidateName("Enter the customer name: ");
            TaxResponse taxResponse = ValidateTaxUserInput();
            ProductResponse productResponse = ValidateProductUserInput();
            int area = ValidateAreaUserInput();
            string line;
            List<string> notes = new List<string>();
            Console.WriteLine("Notes(Type 'exit' in a new line to exit notes): ");
            while((line = Console.ReadLine()) != "exit")
            {
                if (line != "exit")
                {
                    notes.Add(line);
                }
            }

            //create an order and assign all it's properties
            Order order = new Order();
            order.OrderNumber = service.GetCurrentOrderNumber(date);
            order.CustomerName = name;
            order.State = taxResponse.tax.StateAbbreviation;
            order.ProductType = productResponse.product.ProductType;
            order.Area = area;
            order.TaxRate = taxResponse.tax.TaxRate;
            order.CostPerSquareFoot = productResponse.product.CostPerSquareFoot;
            order.LaborCostPerSquareFoot = productResponse.product.LaborCostPerSquareFoot;
            order.Notes = notes;
            order = service.CalculateOrder(order);
            Console.Clear();
            DisplayOrder(order, date);

            Console.WriteLine();
            if (YesOrNo("Are you sure you want to add the order(y/n): "))
            {
                service.AddOrder(order, date);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Succesfully Added.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Order not added. Returning to menu.");
                Console.ResetColor();
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();

        }


        public void DisplayProducts()
        {
            List<Product> products = service.GetProductsList();
            Console.WriteLine($"{"Product",-12}  {"Price Per Square Ft",-20}  Labor Cost Per Square Ft");
            LineSeparator();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductType,-15}{p.CostPerSquareFoot,-20:c}{p.LaborCostPerSquareFoot:c}");
            }
            Console.WriteLine();
        }

        public void EditOrder()
        {
            Console.Clear();
            Console.WriteLine("Add an Order");
            LineSeparator();
            DateTime date = ValidateDate("What date do you want to lookup: ");

            GetListFromRepoResponse response;
            OrderResponse orderResponse;
            response = service.GetFileFromDate(date);
            if (response.Success)
            {
                foreach (var o in response.Orders)
                {
                    DisplayOrder(o, date);
                }
                //check to make order number exist
                int orderNumber = ValidateIntegerUserInput("Which Order Number do you want to modify: ");
                orderResponse = service.GetOrder(orderNumber, date);
                if (!orderResponse.Success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(orderResponse.Message);//error message if order doesn't exist
                    Console.ResetColor();
                }
                else
                {//if order exist, get input on what to modify
                    Console.Clear();
                    DisplayOrder(orderResponse.order, date);
                    Console.WriteLine();
                    string name = ValidateName("What is the new name: ", true);
                    TaxResponse taxResponse = ValidateTaxUserInput(true);
                    ProductResponse productResponse = ValidateProductUserInput(true);
                    int area = ValidateAreaUserInput(true);

                    //assign order with updated information then recalculate
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        orderResponse.order.CustomerName = name;
                    }
                    if (taxResponse.tax != null)
                    {
                        orderResponse.order.State = taxResponse.tax.StateAbbreviation;
                    }
                    if (productResponse.product != null)
                    {
                        orderResponse.order.ProductType = productResponse.product.ProductType;
                    }
                    if (area != 0)
                    {
                        orderResponse.order.Area = area;
                    }
                    orderResponse.order = service.CalculateOrder(orderResponse.order);
                    DisplayOrder(orderResponse.order, date);

                    Console.WriteLine();
                    if (YesOrNo("Are you sure you want to modify the order(y/n): "))
                    {
                        Response responseGoodOrBad = service.EditOrder(orderResponse.order, date);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (responseGoodOrBad.Success)
                        {
                            Console.WriteLine("Succesfully modified.");
                        }
                        else
                        {
                            Console.WriteLine("There was an error: ");
                            Console.WriteLine(responseGoodOrBad.Message);
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Order not modified. Returning to menu.");
                        Console.ResetColor();
                    }

                }

            }
            else
            {//error message no file found from date
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ResetColor();
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public void RemoveOrder()
        {
            Console.Clear();
            Console.WriteLine("Remove an Order");
            LineSeparator();
            DateTime date = ValidateDate("What date do you want to lookup: ");

            GetListFromRepoResponse response;
            OrderResponse orderResponse;
            response = service.GetFileFromDate(date);
            if (response.Success)
            {//lookup order number
                foreach (var o in response.Orders)
                {
                    DisplayOrder(o, date);
                }
                int orderNumber = ValidateIntegerUserInput("Which Order Number: ");
                orderResponse = service.GetOrder(orderNumber, date);
                if (!orderResponse.Success)
                {
                    Console.WriteLine(response.Message);
                }
                else
                {
                    if(YesOrNo("Are you sure you want to delete(y/n)? "))
                    {
                        var respsoneGoodOrBad = service.removeOrder(orderNumber, date);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (respsoneGoodOrBad.Success)
                        {
                            Console.WriteLine("Succesfully Deleted.");
                        }
                        else
                        {
                            Console.WriteLine("There was an error: ");
                            Console.WriteLine(respsoneGoodOrBad.Message);
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Order not deleted. Returning to menu.");
                        Console.ResetColor();
                    }

                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ResetColor();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }
}
