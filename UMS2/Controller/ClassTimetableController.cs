using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS2.Model;
using UMS2.Data;

namespace UMS2.Controller
{
    internal class ClassTimetableController
    {
        public void AddTimetable(ClassTimetable timetable)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query = @"
                        INSERT INTO Timetable (SubjectId, Room, ClassDate, StartTime, EndTime)
                        VALUES (@subjectId, @room, @classDate, @startTime, @endTime)";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@subjectId", timetable.SubjectId);
                        cmd.Parameters.AddWithValue("@room", timetable.Room);
                        cmd.Parameters.AddWithValue("@classDate", timetable.ClassDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@startTime", timetable.StartTime.ToString());
                        cmd.Parameters.AddWithValue("@endTime", timetable.EndTime.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Timetable added successfully.");
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        MessageBox.Show("Conflict: This timeslot is already booked in the room.");
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

        public void DeleteTimetable(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Timetable WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClassTimetable GetTimetableById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT Id, SubjectId, Room, ClassDate, StartTime, EndTime
                    FROM Timetable
                    WHERE Id = @id";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClassTimetable
                            {
                                Id = reader.GetInt32(0),
                                SubjectId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                Room = reader.GetString(2),
                                ClassDate = DateTime.Parse(reader.GetString(3)),
                                StartTime = TimeSpan.Parse(reader.GetString(4)),
                                EndTime = TimeSpan.Parse(reader.GetString(5))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<ClassTimetable> GetAllTimetables()
        {
            var list = new List<ClassTimetable>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT Id, SubjectId, Room, ClassDate, StartTime, EndTime FROM Timetable";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ClassTimetable
                        {
                            Id = reader.GetInt32(0),
                            SubjectId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                            Room = reader.GetString(2),
                            ClassDate = DateTime.Parse(reader.GetString(3)),
                            StartTime = TimeSpan.Parse(reader.GetString(4)),
                            EndTime = TimeSpan.Parse(reader.GetString(5))
                        });
                    }
                }
            }

            return list;
        }
    }
}
