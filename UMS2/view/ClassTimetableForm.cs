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
    public partial class ClassTimetableForm : Form
    {
        int selectedTimetableId = -1;
        public ClassTimetableForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClassTimetableForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadTimetables();



        }

        private void LoadSubjects()
        {
            SubjectController controller = new SubjectController();
            cobsubject.DataSource = controller.GetSubjectList();
            cobsubject.DisplayMember = "Name";
            cobsubject.ValueMember = "Id";
            cobsubject.SelectedIndex = -1;
        }

        private void LoadTimetables()
        {
            ClassTimetableController controller = new ClassTimetableController();
            dgvclass.DataSource = controller.GetAllTimetables();

            dgvclass.Columns["Id"].Visible = false;
            dgvclass.Columns["SubjectId"].Visible = false;

            this.BeginInvoke(new Action(() =>
            {
                dgvclass.ClearSelection();
                dgvclass.CurrentCell = null;
                selectedTimetableId = -1;
                ClearFields();
            }));
        }

        private void ClearFields()
        {
            txtroom.Clear();
            dtdate.Value = DateTime.Now;
            txtstart.Clear();
            txtend.Clear();
            cobsubject.SelectedIndex = -1;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtroom.Text) ||
              string.IsNullOrWhiteSpace(txtstart.Text) ||
              string.IsNullOrWhiteSpace(txtend.Text) ||
              cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!TimeSpan.TryParse(txtstart.Text, out TimeSpan startTime) ||
                !TimeSpan.TryParse(txtend.Text, out TimeSpan endTime))
            {
                MessageBox.Show("Invalid time format. Use HH:mm.", "Format Error", MessageBoxButtons.OK);
                return;
            }

            ClassTimetable timetable = new ClassTimetable
            {
                SubjectId = Convert.ToInt32(cobsubject.SelectedValue),
                Room = txtroom.Text,
                ClassDate = dtdate.Value.Date,
                StartTime = startTime,
                EndTime = endTime
            };

            ClassTimetableController controller = new ClassTimetableController();
            controller.AddTimetable(timetable);
            ClearFields();
            LoadTimetables();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId == -1)
            {
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                ClassTimetableController controller = new ClassTimetableController();
                controller.DeleteTimetable(selectedTimetableId);
                ClearFields();
                LoadTimetables();
            }
        }

        private void dgvclass_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvclass.SelectedRows.Count > 0)
            {
                var row = dgvclass.SelectedRows[0];
                selectedTimetableId = Convert.ToInt32(row.Cells["Id"].Value);

                ClassTimetableController controller = new ClassTimetableController();
                var record = controller.GetTimetableById(selectedTimetableId);

                if (record != null)
                {
                    cobsubject.SelectedValue = record.SubjectId;
                    txtroom.Text = record.Room;
                    dtdate.Value = record.ClassDate;
                    txtstart.Text = record.StartTime.ToString(@"hh\:mm");
                    txtend.Text = record.EndTime.ToString(@"hh\:mm");
                }
            }
            else
            {
                ClearFields();
                selectedTimetableId = -1;
            }
        }
    }
}
    

