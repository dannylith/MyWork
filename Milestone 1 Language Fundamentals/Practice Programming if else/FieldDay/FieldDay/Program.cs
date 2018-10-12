using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string strLastName, strTeam;

            Console.Write("What is your last name? ");
            strLastName = Console.ReadLine();

            if(strLastName == "baggins")
            {
                strTeam = "Red Dragons";
            } else if(strLastName == "dresden")
            {
                strTeam = "Dark Wizards";
            }
            else if (strLastName == "howl")
            {
                strTeam = "Moving Castles";
            }
            else if (strLastName == "Potter")
            {
                strTeam = "Golden Snitches";
            }
            else if (strLastName == "vimes")
            {
                strTeam = "Night Guards";
            }
            else
            {
                strTeam = "Black Holes";
            }

            Console.WriteLine("You are on team " + strTeam);


            Console.ReadKey();
        }
    }
}
