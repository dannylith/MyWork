using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            Exercise31();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var outOfStock = products.Where(p => p.UnitsInStock == 0).Select(p=>p);
            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();
            var inStock = products.Where(p => p.UnitsInStock > 0).Where(p => p.UnitPrice > 3.00M);
            PrintProductInformation(inStock);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customers = DataLoader.LoadCustomers();
            var cInWA = customers.Where(c => c.Region == "WA");
            PrintCustomerInformation(cInWA);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();
            var productName = products.Select(p => new {
                p.ProductName
            });

            foreach (var p in productName)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();
            var priceInc25 = products.Select(p=>new {
                p.Category,
                p.ProductID,
                p.ProductName,
                unitPrice = p.UnitPrice + (p.UnitPrice * .25M),
                p.UnitsInStock
            });

            foreach (var p in priceInc25)
            {
                Console.WriteLine(p);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();
            var toUpper = products.Select(p => new {
                ProductName = p.ProductName.ToUpper(),
                Category = p.Category.ToUpper()
            });

            foreach (var p in toUpper)
            {
                Console.WriteLine(p.Category);
                Console.WriteLine(p.ProductName);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var reOrder = products.Select(p=>new {
                p.Category,
                p.ProductID,
                p.ProductName,
                p.UnitPrice,
                p.UnitsInStock,
                ReOrder = p.UnitsInStock < 3
            });

            foreach (var p in reOrder)
            {
                Console.WriteLine(p.ProductName);
                Console.WriteLine(p.UnitsInStock);
                Console.WriteLine(p.ReOrder);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var reOrder = products.Select(p => new {
                p.Category,
                p.ProductID,
                p.ProductName,
                p.UnitPrice,
                p.UnitsInStock,
                StockValue = p.UnitPrice * p.UnitsInStock
            });

            foreach (var p in reOrder)
            {
                Console.WriteLine(p.ProductName);
                Console.WriteLine(p.UnitsInStock);
                Console.WriteLine(p.StockValue);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var evenA = DataLoader.NumbersA.Where(n => n % 2 == 0);
            foreach (var n in evenA)
            {
                Console.Write(n + " ");
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customers = DataLoader.LoadCustomers();

            var orderLess500 = customers.Where(c => c.Orders.Any(o => o.Total < 500));
            PrintCustomerInformation(orderLess500);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var oddFirst3C = DataLoader.NumbersC.Where(n => n % 2 != 0).Take(3);
            foreach (var n in oddFirst3C)
            {
                Console.Write(n + " ");
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var skip3 = DataLoader.NumbersB.Skip(3);
            foreach (var n in skip3)
            {
                Console.Write(n + " ");
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customers = DataLoader.LoadCustomers();

            var recentOrderWA = customers.Where(p => p.Region == "WA").Select(p => new {
                p.CompanyName,
                recentOrder = p.Orders.OrderByDescending(o => o.OrderDate).Take(1)
            });

            foreach (var c in recentOrderWA)
            {
                Console.WriteLine(c.CompanyName);
                foreach (var o in c.recentOrder)
                {
                    Console.WriteLine(o.OrderDate);
                    Console.WriteLine(o.OrderID);
                    Console.WriteLine(o.Total);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var stopAt6 = DataLoader.NumbersC.TakeWhile(n => n <= 6);
            foreach (var n in stopAt6)
            {
                Console.Write(n + " ");
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var skipTilDivBy3 = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0).Skip(1);
            foreach (var n in skipTilDivBy3)
            {
                Console.Write(n + " ");
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();

            var alphaP = products.OrderBy(p => p.ProductName);
            PrintProductInformation(alphaP);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var alphaP = products.OrderByDescending(p => p.UnitPrice);
            PrintProductInformation(alphaP);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();
            var ordered = products.OrderByDescending(p => p.UnitPrice).OrderBy(p => p.Category);
            PrintProductInformation(ordered);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var reverse = DataLoader.NumbersB.Reverse();
            foreach (var n in reverse)
            {
                Console.Write(n + " ");
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var groupCat = products.GroupBy(p => p.Category);
            foreach(var c in groupCat)
            {
                Console.WriteLine(c.Key);
                foreach (var p in c)
                {
                    Console.WriteLine(p.ProductName);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();

            var print = customers.Select(c => new {
                c.CompanyName,
                orders = c.Orders.OrderBy(o=>o.OrderDate.Month).GroupBy(o=>o.OrderDate.Year)
            });


            foreach(var c in print)
            {
                Console.WriteLine(c.CompanyName);
                foreach(var o in c.orders)
                {
                    Console.WriteLine( o.Key);
                    foreach (var m in o)
                    {
                        //Console.WriteLine(m.OrderDate);
                        Console.WriteLine("  " + m.OrderDate.Month + " -   " + m.Total);
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();

            var uniqueCat = products.GroupBy(p => p.Category);

            foreach (var c in uniqueCat)
            {
                Console.WriteLine(c.Key);

            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();

            var product789 = products.Where(p => p.ProductID == 789);

            Console.WriteLine(product789.Any());
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();

            var catOutOfStock = products.Where(p => p.UnitsInStock == 0).GroupBy(p => p.Category);

            foreach (var c in catOutOfStock)
            {
                Console.WriteLine(c.Key);
                foreach(var p in c)
                {
                    Console.WriteLine("   " + p.ProductName);
                    Console.WriteLine("   Stock: " + p.UnitsInStock);
                }
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            var catInStock = products.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category);

            foreach (var c in catInStock)
            {
                Console.WriteLine(c.Key);
                foreach (var p in c)
                {
                    Console.Write("   " + p.ProductName);
                    Console.WriteLine("   Stock: " + p.UnitsInStock);
                }
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var oddA = DataLoader.NumbersA.Where(n => n % 2 != 0 ).Count();
            Console.WriteLine(oddA);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();

            var countOrders = customers.Select(p=> new {
                p.CustomerID,
                ordersCount = p.Orders.Count()
            });

            foreach (var c in countOrders)
            {
                Console.WriteLine(c.CustomerID);
                Console.WriteLine("Orders Count: " + c.ordersCount);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();

            var distinctListofCatAndCount = products.GroupBy(p => p.Category).Select(g => new
            {
                category = g.Key,
                productCount = g.Key.Count()
            });

            foreach (var c in distinctListofCatAndCount)
            {
                Console.WriteLine(c.category);
                Console.WriteLine(c.productCount);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> products = DataLoader.LoadProducts();

            var catTotalUnitsInStock = products.GroupBy(p => p.Category).Select(g => new
            {
                category = g.Key,
                totalUnitsInStock = g.Sum(f => f.UnitsInStock)
            });

            foreach (var c in catTotalUnitsInStock)
            {
                Console.WriteLine(c.category);
                Console.WriteLine("Total Units in Stock: " + c.totalUnitsInStock);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();

            var lowestPriceInCat = products.GroupBy(p => p.Category).Select(g => new {
                category = g.Key,
                lowestPrice = g.Min(f=>f.UnitPrice)
            });

            foreach (var p in lowestPriceInCat)
            {
                Console.WriteLine(p.category);
                Console.WriteLine("Lowest Price: "+p.lowestPrice);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();

            var top3CatAvgUnit = products.GroupBy(p => p.Category).Select(g=> new {
                category = g.Key,
                average = g.Average(f=> f.UnitPrice)
            }).OrderByDescending(o=>o.average).Take(3);

            foreach (var c in top3CatAvgUnit)
            {
                Console.WriteLine(c.category);
                Console.WriteLine("Average: "+c.average);
                Console.WriteLine();
            }

        }
    }
}
