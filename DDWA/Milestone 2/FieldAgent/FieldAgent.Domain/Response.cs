using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Domain
{
    public class Response
    {
        public bool Success { get; set; }
        public List<string> Messages { get; private set; }

        public Response()
        {
            Messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
