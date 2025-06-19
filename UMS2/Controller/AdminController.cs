using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS2.Data;
using UMS2.Model;

namespace UMS2.Controller
{
    internal class AdminController
    {
        public void CreateAdmin(Admin admin)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", admin.Username);
                    command.Parameters.AddWithValue("@Password", admin.Password);
                    command.Parameters.AddWithValue("@Role", "Admin");
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

