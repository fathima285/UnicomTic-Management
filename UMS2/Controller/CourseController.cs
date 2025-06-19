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
    internal class CourseController
    {
        public void AddCourse(Course course)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query= "INSERT INTO Courses (Name) VALUES (@name)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", course.Name);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Course added successfully.");
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        MessageBox.Show("Course already exists.");
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

        // This method Delete an existing course in the database.
        public void DeleteCourse(int CourseId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Courses WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", CourseId);
                command.ExecuteNonQuery();
            }
        }


        public Course GetCourseById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Courses WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Course
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }

        // This method retrieves a list of all courses from the database.
        public List<Course> GetCourseList()
        {
            var courses = new List<Course>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                string coursequery = "SELECT * FROM Courses";

                using (var cmd = new SQLiteCommand(coursequery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            };
                            courses.Add(course);
                        }
                    }
                }

            }
            return courses;
        }
        //public List<Student> GetAllStudents()
        //{
        //    var students = new List<Student>();

        //    using (var conn = DbCon.GetConnection())
        //    {
        //        var cmd = new SQLiteCommand(@"
        //            SELECT s.Id, s.Name, s.Address, s.SectionId, sec.Name AS SectionName
        //            FROM Students s
        //            LEFT JOIN Sections sec ON s.SectionId = sec.Id", conn);

        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Student student = new Student
        //            {
        //                Id = reader.GetInt32(0),
        //                Name = reader.GetString(1),
        //                Address = reader.GetString(2),
        //                SectionId = reader.GetInt32(3),
        //                SectionName = reader.GetString(4),
        //            };
        //            students.Add(student);
        //        }
        //    }

        //    return students;
        //}
    }
}

    

