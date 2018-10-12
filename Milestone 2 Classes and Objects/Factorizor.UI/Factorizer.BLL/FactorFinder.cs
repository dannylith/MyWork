using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class FactorFinder
    {
        public int[] FactorArray(int number)
        {
            int[] arrIntFactor, arrIntTempFactor = new int[number];
            int counter = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    arrIntTempFactor[counter] = i;
                    counter++;
                }
            }
            arrIntFactor = new int[counter];
            for(int i =0; i< arrIntFactor.Length; i++)
            {
                arrIntFactor[i] = arrIntTempFactor[i];
            }
            return arrIntFactor;
        }
    }
}
