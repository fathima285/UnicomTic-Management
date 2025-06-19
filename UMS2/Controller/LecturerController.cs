using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS2.Data;
using UMS2.Model;

namespace UMS2.Controller
{
    internal class LecturerController
    {
        public void AddLecturer(Lecturer lecturer)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string lecturerquery = "INSERT INTO Lecturers(Name , NIC) VALUES (@name,@nic)";
                        using (var command = new SQLiteCommand(lecturerquery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@name", lecturer.Name);
                            command.Parameters.AddWithValue("@nic", lecturer.NIC);
                            command.ExecuteNonQuery();
                        }

                        // Get the last inserted lecturer ID
                        string lastLecturerIdQuery = "SELECT last_insert_rowid()";
                        int lastLecturerId;
                        using (var lastIdCommand = new SQLiteCommand(lastLecturerIdQuery, connection, transaction))
                        {
                            lastLecturerId = Convert.ToInt32(lastIdCommand.ExecuteScalar());
                        }

                        // Insert into Users table
                        string userquery = "INSERT INTO Users (Username, Password, Role,LinkedId) VALUES (@Username, @Password, @Role,@linkedid)";
                        using (var cmd = new SQLiteCommand(userquery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Username", lecturer.Username);
                            cmd.Parameters.AddWithValue("@Password", lecturer.Password);
                            cmd.Parameters.AddWithValue("@Role", "Lecturer");
                            cmd.Parameters.AddWithValue("@linkedid", lastLecturerId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Lecturer added successfully.");
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            if (ex.Message.Contains("NIC"))
                                MessageBox.Show("NIC already exists.");
                            else if (ex.Message.Contains("Username"))
                                MessageBox.Show("Username already exists.");
                            else
                                MessageBox.Show("Constraint error occurred.");
                        }
                        else
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
        }

        //Method To Delete Lecturer
        public void DeleteLecturer(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Delete the user linked to the lecturer
                        string deleteUserQuery = "DELETE FROM Users WHERE LinkedId = @Id AND Role = 'Lecturer'";
                        using (var userCommand = new SQLiteCommand(deleteUserQuery, connection, transaction))
                        {
                            userCommand.Parameters.AddWithValue("@Id", id);
                            userCommand.ExecuteNonQuery();
                        }

                        // Step 2: Delete the lecturer
                        string deleteLecturerQuery = "DELETE FROM Lecturers WHERE Id = @Id";
                        using (var lecturerCommand = new SQLiteCommand(deleteLecturerQuery, connection, transaction))
                        {
                            lecturerCommand.Parameters.AddWithValue("@Id", id);
                            lecturerCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Lecturer deleted successfully.");
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error deleting lecturer: " + ex.Message);
                    }
                }
            }
        }

        //Method To Update Lecturer
        public void UpdateLecturer(Lecturer lecturer)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateQuery = "UPDATE Users SET Username = @Username, Password = @Password WHERE LinkedId = @Id AND Role = 'Lecturer'";
                        using (var command = new SQLiteCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Username", lecturer.Username);
                            command.Parameters.AddWithValue("@Password", lecturer.Password);
                            command.Parameters.AddWithValue("@Id", lecturer.Id);
                            command.ExecuteNonQuery();
                        }

                        string update = "UPDATE Lecturers SET Name = @name , NIC = @nic WHERE Id = @id";
                        using (var command = new SQLiteCommand(update, connection))
                        {
                            command.Parameters.AddWithValue("@name", lecturer.Name);
                            command.Parameters.AddWithValue("@nic", lecturer.NIC);
                            command.Parameters.AddWithValue("@id", lecturer.Id);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();

                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            if (ex.Message.Contains("NIC"))
                                MessageBox.Show("NIC already exists.");
                            else if (ex.Message.Contains("Username"))
                                MessageBox.Show("Username already exists.");
                            else
                                MessageBox.Show("Constraint error occurred.");
                        }
                        else
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
        }

        public List<Lecturer> GetLecturerList()
        {
            var Lecturers = new List<Lecturer>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string lecturerquery = "SELECT * FROM Lecturers";

                using (var cmd = new SQLiteCommand(lecturerquery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var lecturer = new Lecturer()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                NIC = reader.GetString(2)
                            };
                            Lecturers.Add(lecturer);
                        }
                    }
                }
            }
            return Lecturers;
        }

        public Lecturer GetLecturerById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Lecturers WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            NIC = reader.GetString(2)
                        };
                    }
                }
            }
            return null;
        }

        public Lecturer FindUsernamePassword(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT Username, Password FROM Users WHERE LinkedId = @Id AND Role = @role", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@role", "Lecturer");

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}

    

