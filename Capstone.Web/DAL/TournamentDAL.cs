using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class TournamentDAL : ITournamentDAL
    {

        string databaseConnectionString;

        public TournamentDAL(string connectionString)
        {
            databaseConnectionString = connectionString;
        }


        public Tournament CreateTournament(string name, string url, string type, string format)
        {
            //try
            //{
            //    string sql = $"INSERT INTO tournament VALUES (@name, @url, @email);";
            //    using (SqlConnection conn = new SqlConnection(databaseConnectionString))
            //    {
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand(sql, conn);
            //        cmd.Parameters.AddWithValue("@name", newUser.name);
            //        cmd.Parameters.AddWithValue("@password", newUser.password);
            //        cmd.Parameters.AddWithValue("@email", newUser.email);


            //        int result = cmd.ExecuteNonQuery();

            //        return result > 0;
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    // logger.Error($"Error creating user w un/pw {newUser.Username}, {newUser.Password}", ex);
            //    throw;
            //}
            throw new NotImplementedException();
        }

        public Tournament GetTournament(string username)
        {
            throw new NotImplementedException();
        }

        public Tournament GetTournament(string username, string id)
        {
            throw new NotImplementedException();
        }
    }
}