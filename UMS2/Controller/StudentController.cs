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
    internal class StudentController
    {
        public void AddStudent(Student student)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string Query = "INSERT INTO Students (Name, NIC, CourseId) VALUES (@name, @nic, @courseId)";
                        using (var cmd = new SQLiteCommand(Query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", student.Name);
                            cmd.Parameters.AddWithValue("@nic", student.NIC);
                            cmd.Parameters.AddWithValue("@courseId", student.CourseId);
                            cmd.ExecuteNonQuery();
                        }

                        string GetIastIdQuery = "SELECT last_insert_rowid()";
                        int lastId;
                        using (var cmd = new SQLiteCommand(GetIastIdQuery, conn))
                        {
                            lastId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string userquery = "INSERT INTO Users (Username, Password, LinkedId,Role) VALUES (@username, @pass, @linkedid,@role)";
                        using (var cmd = new SQLiteCommand(userquery, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", student.Username);
                            cmd.Parameters.AddWithValue("@pass", student.Password);
                            cmd.Parameters.AddWithValue("@linkedid", lastId);
                            cmd.Parameters.AddWithValue("@role", "Student");
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Student Added Successfully");
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
        public List<Student> GetAll()
        {
            var Students = new List<Student>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string stuquery = @"SELECT 
                                    st.Id,              
                                    st.Name,
                                    st.NIC,
                                    st.CourseId,
                                    co.Name AS CourseName
                                    FROM Students st
                                    LEFT JOIN Courses co ON st.CourseId = co.Id
                                ";

                using (var cmd = new SQLiteCommand(stuquery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new Student()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                NIC = reader.GetString(2),
                                CourseId = reader.GetInt32(3),
                                CourseName = reader.GetString(4),
                            };
                            Students.Add(student);
                        }
                    }
                }
            }
            return Students;
        }

        public Student GetStudentById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Students WHERE Id =@id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            NIC = reader.GetString(2),
                            CourseId = reader.GetInt32(3),
                        };
                    }
                }
            }
            return null;
        }
        public Student FindUsernamePassword(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT Username, Password FROM Users WHERE LinkedId = @Id AND Role = @role", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@role", "Student");

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student
                        {
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void DeleteStudent(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string userdel = "DELETE FROM Users WHERE LinkedId = @Id AND Role = 'Student'";
                        using (var deluser = new SQLiteCommand(userdel, conn))
                        {
                            deluser.Parameters.AddWithValue("@Id", id);
                            deluser.ExecuteNonQuery();
                        }
                        string studel = "DELETE FROM Students WHERE Id = @id";
                        using (var delstudel = new SQLiteCommand(studel, conn))
                        {
                            delstudel.Parameters.AddWithValue("@id", id);
                            delstudel.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Student Deleted Successfully");
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error deleting lecturer: " + ex.Message);
                    }
                }
            }
        }
        public void UpdateStudent(int id, Student student)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update student table
                        string updateStudentQuery = "UPDATE Students SET Name = @Name, NIC = @NIC, CourseId = @CourseId WHERE Id = @Id";
                        using (var cmd = new SQLiteCommand(updateStudentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", student.Name);
                            cmd.Parameters.AddWithValue("@NIC", student.NIC);
                            cmd.Parameters.AddWithValue("@CourseId", student.CourseId);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // Update user table
                        string updateUserQuery = "UPDATE Users SET Username = @Username, Password = @Password WHERE LinkedId = @Id AND Role = 'Student'";
                        using (var cmd = new SQLiteCommand(updateUserQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Username", student.Username);
                            cmd.Parameters.AddWithValue("@Password", student.Password);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Student updated successfully.");
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating student: " + ex.Message);
                    }
                }
            }
        }
    }
}

    

