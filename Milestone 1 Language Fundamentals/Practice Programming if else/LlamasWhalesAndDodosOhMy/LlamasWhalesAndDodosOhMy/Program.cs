﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamasWhalesAndDodosOhMy
{
    class Program
    {
        static void Main(string[] args)
        {
            int llamas = 20;
            int whales = 15;
            int dodos = 0;

            if (dodos > 0)
            {
                Console.WriteLine("Egads, I thought dodos were extinct!");
            }

            if (dodos < 0)
            {
                Console.WriteLine("Hold on, how can we have NEGATIVE dodos??!");
            }

            if (llamas > whales)
            {
                Console.WriteLine("Whales may be bigger, but llamas are better, ha!");
            }

            if (llamas <= whales)
            {
                Console.WriteLine("Aw man, brawn over brains I guess. Whales beat llamas.");
            }

            Console.WriteLine("There's been a huge increase in the dodo population via cloning!");
            dodos += 100;

            if ((whales + llamas) < dodos)
            {
                Console.WriteLine("I never thought I'd see the day when dodos ruled the earth.");
            }

            if (llamas > whales && llamas > dodos)
            {
                Console.WriteLine("I don't know how, but the llamas have come out ahead! Sneaky!");

            }

            Console.ReadKey();
        }
    }
}
