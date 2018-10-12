using FieldAgent.Domain;
using FieldAgent.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Repository.ADO
{
    public class ADOAssignmentRepository : IAssignmentRepository
    {
        public void AddAssign(Assignment assignment)
        {

            var exist = FindAssignmentsById(assignment.Identifier);
            if (exist == null)
            {
                assignment.AssignmentIdentifier = 1;
            }
            else
            {
                assignment.AssignmentIdentifier = exist.Count() + 1;
            }

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                        ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Assignment(AssignmentIdentifier, Identifier, CountryCode, StartDate, ProjectedEndDate, ActualEndDate, Notes) " +
                    "VALUES (@AssignmentIdentifier, @Identifier, @CountryCode, @StartDate, @ProjectedEndDate, @ActualEndDate, @Notes)";

                cmd.Parameters.AddWithValue("@AssignmentIdentifier", assignment.AssignmentIdentifier);
                cmd.Parameters.AddWithValue("@Identifier", assignment.Identifier);
                cmd.Parameters.AddWithValue("@CountryCode", assignment.CountryCode);
                cmd.Parameters.AddWithValue("@StartDate", assignment.StartDate);
                cmd.Parameters.AddWithValue("@ProjectedEndDate", assignment.ProjectedEndDate);
                cmd.Parameters.AddWithValue("@ActualEndDate", assignment.ActualEndDate);
                if (assignment.Notes != null)
                {
                    cmd.Parameters.AddWithValue("@Notes", assignment.Notes);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                }
                
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Assignment> All()
        {
            List<Assignment> assignments = new List<Assignment>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Assignment";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Assignment currentRow = new Assignment();
                        currentRow.AssignmentIdentifier = (int)dr["AssignmentIdentifier"];
                        currentRow.Identifier = dr["Identifier"].ToString();
                        currentRow.CountryCode = dr["CountryCode"].ToString();
                        currentRow.StartDate = (DateTime)dr["StartDate"];
                        currentRow.ProjectedEndDate = (DateTime)dr["ProjectedEndDate"];
                        currentRow.ActualEndDate = (DateTime)dr["ActualEndDate"];
                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        assignments.Add(currentRow);
                    }
                }
            }
            return assignments;
        }

        public void DeleteAllAssign(string identifier)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Assignment " +
                    "WHERE Identifier = @Identifier ";

                cmd.Parameters.AddWithValue("@Identifier", identifier);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAssign(Assignment assignment)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Assignment " +
                    "WHERE Identifier = @Identifier AND AssignmentIdentifier = @AssignmentIdentifier ";

                cmd.Parameters.AddWithValue("@Identifier", assignment.Identifier);
                cmd.Parameters.AddWithValue("@AssignmentIdentifier", assignment.AssignmentIdentifier);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditAssign(Assignment assignment)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Assignment " +
                    "SET Identifier = @Identifier, " +
                    "AssignmentIdentifier = @AssignmentIdentifier, " +
                    "CountryCode = @CountryCode, " +
                    "StartDate = @StartDate, " +
                    "ProjectedEndDate = @ProjectedEndDate, " +
                    "ActualEndDate = @ActualEndDate " +
                    "WHERE Identifier = @Identifier AND AssignmentIdentifier = @AssignmentIdentifier";

                cmd.Parameters.AddWithValue("@Identifier", assignment.Identifier);
                cmd.Parameters.AddWithValue("@AssignmentIdentifier", assignment.AssignmentIdentifier);
                cmd.Parameters.AddWithValue("@CountryCode", assignment.CountryCode);
                cmd.Parameters.AddWithValue("@StartDate", assignment.StartDate);
                cmd.Parameters.AddWithValue("@ProjectedEndDate", assignment.ProjectedEndDate);
                cmd.Parameters.AddWithValue("@ActualEndDate", assignment.ActualEndDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Assignment FindAssignmentByID(string identifier, int assignmentIdentifier)
        {
            Assignment assignment =  null;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Assignment WHERE Identifier = @Identifier AND AssignmentIdentifier = @AssignmentIdentifier";

                cmd.Parameters.AddWithValue("@Identifier", identifier);
                cmd.Parameters.AddWithValue("@AssignmentIdentifier", assignmentIdentifier);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Assignment currentRow = new Assignment();
                        currentRow.AssignmentIdentifier = (int)dr["AssignmentIdentifier"];
                        currentRow.Identifier = dr["Identifier"].ToString();
                        currentRow.CountryCode = dr["CountryCode"].ToString();
                        currentRow.StartDate = (DateTime)dr["StartDate"];
                        currentRow.ProjectedEndDate = (DateTime)dr["ProjectedEndDate"];
                        currentRow.ActualEndDate = (DateTime)dr["ActualEndDate"];
                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        assignment = currentRow;
                    }
                }
            }
            return assignment;
        }

        public List<Assignment> FindAssignmentsById(string identifier)
        {
            List<Assignment> listOfAssignments = new List<Assignment>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Assignment WHERE Identifier = @Identifier";

                cmd.Parameters.AddWithValue("@Identifier", identifier);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Assignment currentRow = new Assignment();
                        currentRow.AssignmentIdentifier = (int)dr["AssignmentIdentifier"];
                        currentRow.Identifier = dr["Identifier"].ToString();
                        currentRow.CountryCode = dr["CountryCode"].ToString();
                        currentRow.StartDate = (DateTime)dr["StartDate"];
                        currentRow.ProjectedEndDate = (DateTime)dr["ProjectedEndDate"];
                        currentRow.ActualEndDate = (DateTime)dr["ActualEndDate"];
                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        listOfAssignments.Add(currentRow);
                    }
                }
            }

            if (listOfAssignments.Any())
            {
                return listOfAssignments;
            }
            return null;

        }
    }
}
