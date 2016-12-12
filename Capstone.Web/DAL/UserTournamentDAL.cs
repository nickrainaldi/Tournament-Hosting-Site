using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class UserTournamentDAL : IUserTournamentDAL
    {
        string databaseConnectionString; //@"Data Source=.\sqlexpress;Initial Catalog = TournamentWebsite; User ID = te_student; Password=techelevator";

        public UserTournamentDAL(string connectionString)
        {
            databaseConnectionString = connectionString;
        }

        bool CreateUserTournament(UserTournament newUserTournament)
        {
            return false;
        }
        public bool CreateUserTournament(int user_id, int tournament_id, int owner)
        {
            try
            {
                string sql = $"INSERT INTO [dbo].[userstournaments] VALUES (@user_id, @tournament_id,@owner)";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@tournament_id", tournament_id);
                    cmd.Parameters.AddWithValue("@owner", owner);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }

            }
            catch (SqlException ex)
            {
                // logger.Error($"Error creating user w un/pw {newUser.Username}, {newUser.Password}", ex);
                throw;
            }
        }

        public UserTournament GetUserTournament(int user_id, int tournament_id)
        {

            UserTournament userTournament = null;

            try
            {

                string sql = $"SELECT TOP 1 [user_id] ,[tournament_id] FROM[dbo].[userstournaments] WHERE user_id = '{user_id}' AND tournament_id = '{tournament_id}'";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userTournament = new UserTournament
                        {
                            user_id = Convert.ToInt32(reader["user_id"]),
                            tournament_id = Convert.ToInt32(reader["tournament_id"])
                        };
                    }

                }
            }
            catch (SqlException ex)
            {

                throw;
            }

            return userTournament;
        }

        bool IUserTournamentDAL.CreateUserTournament(UserTournament newUserTournament)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, bool> GetUserTournaments(int user_id)
        {
            UserTournament userTournament = null;
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            try
            {

                string sql = $"SELECT [tournament_id], [owner] FROM [dbo].[userstournaments] WHERE user_id = '{user_id}'";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userTournament = new UserTournament
                        {
                            tournament_id = Convert.ToInt32(reader["tournament_id"]),
                            owner = Convert.ToBoolean(reader["owner"]),

                        };
                        dict.Add(userTournament.tournament_id, userTournament.owner);
                    }

                }
            }
            catch (SqlException ex)
            {

                throw;
            }

            return dict;
        }

        public List<int> GetUserTournaments(int user_id, int isOwner)
        {
            List<int> result = new List<int>();
            try
            {

                string sql = $"SELECT [tournament_id] FROM [dbo].[userstournaments] WHERE user_id = '{user_id}' AND owner = {isOwner}";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var tournament_id = Convert.ToInt32(reader["tournament_id"]);
                        result.Add(tournament_id);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        List<int> IUserTournamentDAL.GetUserTournaments(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}