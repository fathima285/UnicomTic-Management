using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS2.view
{
    public partial class StudentDashboard : Form
    {
        private readonly string _username;
        public StudentDashboard(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_username}";
            // Show only student-accessible features
            btnViewMarks.Visible = true;
            btnViewTimetable.Visible = true;

            // Hide all other restricted controls
            btnManageStudents.Visible = false;
            btnManageCourses.Visible = false;
            btnManageExams.Visible = false;
            btnManageMarks.Visible = false;
        }

        private void btnViewMarks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your marks will be shown here.");
            // You can connect it to student marks controller
        }
        

        private void btnViewTimetable_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your timetable will be shown here.");
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {

        }

        private void btnManageExams_Click(object sender, EventArgs e)
        {

        }

        private void btnManageCourses_Click(object sender, EventArgs e)
        {

        }

        private void btnManageMarks_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }
    }
}
