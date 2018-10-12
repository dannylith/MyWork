using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using FlooringOrderingSystem.Data;

namespace FlooringOrderingSystem.UI
{
    public static class DIContainer
    {
        public static IKernel Kernel = new StandardKernel();

        static DIContainer()
        {
            
            string chooserType = ConfigurationManager.AppSettings["Mode"];

            Kernel.Bind<ITaxFileRepository>().To<TaxFileRepository>();
            Kernel.Bind<IProductsFileRepository>().To<ProductsFileRepository>();

            if (chooserType == "Prod")
                Kernel.Bind<IOrdersFileRepository>().To<OrdersFileRepository>();
            else if (chooserType == "Test")
                Kernel.Bind<IOrdersFileRepository>().To<TestOrdersFileRepository>();
            else
                throw new Exception("Chooser key in app.config not set properly!");
        }
    }
}
