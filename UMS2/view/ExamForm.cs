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
   
    public partial class ExamForm : Form
    {
        int selectedExamId = -1;
        public ExamForm()
        {
            InitializeComponent();
        }
        private void LoadSubjects()
        {
            SubjectController controller = new SubjectController();
            cobsubject.DataSource = controller.GetSubjectList();
            cobsubject.DisplayMember = "Name";
            cobsubject.ValueMember = "Id";
            cobsubject.SelectedIndex = -1;
        }

        private void LoadExams()
        {
            ExamController controller = new ExamController();
            dgvexam.DataSource = controller.GetExamList();

            dgvexam.Columns["SubjectId"].Visible = false;

            this.BeginInvoke(new Action(() =>
            {
                dgvexam.ClearSelection();
                dgvexam.CurrentCell = null;
                selectedExamId = -1;
                ClearFields();
            }));
        }

        private void ClearFields()
        {
            txtname.Clear();
            dtExamDate.Value = DateTime.Now;
            txtstart.Text = "";
            txtend.Text = "";
            cobsubject.SelectedIndex = -1;
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cobsubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtExamDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtstart_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvexam_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvexam.SelectedRows.Count > 0)
            {
                var row = dgvexam.SelectedRows[0];
                selectedExamId = Convert.ToInt32(row.Cells["Id"].Value);

                ExamController controller = new ExamController();
                var exam = controller.GetExamById(selectedExamId);

                if (exam != null)
                {
                    txtname.Text = exam.Name;
                    dtExamDate.Value = exam.ExamDate;
                    txtstart.Text = exam.StartTime.ToString(@"hh\:mm");
                    txtend.Text = exam.EndTime.ToString(@"hh\:mm");
                    cobsubject.SelectedValue = exam.SubjectId;
                }
            }
            else
            {
                ClearFields();
                selectedExamId = -1;
            }
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadExams();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
               string.IsNullOrWhiteSpace(txtstart.Text) ||
               string.IsNullOrWhiteSpace(txtend.Text) ||
               cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!TimeSpan.TryParse(txtstart.Text, out TimeSpan start) ||
                !TimeSpan.TryParse(txtend.Text, out TimeSpan end))
            {
                MessageBox.Show("Start and End time must be in HH:mm format.", "Error", MessageBoxButtons.OK);
                return;
            }

            Exam exam = new Exam
            {
                Name = txtname.Text,
                SubjectId = Convert.ToInt32(cobsubject.SelectedValue),
                ExamDate = dtExamDate.Value.Date,
                StartTime = start,
                EndTime = end
            };

            ExamController controller = new ExamController();
            controller.AddExam(exam);
            ClearFields();
            LoadExams();

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an Exam to delete.", "Validation Error", MessageBoxButtons.OK);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this Exam?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                ExamController controller = new ExamController();
                controller.DeleteExam(selectedExamId);
                ClearFields();
                LoadExams();
            }
        }
    }
}
