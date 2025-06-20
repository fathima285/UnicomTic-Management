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
    public partial class CourseForm : Form
    {
        int SelectedCourseId = -1;
        CourseController courseController;
        public CourseForm()
        {
            InitializeComponent();
            courseController = new CourseController();
        }
        // This is the event handler for the form load event.
        private void CourseForm_Load(object sender, EventArgs e)
        {

            dgvcourse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvcourse.MultiSelect = false;
            LoadCoursesToGrid();

        }

        //This Method Loads the courses into the DataGridView when the form loads.
        private void LoadCoursesToGrid()
        {
            dgvcourse.DataSource = courseController.GetCourseList();

            this.BeginInvoke(new Action(() =>
            {
                dgvcourse.ClearSelection();
                dgvcourse.CurrentCell = null;
                SelectedCourseId = -1;
                txtname.Clear();
            }));
        }
    
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (SelectedCourseId <= 0)
            {
                MessageBox.Show("Select a Course to delete!", "Error", MessageBoxButtons.OK);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CourseController courseController = new CourseController();
                courseController.DeleteCourse(SelectedCourseId);
            }

            SelectedCourseId = -1;
            txtname.Clear();
            LoadCoursesToGrid();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("Course Name Cannot be empty!", "Error", MessageBoxButtons.OK);
                return;
            }

            Course course = new Course
            {
                Name = txtname.Text.Trim()
            };
            courseController.AddCourse(course);

            txtname.Clear();
            LoadCoursesToGrid();
        }

        private void dgvcourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvcourse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvcourse.SelectedRows.Count == 0 || dgvcourse.CurrentCell == null)
            {
                SelectedCourseId = -1;
                txtname.Clear();
                return;
            }

            var row = dgvcourse.SelectedRows[0];
            var courseview = row.DataBoundItem as Course;

            if (courseview != null)
            {
                SelectedCourseId = courseview.Id;

                var course = courseController.GetCourseById(courseview.Id);
                if (course != null)
                {
                    txtname.Text = course.Name;
                }
            }
        }

        private void CourseForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
