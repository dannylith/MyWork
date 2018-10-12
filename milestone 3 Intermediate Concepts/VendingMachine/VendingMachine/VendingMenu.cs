using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Workflow;

namespace VendingMachine
{
    public class VendingMenu
    {

        //IVendingItemsRepository fileRepo = new VendingInFileRepository(@".\VendingItems.txt");
        IVendingItemsRepository fileRepo = new VendingInMemoryRepository();
        GetProductList getProductList;
        UpdateVendingRepo updateVendingRepo;

        public void DisplayMenu()
        {


            getProductList = new GetProductList(fileRepo);
            updateVendingRepo = new UpdateVendingRepo(fileRepo);

            AsciiArt();
            Console.WriteLine();
            new CalculateChange(ConsoleIO.ReadDecimailInRange("How Much money do you want to put into the vending machine: ", 0, 100));

            int selection = 0;
            do
            {
                Console.Clear();
                Dictionary<string, VendingItem> products = getProductList.GetProducts();
                AsciiArt();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Current Money: ${CalculateChange.Money}");
                Console.ResetColor();
                selection = ConsoleIO.SelectFromMenu();
                switch (selection)
                {
                    case 1:                      
                        CalculateChange.AddMoney();
                        break;
                    case 2:
                        Console.Clear();
                        AsciiArt();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Current Money: ${CalculateChange.Money}");
                        Console.ResetColor();
                        updateVendingRepo.UpdateVending();
                        break;

                }
                
            } while (selection > 0 && selection < 3);

            Console.Clear();
            Console.WriteLine("GOODBYE!");
            Console.ReadKey();
        }

        //displays a border with the vending options inside it
        private void AsciiArt()
        {
            getProductList = new GetProductList(fileRepo);
            updateVendingRepo = new UpdateVendingRepo(fileRepo);
            Dictionary<string, VendingItem> products = getProductList.GetProducts();
            string a1ItemName = MessageProductName(products, "A1");
            string a2ItemName = MessageProductName(products, "A2");
            string a3ItemName = MessageProductName(products, "A3");
            string b1ItemName = MessageProductName(products, "B1");
            string b2ItemName = MessageProductName(products, "B2");
            string b3ItemName = MessageProductName(products, "B3");
            string a1Price = MessageProductPrice(products, "A1");
            string a2Price = MessageProductPrice(products, "A2");
            string a3Price = MessageProductPrice(products, "A3");
            string b1Price = MessageProductPrice(products, "B1");
            string b2Price = MessageProductPrice(products, "B2");
            string b3Price = MessageProductPrice(products, "B3");

            Console.WriteLine("(_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_)");
            Console.Write("##");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("      {0,-10}{1,-10}{2,-10}", "A1", "A2","A3");
            Console.ResetColor();
            Console.WriteLine("##   {0,-12}{1,-10}{2}", a1ItemName, a2ItemName, a3ItemName);
            Console.WriteLine("##   {0,-11}{1,-10}{2}", a1Price, a2Price, a3Price);
            Console.WriteLine("##");
            Console.WriteLine("##");
            Console.Write("##");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("      {0,-10}{1,-10}{2,-10}", "B1", "B2", "B3");
            Console.ResetColor();
            Console.WriteLine("##    {0,-11}{1,-10}{2}", b1ItemName, b2ItemName, b3ItemName);
            Console.WriteLine("##   {0,-11}{1,-11}{2}", b1Price, b2Price, b3Price);
            Console.WriteLine("(_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_}{_)");
        }

        //return an empty string or the product name
        private string MessageProductName(Dictionary<string, VendingItem> products, string key)
        {
            if(products[key].Inventory > 0)
            {
                return products[key].ItemName;
            }
            return "";
        }
        //return an empty string or the product price
        private string MessageProductPrice(Dictionary<string, VendingItem> products, string key)
        {
            if (products[key].Inventory > 0)
            {
                return "$"+products[key].Price.ToString();
            }
            return "";
        }



    }
}
