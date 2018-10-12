using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class ConsoleOutput
    {
        public void OutputMessage(string x)
        {
            Console.Write(x);
        }
        public void StringJoinArray(int[] numbers)
        {
             Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
