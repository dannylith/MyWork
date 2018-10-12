using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMadLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            string one, two, three, four, five, six, seven, eight, nine, ten;

            Console.WriteLine("Let's play MAD LIBS!\n");
            Console.Write("I need a noun: ");
            one = Console.ReadLine();
            Console.Write("Now an adj: ");
            two = Console.ReadLine();
            Console.Write("Another noun: ");
            three = Console.ReadLine();
            Console.Write("And a number: ");
            four = Console.ReadLine();
            Console.Write("Another adj: ");
            five = Console.ReadLine();
            Console.Write("A plural noun: ");
            six = Console.ReadLine();
            Console.Write("Another one: ");
            seven = Console.ReadLine();
            Console.Write("One more:");
            eight = Console.ReadLine();
            Console.Write("A verb (present tense): ");
            nine = Console.ReadLine();
            Console.Write("Same verb (past tense): ");
            ten = Console.ReadLine();

            Console.WriteLine($"{one}: the {two} frontier.These are the voyages of the starship {three}.Its {four}-year mission: to explore strange {five} {six}, to seek out {five} {seven} and {five} {eight}, to boldly {nine} where no one has {ten} before.");


            Console.ReadKey();
        }
    }
}
