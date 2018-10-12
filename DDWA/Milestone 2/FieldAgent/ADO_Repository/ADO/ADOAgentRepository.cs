using FieldAgent.Domain;
using FieldAgent.Domain.Repositories;
using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Repository.ADO
{
    public class ADOAgentRepository : IFieldAgentRepository
    {
        public void Add(Agent agent)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                        ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Agent(Identifier, FirstName, MiddleName, LastName, PictureUrl, BirthDate, Height, Agency, ActivationDate, SecurityClearance, IsActive, Aliases) " +
                    "VALUES (@Identifier, @FirstName, @MiddleName, @LastName, @PictureUrl, @BirthDate, @Height, @Agency, @ActivationDate, @SecurityClearance, @IsActive, null)";

                cmd.Parameters.AddWithValue("@Identifier", agent.Identifier);
                cmd.Parameters.AddWithValue("@FirstName", agent.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", "");
                cmd.Parameters.AddWithValue("@LastName", agent.LastName);
                cmd.Parameters.AddWithValue("@PictureUrl", "");
                cmd.Parameters.AddWithValue("@BirthDate", agent.BirthDate);
                cmd.Parameters.AddWithValue("@Height", agent.Height);
                cmd.Parameters.AddWithValue("@Agency", agent.Agency);
                cmd.Parameters.AddWithValue("@ActivationDate", agent.ActivationDate);
                cmd.Parameters.AddWithValue("@SecurityClearance", agent.SecurityClearance);
                cmd.Parameters.AddWithValue("@IsActive", agent.IsActive);
                //cmd.Parameters.AddWithValue("@Aliases", null);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Agent agent)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Agent " +
                    "WHERE Identifier = @Identifier";

                cmd.Parameters.AddWithValue("@Identifier", agent.Identifier);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(Agent agent, string oldIdentifier)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Agent " +
                    "SET Identifier = @Identifier, " +
                    "FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "BirthDate = @BirthDate, " +
                    "Height = @Height, " +
                    "Agency = @Agency, " +
                    "ActivationDate = @ActivationDate, " +
                    "SecurityClearance = @SecurityClearance " +
                    "WHERE Identifier = @oldIdentifier";

                cmd.Parameters.AddWithValue("@oldIdentifier", oldIdentifier);
                cmd.Parameters.AddWithValue("@Identifier", agent.Identifier);
                cmd.Parameters.AddWithValue("@FirstName", agent.FirstName);
                cmd.Parameters.AddWithValue("@LastName", agent.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", agent.BirthDate);
                cmd.Parameters.AddWithValue("@Height", agent.Height);
                cmd.Parameters.AddWithValue("@Agency", agent.Agency);
                cmd.Parameters.AddWithValue("@ActivationDate", agent.ActivationDate);
                cmd.Parameters.AddWithValue("@SecurityClearance", agent.SecurityClearance);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Agent FindByIdentifier(string id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FindAgentById";

                cmd.Parameters.AddWithValue("@Identifier", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Agent currentRow = new Agent();


                        currentRow.FirstName = dr["FirstName"].ToString();
                        if (dr["MiddleName"] != DBNull.Value)
                        {
                            currentRow.MiddleName = dr["MiddleName"].ToString();
                        }
                        currentRow.LastName = dr["LastName"].ToString();
                        if (dr["PictureUrl"] != DBNull.Value)
                        {
                            currentRow.PicturUrl = dr["PictureUrl"].ToString();
                        }
                        currentRow.BirthDate = (DateTime)dr["BirthDate"];
                        currentRow.Height = (int)dr["Height"];
                        currentRow.Agency = dr["Agency"].ToString();
                        currentRow.ActivationDate = DateTime.Parse(dr["ActivationDate"].ToString());
                        currentRow.SecurityClearance = dr["SecurityClearance"].ToString();
                        currentRow.IsActive = (bool)dr["IsActive"];
                        if (dr["Aliases"] != DBNull.Value)
                        {
                            currentRow.Aliases = new List<Alias> { new Alias { Id = 1, Name = dr["Aliases"].ToString() } };
                        }


                        currentRow.Identifier = dr["Identifier"].ToString();
                        return currentRow;
                    }
                }
                return null;
            }

            
        }

        public IEnumerable<Agent> All()
        {
            List<Agent> agents = new List<Agent>();


            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldAgent"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Agent";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Agent currentRow = new Agent();

                        currentRow.FirstName = dr["FirstName"].ToString();
                        if (dr["MiddleName"] != DBNull.Value)
                        {
                            currentRow.MiddleName = dr["MiddleName"].ToString();
                        }
                        currentRow.LastName = dr["LastName"].ToString();
                        if (dr["PictureUrl"] != DBNull.Value)
                        {
                            currentRow.PicturUrl = dr["PictureUrl"].ToString();
                        }
                        currentRow.BirthDate = (DateTime)dr["BirthDate"];
                        currentRow.Height = (int)dr["Height"];
                        currentRow.Agency = dr["Agency"].ToString();
                        currentRow.ActivationDate = DateTime.Parse(dr["ActivationDate"].ToString());
                        currentRow.SecurityClearance = dr["SecurityClearance"].ToString();
                        currentRow.IsActive = (bool)dr["IsActive"];
                        if (dr["Aliases"] != DBNull.Value)
                        {
                            currentRow.Aliases = new List<Alias> { new Alias { Id = 1, Name = dr["Aliases"].ToString() } };
                        }


                        currentRow.Identifier = dr["Identifier"].ToString();
                        agents.Add(currentRow);
                    }
                }
            }
            return agents;
        }
    }
}
