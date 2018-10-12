using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace FlooringOrderingSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = DIContainer.Kernel.Get<Controller>();
            controller.Run();
        }
    }
}
