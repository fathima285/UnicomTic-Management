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

namespace UMS2
{
    public partial class Form1 : Form
    {
        int SelectedCourseId = -1;
        CourseController courseController;
        public Form1()
        {
            InitializeComponent();
            courseController = new CourseController();
        }
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
    }
}
