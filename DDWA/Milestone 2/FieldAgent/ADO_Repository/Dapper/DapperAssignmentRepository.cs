using Dapper;
using FieldAgent.Domain;
using FieldAgent.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Repository.Dapper
{
    public class DapperAssignmentRepository : IAssignmentRepository
    {
        public void AddAssign(Assignment assignment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Assignment> All()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                return cn.Query<Assignment>("SELECT * FROM Assignment");
            }
        }

        public void DeleteAllAssign(string identifier)
        {
            throw new NotImplementedException();
        }

        public void DeleteAssign(Assignment assignment)
        {
            throw new NotImplementedException();
        }

        public void EditAssign(Assignment assignment)
        {
            throw new NotImplementedException();
        }

        public Assignment FindAssignmentByID(string identifier, int assignmentIdentifier)
        {
            throw new NotImplementedException();
        }

        public List<Assignment> FindAssignmentsById(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
