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
    internal class ExamController
    {
        public void AddExam(Exam exam)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query = @"
                        INSERT INTO Exams (Name, SubjectId, ExamDate, StartTime, EndTime) 
                        VALUES (@name, @subjectId, @examDate, @startTime, @endTime)";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", exam.Name);
                        cmd.Parameters.AddWithValue("@subjectId", exam.SubjectId);
                        cmd.Parameters.AddWithValue("@examDate", exam.ExamDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@startTime", exam.StartTime.ToString());
                        cmd.Parameters.AddWithValue("@endTime", exam.EndTime.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Exam added successfully.");
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        MessageBox.Show("Exam already exists or subject reference issue.");
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

        public void DeleteExam(int examId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Exams WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", examId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Exam GetExamById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT Id, Name, SubjectId, ExamDate, StartTime, EndTime 
                    FROM Exams 
                    WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Exam
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                SubjectId = reader.GetInt32(2),
                                ExamDate = DateTime.Parse(reader.GetString(3)),
                                StartTime = TimeSpan.Parse(reader.GetString(4)),
                                EndTime = TimeSpan.Parse(reader.GetString(5))
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<Exam> GetExamList()
        {
            var exams = new List<Exam>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT Id, Name, SubjectId, ExamDate, StartTime, EndTime FROM Exams";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            SubjectId = reader.GetInt32(2),
                            ExamDate = DateTime.Parse(reader.GetString(3)),
                            StartTime = TimeSpan.Parse(reader.GetString(4)),
                            EndTime = TimeSpan.Parse(reader.GetString(5))
                        });
                    }
                }
            }

            return exams;
        }
    }
}
