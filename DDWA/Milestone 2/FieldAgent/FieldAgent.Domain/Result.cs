using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Domain
{
    public class Result<T> : Response
    {
        public T Payload { get; set; }
    }
}
