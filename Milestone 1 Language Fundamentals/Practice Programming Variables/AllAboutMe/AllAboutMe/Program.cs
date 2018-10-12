using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAboutMe
{
    class Program
    {
        static void Main(string[] args)
        {

            string name, food, haveNotEatenGnocchi;
            int petOwned, ageWhistled;

            name = "my name is Danny Lithyouvong";
            food = "My favorite food is pizza.";
            haveNotEatenGnocchi = "I have not eaten Gnocchi";
            petOwned = 0;
            ageWhistled = 13;

            Console.WriteLine(name);
            Console.WriteLine(food);
            Console.WriteLine(haveNotEatenGnocchi);
            Console.WriteLine("I own " + petOwned + " pet.");
            Console.WriteLine("I whisteld at the age of " + ageWhistled);

            Console.ReadKey();

        }
    }
}
