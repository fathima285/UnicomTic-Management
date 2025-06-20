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
    internal class MarkController
    {

       
        
            public void AddMark(Mark mark)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    try
                    {
                        string query = "INSERT INTO Marks (StudentId, ExamId, Marks) VALUES (@studentId, @examId, @marks)";
                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@studentId", mark.StudentId);
                            cmd.Parameters.AddWithValue("@examId", mark.ExamId);
                            cmd.Parameters.AddWithValue("@marks", mark.Marks);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Mark added successfully.");
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            MessageBox.Show("Mark entry already exists or foreign key constraint failed.");
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

            public void DeleteMark(int studentId, int examId)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM Marks WHERE StudentId = @studentId AND ExamId = @examId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@examId", examId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public Mark GetMarkById(int studentId, int examId)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT StudentId, ExamId, Marks FROM Marks WHERE StudentId = @studentId AND ExamId = @examId";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@examId", examId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Mark
                                {
                                    StudentId = reader.GetInt32(0),
                                    ExamId = reader.GetInt32(1),
                                    Marks = reader.GetInt32(2)
                                };
                            }
                        }
                    }
                }
                return null;
            }

            public List<Mark> GetMarkList()
            {
                var marksList = new List<Mark>();

                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT StudentId, ExamId, Marks FROM Marks";

                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marksList.Add(new Mark
                            {
                                StudentId = reader.GetInt32(0),
                                ExamId = reader.GetInt32(1),
                                Marks = reader.GetInt32(2)
                            });
                        }
                    }
                }

                return marksList;
            }
        }
    }

