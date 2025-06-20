using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
                        MessageBox.Show("Subject already exists or invalid course/lecturer reference.");
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

        public void UpdateSubject(Subject subject)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"UPDATE Subjects SET Name=@name, CourseId=@courseId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", subject.Name);
                    cmd.Parameters.AddWithValue("@courseId", subject.CourseId);
       
                    cmd.Parameters.AddWithValue("@id", subject.Id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        MessageBox.Show("Update failed: Subject not found.");
                    else
                        MessageBox.Show("Subject updated successfully.");
                }
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Subjects WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", subjectId);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        MessageBox.Show("Delete failed: Subject not found.");
                    else
                        MessageBox.Show("Subject deleted successfully.");
                }
            }
        }

        public List<Subject> GetSubjectList()
        {
            var list = new List<Subject>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT s.Id, s.Name, s.CourseId,
                           c.Name AS CourseName
                    FROM Subjects s
                    LEFT JOIN Courses c ON s.CourseId = c.Id
                    
                    ORDER BY s.Name ASC";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Subject
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            CourseId = reader.GetInt32(2),
                           
                            CourseName = reader["CourseName"]?.ToString(),
                           
                        });
                    }
                }
            }
            return list;
        }
    }
}
