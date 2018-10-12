using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class PerfectChecker
    {
        public bool PerfectNumber(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }

            }

            if (sum == number)
            {
                return true;
            }
            return false;
        } 
    }
}
