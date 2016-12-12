using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class UserSQLDAL : IUserDAL
    {
        string databaseConnectionString; //@"Data Source=.\sqlexpress;Initial Catalog = TournamentWebsite; User ID = te_student; Password=techelevator";


        public UserSQLDAL(string connectionString)
        {
            databaseConnectionString = connectionString;
        }

        public int CreateUser(User newUser)
        {
            try
            {
                string sql = $"INSERT INTO users output INSERTED.user_id VALUES (@name, @password, @email, @salt);";
                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", newUser.name);
                    cmd.Parameters.AddWithValue("@password", newUser.password);
                    cmd.Parameters.AddWithValue("@email", newUser.email);
                    cmd.Parameters.AddWithValue("@salt", newUser.Salt);


                    int result = (int)cmd.ExecuteScalar();

                    return result;
                }
            }
            catch (SqlException ex)
            {
               // logger.Error($"Error creating user w un/pw {newUser.Username}, {newUser.Password}", ex);
                throw;
            }
        }

        public User GetUser(string email)
        {
            User user = null;

            try
            {
                string sql = $"SELECT TOP 1 * FROM users WHERE email = '{email}'";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        user = new User
                        {
                            user_id = Convert.ToInt32(reader["user_id"]),
                            name = Convert.ToString(reader["name"]),
                            password = Convert.ToString(reader["password"]),
                            email = Convert.ToString(reader["email"]),
                            Salt = Convert.ToString(reader["salt"])
                        };
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return user;
        }

        public User GetUser(string email, string password)
        {
            User user = null;

            try
            {
                string sql = $"SELECT TOP 1 * FROM users WHERE email = '{email}' AND password = '{password}'";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        user = new User
                        {
                            user_id = Convert.ToInt32(reader["user_id"]),
                            name = Convert.ToString(reader["name"]),
                            password = Convert.ToString(reader["password"]),
                            email = Convert.ToString(reader["email"]),
                            Salt = Convert.ToString(reader["salt"])
                        };
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return user;
        }
    }
}