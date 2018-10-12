using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball.Models
{
    public class GetPickListResponse : Response
    {
        public List<Pick> picks { get; set; }
    }
}
