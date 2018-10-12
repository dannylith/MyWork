using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Response
{
    public class OrderResponse : Response
    {
        public Order order { get; set; }
    }
}
