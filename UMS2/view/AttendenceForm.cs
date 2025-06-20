using project.Controller;
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
    public partial class AttendenceForm : Form
    {
        string selectedStudentId = null;
        DateTime selectedDate;
        public AttendenceForm()
        {
            InitializeComponent();
        }
        public void LoadStudents()
        {
            StudentController studentController = new StudentController();
            var students = studentController.GetAll();

            var studentDict = new Dictionary<string, string>();
            foreach (var s in students)
            {
                studentDict[s.Id.ToString()] = s.Name;
            }

            cmbstudents.DataSource = new List<KeyValuePair<string, string>>(studentDict);
            cmbstudents.DisplayMember = "Value";
            cmbstudents.ValueMember = "Key";
            cmbstudents.SelectedIndex = -1;
        }

        public void LoadAttendence()
        {
            AttendenceController controller = new AttendenceController();
            dgvattendence.DataSource = controller.GetAll();
            dgvattendence.Columns["StudentName"].HeaderText = "Student Name";
            dgvattendence.Columns["StudentId"].HeaderText = "Student ID";
            dgvattendence.Columns["Date"].HeaderText = "Date";
            dgvattendence.Columns["Status"].HeaderText = "Status";

            this.BeginInvoke(new Action(() =>
            {
                dgvattendence.ClearSelection();
                dgvattendence.CurrentCell = null;
                selectedStudentId = null;
                ClearFields();
            }));
        }

        private void ClearFields()
        {
            cmbstudents.SelectedIndex = -1;
            cmbstatus.SelectedIndex = 0;
            dtpdate.Value = DateTime.Today;
        }
        private void AttendenceForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadAttendence();
            cmbstatus.Items.AddRange(new string[] { "Present", "Absent" });
            cmbstatus.SelectedIndex = 0;
        }
        

        private void cmbstudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvattendence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cmbstudents.SelectedIndex == -1 || cmbstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student and status.", "Error", MessageBoxButtons.OK);
                return;
            }

            Attendence attendence = new Attendence
            {
                StudentId = ((KeyValuePair<string, string>)cmbstudents.SelectedItem).Key,
                StudentName = ((KeyValuePair<string, string>)cmbstudents.SelectedItem).Value,
                Date = dtpdate.Value.Date,
                Status = cmbstatus.SelectedItem.ToString()
            };

            AttendenceController controller = new AttendenceController();
            controller.AddAttendence(attendence);
            ClearFields();
            LoadAttendence();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == null)
            {
                MessageBox.Show("Please select a record to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    AttendenceController controller = new AttendenceController();
                    controller.DeleteAttendence(selectedStudentId, selectedDate);
                    LoadAttendence();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvattendence_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvattendence.SelectedRows.Count > 0)
            {
                var row = dgvattendence.SelectedRows[0];

                selectedStudentId = row.Cells["StudentId"].Value.ToString();
                selectedDate = Convert.ToDateTime(row.Cells["Date"].Value);
                cmbstatus.SelectedItem = row.Cells["Status"].Value.ToString();

                cmbstudents.SelectedValue = selectedStudentId;
                dtpdate.Value = selectedDate;
            }
            else
            {
                ClearFields();
                selectedStudentId = null;
            }
        }
    }
}
