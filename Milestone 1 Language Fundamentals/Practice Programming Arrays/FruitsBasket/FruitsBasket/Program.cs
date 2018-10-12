using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] fruit = { "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Apple", "Apple", "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Orange", "Orange", "Orange", "Apple", "Apple", "Apple", "Apple", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Orange" };
            string[] orange, apple;
            int intOrangeCount = 0, intAppleCount = 0;


            // Fruit sorting code goes here!
            for (int i = 0; i < fruit.Length; i++)
            {
                if (fruit[i] == "Apple")
                {
                    intAppleCount += 1;
                }
                else
                {
                    intOrangeCount += 1;
                }
            }

            orange = new string[intOrangeCount];
            apple = new string[intAppleCount];

            for (int i = 0; i < fruit.Length; i++)
            {
                if (fruit[i] == "Apple")
                {
                    int x = 0;
                    apple[x] = fruit[i];
                    x++;
                }
                else
                {
                    int x = 0;
                    orange[x] = fruit[i];
                    x++;
                }
            }

            Console.WriteLine($"Total# of Fruit in Basket: {fruit.Length}");
            Console.WriteLine($"Number of Apples: {apple.Length}");
            Console.WriteLine($"Number of Oranges: {orange.Length}");

            Console.ReadKey();

        }
    }
}
