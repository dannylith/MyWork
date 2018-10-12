using FieldAgent.Domain.Repositories;
using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO_Repository.Dapper
{
    public class DapperAgentRepository : IFieldAgentRepository
    {
        public void Add(Agent agent)
        {

            const string sql = "INSERT INTO Agent(Identifier, FirstName, MiddleName, LastName, PictureUrl, BirthDate, Height, Agency, ActivationDate, SecurityClearance, IsActive, Aliases) " +
                    "VALUES (@Identifier, @FirstName, @MiddleName, @LastName, null, @BirthDate, @Height, @Agency, @ActivationDate, @SecurityClearance, @IsActive, null)";

            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;
                cn.Execute(sql, agent);
            }
        }

        public IEnumerable<Agent> All()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                return cn.Query<Agent>("SELECT * FROM Agent");
            }
        }

        public void Delete(Agent agent)
        {
            const string sql = "DELETE FROM Agent WHERE Identifier = @Identifier";
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;
                cn.Execute(sql, new { Identifier = agent.Identifier });
            }
        }

        public void Edit(Agent agent, string oldIdentifier)
        {
            const string sql = "UPDATE Agent " +
                    "SET Identifier = @Identifier, " +
                    "FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "BirthDate = @BirthDate, " +
                    "Height = @Height, " +
                    "Agency = @Agency, " +
                    "ActivationDate = @ActivationDate, " +
                    "SecurityClearance = @SecurityClearance " +
                    "WHERE Identifier = @Identifier";

            using (var cn = new SqlConnection())
            {

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;
                cn.Execute(sql, agent);
            }
        }

        public Agent FindByIdentifier(string id)
        {
            const string sql = "SELECT * "
                + "FROM Agent "
                + "WHERE Identifier = @Identifier";

            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                return cn.Query<Agent>(sql, new { Identifier = id })
                    .FirstOrDefault();
            }
        }
    }
}
