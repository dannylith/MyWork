using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSalad
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] fruit = { "Kiwi Fruit", "Gala Apple", "Granny Smith Apple", "Cherry Tomato", "Gooseberry", "Beefsteak Tomato", "Braeburn Apple", "Blueberry", "Strawberry", "Navel Orange", "Pink Pearl Apple", "Raspberry", "Blood Orange", "Sungold Tomato", "Fuji Apple", "Blackberry", "Banana", "Pineapple", "Florida Orange", "Kiku Apple", "Mango", "Satsuma Orange", "Watermelon", "Snozzberry" };

            String[] fruitSalad = new string[12];

            int counter = 0, appleCount = 0, orangeCount = 0;

            // Code Recipe for fruit salad should go here!
            for(int i = 0; i < fruit.Length; i++)
            {
                if (fruit[i].Contains("Apple") && appleCount <= 3 && counter < 12)
                {
                    
                    fruitSalad[counter] = fruit[i];
                    counter++;
                    appleCount++;

                }
                else if (fruit[i].Contains("Orange") && orangeCount <= 2 && counter < 12)
                {
                    
                    fruitSalad[counter] = fruit[i];
                    counter++;
                    orangeCount++;

                }
                else if (!fruit[i].Contains("Tomato") && counter < 12 && !fruit[i].Contains("Orange") && !fruit[i].Contains("Apple"))
                {
                    fruitSalad[counter] = fruit[i];
                    counter++;
                }
            }

            Console.WriteLine($"Total number of fruits: {fruitSalad.Length}");
            for(int i=0; i<fruitSalad.Length;i++)
            {
                Console.Write($"{fruitSalad[i]}- ");
            }
            Console.ReadKey();
        }
    }
}
