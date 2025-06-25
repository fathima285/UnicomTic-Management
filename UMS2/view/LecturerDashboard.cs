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
    public partial class LecturerDashboard : Form
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }

        private void btnViewMarks_Click(object sender, EventArgs e)
        {

        }

        private void btnViewTimetable_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Timetable view loads.");
            // Connect to timetable
        }

        private void LecturerDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, Lecturer";
            btnViewTimetable.Visible = true;
            btnManageMarks.Visible = true;

            // Hide all non-lecturer features
            btnManageStudents.Visible = false;
            btnManageCourses.Visible = false;
            btnManageExams.Visible = false;
            btnViewMarks.Visible = false;
        }

        private void btnManageMarks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mark management form opens.");
            // Connect to mark form
        }
    }
}
