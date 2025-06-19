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
    internal class SubjectController
    {
        public void AddSubject(Subject subject)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO Subjects (Name, CourseId) VALUES (@name, @courseId)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", subject.Name);
                        cmd.Parameters.AddWithValue("@courseId", subject.CourseId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Subject added successfully.");
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        MessageBox.Show("Subject already exists or course reference issue.");
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message);
                }
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Subjects WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", subjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public Subject GetSubjectById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT s.Id, s.Name, s.CourseId, c.Name AS CourseName 
                    FROM Subjects s 
                    LEFT JOIN Courses c ON s.CourseId = c.Id 
                    WHERE s.Id = @Id";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subject
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CourseId = reader.GetInt32(2),
                                CourseName = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<Subject> GetSubjectList()
        {
            var subjects = new List<Subject>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT s.Id, s.Name, s.CourseId, c.Name AS CourseName 
                    FROM Subjects s 
                    LEFT JOIN Courses c ON s.CourseId = c.Id";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            CourseId = reader.GetInt32(2),
                            CourseName = reader.GetString(3)
                        });
                    }
                }
            }

            return subjects;
        }
    }
}
    

