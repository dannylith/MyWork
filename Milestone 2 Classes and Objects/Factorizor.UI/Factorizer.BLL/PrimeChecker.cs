using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class PrimeChecker
    {
        public bool PrimeNumber(int number)
        {
            int counter = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    counter++;
                }
            }
            if (counter == 2)
            {
                return true;
            }
            return false;
        }
    }
}
