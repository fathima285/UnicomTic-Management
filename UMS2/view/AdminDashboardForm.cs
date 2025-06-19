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
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void LoadFormIntoPanel(Form form)
        {
            pnl_center.Controls.Clear();            // Clear old form
            form.TopLevel = false;                 // Child form-a set pannurathu
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;            // Full fill pannum
            pnl_center.Controls.Add(form);          // Add pannurathu
            form.Show();                           // Show pannurathu
        }

        private void pnl_select_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_center_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_up_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_course_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new CourseForm());
        }

        private void btn_lecturer_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new LecturerForm());
        }

        private void btn_subject_Click(object sender, EventArgs e)
        {

        }

        private void btn_student_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_class_Click(object sender, EventArgs e)
        {

        }

        private void btn_exam_Click(object sender, EventArgs e)
        {

        }

        private void btn_marks_Click(object sender, EventArgs e)
        {

        }
    }
}
