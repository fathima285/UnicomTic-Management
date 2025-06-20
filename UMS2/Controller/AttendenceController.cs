
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS2.Data;
using UMS2.Model;

namespace project.Controller
{
    internal class AttendenceController
    {
        // Add new attendance record
        public void AddAttendence(Attendence attendence)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO Attendence (StudentId, Date, Status) 
                                         VALUES (@StudentId, @Date, @Status)";
                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentId", attendence.StudentId);
                            cmd.Parameters.AddWithValue("@Date", attendence.Date.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Status", attendence.Status);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Attendance recorded successfully.");
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        if (ex.ResultCode == SQLiteErrorCode.Constraint && ex.Message.Contains("UNIQUE"))
                        {
                            MessageBox.Show("Attendance for this student on this date already exists.");
                        }
                        else
                        {
                            MessageBox.Show("Error adding attendance: " + ex.Message);
                        }
                    }
                }
            }
        }

        // Get all attendance records with student name
        public List<Attendence> GetAll()
        {
            var list = new List<Attendence>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT a.StudentId, s.Name AS StudentName, a.Date, a.Status 
                                 FROM Attendence a 
                                 JOIN Students s ON a.StudentId = s.Id";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var att = new Attendence()
                        {
                            StudentId = reader["StudentId"].ToString(),
                            StudentName = reader["StudentName"].ToString(),
                            Date = DateTime.Parse(reader["Date"].ToString()),
                            Status = reader["Status"].ToString()
                        };
                        list.Add(att);
                    }
                }
            }
            return list;
        }

        // Delete attendance for student on specific date
        public void DeleteAttendence(string studentId, DateTime date)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "DELETE FROM Attendence WHERE StudentId = @StudentId AND Date = @Date";
                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentId", studentId);
                            cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                MessageBox.Show("Attendance deleted successfully.");
                            else
                                MessageBox.Show("No record found for deletion.");
                        }

                        transaction.Commit();
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error deleting attendance: " + ex.Message);
                    }
                }
            }
        }

        // Optional: Get attendance for a specific student
        public List<Attendence> GetByStudentId(string studentId)
        {
            var list = new List<Attendence>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT a.StudentId, s.Name AS StudentName, a.Date, a.Status 
                                 FROM Attendence a 
                                 JOIN Students s ON a.StudentId = s.Id
                                 WHERE a.StudentId = @StudentId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var att = new Attendence()
                            {
                                StudentId = reader["StudentId"].ToString(),
                                StudentName = reader["StudentName"].ToString(),
                                Date = DateTime.Parse(reader["Date"].ToString()),
                                Status = reader["Status"].ToString()
                            };
                            list.Add(att);
                        }
                    }
                }
            }
            return list;
        }
    }
}
