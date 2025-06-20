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
        private int selectedSubjectId = -1;
        public SubjectForm()
        {
            InitializeComponent();
            this.Load += SubjectForm_Load;
            dgvsubject.SelectionChanged += dgvsubject_SelectionChanged;

            btnadd.Click += btnadd_Click;
            btnedit.Click += btnedit_Click;
            btndelete.Click += btndelete_Click;
        }

        private void LoadCourses()
        {
            var courseController = new CourseController();
            cobcourse.DataSource = courseController.GetCourseList();
            cobcourse.DisplayMember = "Name";
            cobcourse.ValueMember = "Id";
            cobcourse.SelectedIndex = -1;
        }

       

        private void LoadSubjects()
        {
            var subjectController = new SubjectController();
            dgvsubject.DataSource = subjectController.GetSubjectList();

            // Hide Id and foreign keys if present
            if (dgvsubject.Columns["Id"] != null)
                dgvsubject.Columns["Id"].Visible = false;
            if (dgvsubject.Columns["CourseId"] != null)
                dgvsubject.Columns["CourseId"].Visible = false;
            if (dgvsubject.Columns["LecturerId"] != null)
                dgvsubject.Columns["LecturerId"].Visible = false;

            ClearFields();
            selectedSubjectId = -1;
        }

        private void ClearFields()
        {
            txtsubname.Clear();
            cobcourse.SelectedIndex = -1;
           
        }

        private void cobcourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtsubname_TextChanged(object sender, EventArgs e)
        {

        }

        private void coblecturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvsubject_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvsubject.SelectedRows.Count > 0)
            {
                var row = dgvsubject.SelectedRows[0];
                if (row.Cells["Id"].Value != null)
                {
                    selectedSubjectId = Convert.ToInt32(row.Cells["Id"].Value);
                    txtsubname.Text = row.Cells["Name"].Value?.ToString();
                    cobcourse.SelectedValue = row.Cells["CourseId"].Value;
                    
                }
            }
            else
            {
                ClearFields();
                selectedSubjectId = -1;
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsubname.Text) || cobcourse.SelectedIndex == -1 )
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subject = new Subject
            {
                Name = txtsubname.Text.Trim(),
                CourseId = Convert.ToInt32(cobcourse.SelectedValue),
               
            };

            var controller = new SubjectController();
            controller.AddSubject(subject);

            LoadSubjects();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subject = new Subject
            {
                Id = selectedSubjectId,
                Name = txtsubname.Text.Trim(),
                CourseId = Convert.ToInt32(cobcourse.SelectedValue),
              
            };

            var controller = new SubjectController();
            controller.UpdateSubject(subject);

            LoadSubjects();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var controller = new SubjectController();
                controller.DeleteSubject(selectedSubjectId);
                LoadSubjects();
            }
        }
    


        private void SubjectForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            
            LoadSubjects();
        }
    }
}
