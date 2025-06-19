using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS2.Controller;
using UMS2.Model;

namespace UMS2.view
{
    public partial class StudentForm : Form
    {
        int selectedStudentId = -1;
        public StudentForm()
        {
            InitializeComponent();
        }
        private void StudentForm_Load(object sender, EventArgs e)
        {
            Loadcourse();
            LoadStudent();
        }

        public void Loadcourse()
        {
            CourseController courseController = new CourseController();
            cobcourse.DataSource = courseController.GetCourseList();
            cobcourse.DisplayMember = "Name";
            cobcourse.ValueMember = "Id";
            cobcourse.SelectedIndex = -1;
        }

        public void LoadStudent()
        {
            StudentController studentController = new StudentController();
            dgvstudent.DataSource = studentController.GetAll();
            dgvstudent.Columns["Id"].Visible = false;
            dgvstudent.Columns["Password"].Visible = false; // Hide password column for security
            dgvstudent.Columns["Username"].Visible = false; // Hide CourseId column if not needed
            dgvstudent.Columns["CourseId"].Visible = false;

            this.BeginInvoke(new Action(() =>
            {
                dgvstudent.ClearSelection();
                dgvstudent.CurrentCell = null;
                selectedStudentId = -1;
                ClearFields();
            }));
        }
        private void ClearFields()
        {
            txtname.Clear();
            txtnic.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            cobcourse.SelectedIndex = -1;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a Student to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show("Are you sure you want to delete this Student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    StudentController studentController = new StudentController();
                    studentController.DeleteStudent(selectedStudentId);
                    LoadStudent();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting Student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtname.Text) ||
                string.IsNullOrEmpty(txtnic.Text) ||
                string.IsNullOrEmpty(txtusername.Text) ||
                string.IsNullOrEmpty(txtpassword.Text) ||
                cobcourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK);
                return;
            }
            Student student = new Student
            {
                Name = txtname.Text,
                NIC = txtnic.Text,
                Username = txtusername.Text,
                Password = txtpassword.Text,
                CourseId = Convert.ToInt32(cobcourse.SelectedValue),
                CourseName = cobcourse.Text
            };
            StudentController studentController = new StudentController();
            try
            {
                studentController.AddStudent(student);
                ClearFields();
                LoadStudent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK);
            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a Student to Edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Student student = new Student
            {
                Name = txtname.Text,
                NIC = txtnic.Text,
                Username = txtusername.Text,
                Password = txtpassword.Text,
                CourseId = Convert.ToInt32(cobcourse.SelectedValue),
            };
            StudentController controller = new StudentController();
            controller.UpdateStudent(selectedStudentId, student);
            LoadStudent();
            ClearFields();

        }

        private void dgvstudent_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvstudent.SelectedRows.Count > 0)
            {
                var row = dgvstudent.SelectedRows[0];

                selectedStudentId = Convert.ToInt32(row.Cells["Id"].Value);
                txtname.Text = row.Cells["Name"].Value.ToString();
                txtnic.Text = row.Cells["NIC"].Value.ToString();
                cobcourse.Text = row.Cells["CourseName"].Value.ToString();

                StudentController controller = new StudentController();
                var Logindetails = controller.FindUsernamePassword(selectedStudentId);
                txtusername.Text = Logindetails.Username;
                txtpassword.Text = Logindetails.Password;
            }
            else
            {
                ClearFields();
                selectedStudentId = -1;
            }
        }

        private void pbback_Click(object sender, EventArgs e)
        {

            this.Parent.Controls.Remove(this);
        }
    }
}
