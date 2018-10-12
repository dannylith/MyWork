using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Domain.Repositories
{
    public interface IFieldAgentRepository
    {
        IEnumerable<Agent> All();
        void Add(Agent agent);
        Agent FindByIdentifier(string id);
        void Delete(Agent agent);
        void Edit(Agent agent, string oldIdentifier);
    }
}
