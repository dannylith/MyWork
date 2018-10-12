using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Workflow
{
    public class UpdateVendingRepo
    {

        private IVendingItemsRepository fileRepo;
        private CheckInventory checkInventory;

        public UpdateVendingRepo(IVendingItemsRepository fileRepo)
        {
            this.fileRepo = fileRepo;
        }

        public void UpdateVending()
        {

            Dictionary<string, VendingItem> products = fileRepo.GetAll();

            checkInventory = new CheckInventory(fileRepo);

            string input;
            Console.Write("Which item do you want to buy(ex. A1, A2...): ");
            input = Console.ReadLine().ToUpper();
            if (products.ContainsKey(input))//Checks to make sure the option that the item selected is in the dictionary
            {
                bool inStock = checkInventory.CheckAvailableInventory(input);//check inventory
                if (inStock)
                {
                    bool enoughMoney = CalculateChange.SubtractMoney(input, fileRepo);//subtract money
                    if (!enoughMoney)
                    {
                        Console.Clear();
                        Console.Write("Curent Money: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("$" + CalculateChange.Money);                        
                        Console.WriteLine("\nYou do not have enough money.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else
                    {

                        products[input].Inventory -= 1;

                        fileRepo.UpdateVending(products);

                        CalculateChange.GetQuartDimeNickPen(); //return change
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product not in stock.");
                    Console.ResetColor();
                    Console.ReadKey();

                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That is not a valid option. Going back to Menu.");
                Console.ResetColor();
                Console.ReadKey();
            }

        }
    }
}
