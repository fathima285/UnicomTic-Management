using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UMS2.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UMS2.Data
{
    internal class TableManagement
    {
        public static void CreateTables()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=Ut.db;Version=3;"))
            {
                conn.Open();

                using (var pragmaCmd = conn.CreateCommand())
                {
                    pragmaCmd.CommandText = "PRAGMA foreign_keys = ON;";
                    pragmaCmd.ExecuteNonQuery();
                }


                string courseTable = @"
             CREATE TABLE IF NOT EXISTS Courses(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name VARCHAR(25) NOT NULL UNIQUE
                        );";
                using (SQLiteCommand cmd = new SQLiteCommand(courseTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string lecturerTable = @"
             CREATE TABLE IF NOT EXISTS Lecturers(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            NIC VARCHAR(12) NOT NULL UNIQUE
                        );";
                using (SQLiteCommand cmd = new SQLiteCommand(lecturerTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string subjectTable = @"
                CREATE TABLE IF NOT EXISTS Subjects(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name VARCHAR(25) NOT NULL UNIQUE,
                            CourseId INTEGER NOT NULL,
                            FOREIGN KEY(CourseId) REFERENCES Courses(Id)
                         );";
                using (SQLiteCommand cmd = new SQLiteCommand(subjectTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string studentTable = @"
                CREATE TABLE IF NOT EXISTS Students(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    NIC VARCHAR(12) NOT NULL UNIQUE,
                            CourseId INTEGER NOT NULL,
                            UNIQUE (Name, NIC),
                            FOREIGN KEY(CourseId) REFERENCES Courses(Id)
                        );";
                using (SQLiteCommand cmd = new SQLiteCommand(studentTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }


                string lecturerstudentTable = @"
                CREATE TABLE IF NOT EXISTS LecturerSubject(
                    LecturerId INTEGER NOT NULL,
                    SubjectId INTEGER NOT NULL,
                    PRIMARY KEY (LecturerId, SubjectId),
                    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
                    FOREIGN KEY (LecturerId) REFERENCES Lecturers(Id)

                );";
                using (SQLiteCommand cmd = new SQLiteCommand(lecturerstudentTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string userTable = @"
                CREATE TABLE IF NOT EXISTS Users(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    LinkedId INTEGER,
                    Role TEXT NOT NULL,
                    UNIQUE(LinkedId, Role)

                );";
                using (SQLiteCommand cmd = new SQLiteCommand(userTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string examTable = @"
                CREATE TABLE IF NOT EXISTS Exams(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    SubjectId INTEGER,
                    ExamDate DATE NOT NULL,
                    StartTime TIME NOT NULL,
                    EndTime TIME NOT NULL,
                    UNIQUE (Name, SubjectId),
                    UNIQUE (SubjectId, ExamDate, StartTime, EndTime),
                    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)

                );";
                using (SQLiteCommand cmd = new SQLiteCommand(examTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string timetableTable = @"
                CREATE TABLE IF NOT EXISTS Timetable(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectId INTEGER,
                    Room TEXT,
                    ClassDate DATE NOT NULL,
                    StartTime TIME NOT NULL,
                    EndTime TIME NOT NULL,
                    UNIQUE (Room, ClassDate, StartTime, EndTime),
                    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)

                );";
                using (SQLiteCommand cmd = new SQLiteCommand(timetableTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string markTable = @"
                CREATE TABLE IF NOT EXISTS Marks(
                    StudentId INTEGER,
                    ExamId INTEGER,
                    Marks INTEGER CHECK (Marks >= 0 AND Marks <= 100),
                            PRIMARY KEY(StudentId, ExamId),
                            FOREIGN KEY(ExamId) REFERENCES Exams(Id),
                            FOREIGN KEY(StudentId) REFERENCES Students(Id)
                        );";
                using (SQLiteCommand cmd = new SQLiteCommand(markTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }



                string attendanceTable = @"
                CREATE TABLE IF NOT EXISTS Attendence(
                    StudentId INTEGER NOT NULL,
                    Date DATE NOT NULL,
                    Status TEXT NOT NULL,
                    UNIQUE (StudentId, Date),
                    FOREIGN KEY (StudentId) REFERENCES Students(Id)

                );";
                using (SQLiteCommand cmd = new SQLiteCommand(attendanceTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                




                conn.Close();
                    


            }
        }
    }
}

            

        
    

