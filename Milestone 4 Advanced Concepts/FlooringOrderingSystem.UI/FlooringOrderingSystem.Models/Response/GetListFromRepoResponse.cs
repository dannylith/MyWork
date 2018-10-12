using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Response
{
    public class GetListFromRepoResponse : Response
    {
        public List<Order> Orders { get; set; }
    }
}
