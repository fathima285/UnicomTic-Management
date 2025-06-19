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
    public partial class SubjectForm : Form
    {
        int selectedSubjectId = -1;
        public SubjectForm()
        {
            InitializeComponent();
            this.Load += SubjectForm_Load;
        }

        private void LoadCourses()
        {
            CourseController courseController = new CourseController();
            cobcourse.DataSource = courseController.GetCourseList();
            cobcourse.DisplayMember = "Name";
            cobcourse.ValueMember = "Id";
            cobcourse.SelectedIndex = -1;
        }

        private void LoadLecturers()
        {
            LecturerController lecturerController = new LecturerController();
            coblecturer.DataSource = lecturerController.GetLecturerList();
            coblecturer.DisplayMember = "Name";
            coblecturer.ValueMember = "Id";
            coblecturer.SelectedIndex = -1;

        }

        private void LoadSubjects()
        {
            SubjectController subjectController = new SubjectController();
            dgvsubject.DataSource = subjectController.GetSubjectList();
            dgvsubject.Columns["Id"].Visible = false;

            this.BeginInvoke(new Action(() =>
            {
                dgvsubject.ClearSelection();
                dgvsubject.CurrentCell = null;
                selectedSubjectId = -1;
                ClearFields();
            }));

        }

        private void ClearFields()
        {
            txtsubname.Clear();
            cobcourse.SelectedIndex = -1;
            coblecturer.SelectedIndex = -1;

        }

        private void txtsubname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cobcourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void coblecturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a Subject to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this Subject?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SubjectController controller = new SubjectController();
                    controller.DeleteSubject(selectedSubjectId);
                    LoadSubjects();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtsubname.Text) ||
                cobcourse.SelectedIndex == -1 || coblecturer.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            Subject subject = new Subject
            {
                Name = txtsubname.Text,
                CourseId = Convert.ToInt32(cobcourse.SelectedValue),
                LecturerId = Convert.ToInt32(coblecturer.SelectedValue),
                CourseName = cobcourse.Text,
                LecturerName = coblecturer.Text
            };

            SubjectController controller = new SubjectController();
            try
            {
                controller.AddSubject(subject);
                LoadSubjects();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding subject: {ex.Message}", "Error", MessageBoxButtons.OK);
            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a Subject to Edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Subject subject = new Subject
            {
                Name = txtsubname.Text,
                CourseId = Convert.ToInt32(cobcourse.SelectedValue),
                LecturerId = Convert.ToInt32(coblecturer.SelectedValue),
            };

            SubjectController controller = new SubjectController();
            controller.DeleteSubject(selectedSubjectId); // simple update method via delete+add
            controller.AddSubject(subject);
            LoadSubjects();
            ClearFields();
        }

        private void dgvsubject_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvsubject.SelectedRows.Count > 0)
            {
                var row = dgvsubject.SelectedRows[0];
                selectedSubjectId = Convert.ToInt32(row.Cells["Id"].Value);
                txtsubname.Text = row.Cells["Name"].Value.ToString();
                cobcourse.Text = row.Cells["CourseName"].Value.ToString();
                coblecturer.Text = row.Cells["LecturerName"].Value.ToString();
            }
            else
            {
                ClearFields();
                selectedSubjectId = -1;
            }
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

            LoadCourses();
            LoadLecturers();
            LoadSubjects();

        }
    }
}
