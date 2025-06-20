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
    public partial class MarkForm : Form
    {
        int SelectedStudentId = -1;
        int SelectedExamId = -1;

        MarkController markController;
        public MarkForm()
        {
            InitializeComponent();
            markController = new MarkController();
        
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarks.SelectedRows.Count == 0 || dgvMarks.CurrentCell == null)
            {
                SelectedStudentId = -1;
                SelectedExamId = -1;
                txtStudentID.Clear();
                txtExamID.Clear();
                txtMarks.Clear();
                return;
            }

            var row = dgvMarks.SelectedRows[0];
            var mark = row.DataBoundItem as Mark;

            if (mark != null)
            {
                SelectedStudentId = mark.StudentId;
                SelectedExamId = mark.ExamId;

                var selectedMark = markController.GetMarkById(mark.StudentId, mark.ExamId);
                if (selectedMark != null)
                {
                    txtStudentID.Text = selectedMark.StudentId.ToString();
                    txtExamID.Text = selectedMark.ExamId.ToString();
                    txtMarks.Text = selectedMark.Marks.ToString();
                }
            }
        }


        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExamID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStudentID.Text.Trim(), out int studentId) ||
              !int.TryParse(txtExamID.Text.Trim(), out int examId) ||
              !int.TryParse(txtMarks.Text.Trim(), out int marks))
            {
                MessageBox.Show("Please enter valid numeric values for Student ID, Exam ID, and Marks.", "Input Error", MessageBoxButtons.OK);
                return;
            }

            if (marks < 0 || marks > 100)
            {
                MessageBox.Show("Marks must be between 0 and 100.", "Input Error", MessageBoxButtons.OK);
                return;
            }

            Mark mark = new Mark
            {
                StudentId = studentId,
                ExamId = examId,
                Marks = marks
            };

            markController.AddMark(mark);

            LoadMarksToGrid();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedStudentId == -1 || SelectedExamId == -1)
            {
                MessageBox.Show("Select a mark entry to delete!", "Error", MessageBoxButtons.OK);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this mark?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                markController.DeleteMark(SelectedStudentId, SelectedExamId);
                LoadMarksToGrid();
            }
        }

        private void MarkForm_Load(object sender, EventArgs e)
        {
            dgvMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarks.MultiSelect = false;

            LoadMarksToGrid();
        }

        private void LoadMarksToGrid()
        {
            dgvMarks.DataSource = markController.GetMarkList();

            this.BeginInvoke(new Action(() =>
            {
                dgvMarks.ClearSelection();
                dgvMarks.CurrentCell = null;
                SelectedStudentId = -1;
                SelectedExamId = -1;
                txtStudentID.Clear();
                txtExamID.Clear();
                txtMarks.Clear();
            }));
        }

        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
