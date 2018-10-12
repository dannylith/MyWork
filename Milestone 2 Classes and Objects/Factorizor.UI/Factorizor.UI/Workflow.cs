using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizer.BLL;

namespace Factorizor.UI
{
    class Workflow
    {
        public void StartProgram()
        {
            int[] arrFactor;

            ConsoleOutput consoleOutput = new ConsoleOutput();
            ConsoleInput consoleInput = new ConsoleInput();
            FactorFinder factorFinder = new FactorFinder();
            PerfectChecker perfectChecker = new PerfectChecker();
            PrimeChecker primeChecker = new PrimeChecker();
            
            consoleOutput.OutputMessage("Which number Do you want to factor: ");
            consoleInput.UserInput = int.Parse(Console.ReadLine());
            arrFactor = factorFinder.FactorArray(consoleInput.UserInput);
            consoleOutput.OutputMessage("The Factors are: \n");
            consoleOutput.StringJoinArray(arrFactor);
            if(perfectChecker.PerfectNumber(consoleInput.UserInput))
            {
                consoleOutput.OutputMessage($"{consoleInput.UserInput} is a Perfect Number. \n");
            }
            else
            {
                consoleOutput.OutputMessage($"{consoleInput.UserInput} is NOT a Perfect Number. \n");
            }

            if (primeChecker.PrimeNumber(consoleInput.UserInput))
            {
                consoleOutput.OutputMessage($"{consoleInput.UserInput} is a Prime Number. \n");
            }
            else
            {
                consoleOutput.OutputMessage($"{consoleInput.UserInput} is NOT a Prime Number.\n");
            }

            Console.ReadKey();

        }
    }
}
