using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS2.Service
{
    internal class UserService
    {
        private static String connectionString = "Data Source=Ut.db;Version=3;";

        public bool RegisterUser(string username, string password, string role)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                var cmd = new SQLiteCommand("INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public (bool success, string role) ValidateLogin(string username, string password)
        {
            using (var con = new SQLiteConnection(connectionString))
            {

                con.Open();

                var cmd = new SQLiteCommand("SELECT Role FROM Users WHERE Username = @username AND Password = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return (true, reader["Role"].ToString());

                return (false, null);
            }
        }
    }
}

