using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Domain.Repositories
{
    public interface IAssignmentRepository
    {
        IEnumerable<Assignment> All();
        void AddAssign(Assignment assignment);
        void DeleteAllAssign(string identifier);
        List<Assignment> FindAssignmentsById(string identifier);
        Assignment FindAssignmentByID(string identifier, int assignmentIdentifier);
        void DeleteAssign(Assignment assignment);
        void EditAssign(Assignment assignment);
    }
}
