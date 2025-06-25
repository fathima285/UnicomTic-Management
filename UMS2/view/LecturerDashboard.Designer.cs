namespace UMS2.view
{
    partial class LecturerDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnViewTimetable = new System.Windows.Forms.Button();
            this.btnManageMarks = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageExams = new System.Windows.Forms.Button();
            this.btnViewMarks = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewTimetable
            // 
            this.btnViewTimetable.Location = new System.Drawing.Point(141, 109);
            this.btnViewTimetable.Name = "btnViewTimetable";
            this.btnViewTimetable.Size = new System.Drawing.Size(110, 23);
            this.btnViewTimetable.TabIndex = 0;
            this.btnViewTimetable.Text = "ViewTimetable";
            this.btnViewTimetable.UseVisualStyleBackColor = true;
            this.btnViewTimetable.Click += new System.EventHandler(this.btnViewTimetable_Click);
            // 
            // btnManageMarks
            // 
            this.btnManageMarks.Location = new System.Drawing.Point(141, 184);
            this.btnManageMarks.Name = "btnManageMarks";
            this.btnManageMarks.Size = new System.Drawing.Size(110, 23);
            this.btnManageMarks.TabIndex = 1;
            this.btnManageMarks.Text = "ManageMarks";
            this.btnManageMarks.UseVisualStyleBackColor = true;
            this.btnManageMarks.Click += new System.EventHandler(this.btnManageMarks_Click);
            // 
            // btnManageStudents
            // 
            this.btnManageStudents.Location = new System.Drawing.Point(141, 249);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(110, 54);
            this.btnManageStudents.TabIndex = 2;
            this.btnManageStudents.Text = "Manage Students";
            this.btnManageStudents.UseVisualStyleBackColor = true;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // btnManageCourses
            // 
            this.btnManageCourses.Location = new System.Drawing.Point(141, 329);
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(75, 49);
            this.btnManageCourses.TabIndex = 3;
            this.btnManageCourses.Text = " Manage Courses";
            this.btnManageCourses.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(242, 37);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(44, 16);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "label1";
            // 
            // btnManageExams
            // 
            this.btnManageExams.Location = new System.Drawing.Point(390, 109);
            this.btnManageExams.Name = "btnManageExams";
            this.btnManageExams.Size = new System.Drawing.Size(75, 50);
            this.btnManageExams.TabIndex = 5;
            this.btnManageExams.Text = " Manage Exams";
            this.btnManageExams.UseVisualStyleBackColor = true;
            // 
            // btnViewMarks
            // 
            this.btnViewMarks.Location = new System.Drawing.Point(390, 184);
            this.btnViewMarks.Name = "btnViewMarks";
            this.btnViewMarks.Size = new System.Drawing.Size(75, 42);
            this.btnViewMarks.TabIndex = 6;
            this.btnViewMarks.Text = " View Marks";
            this.btnViewMarks.UseVisualStyleBackColor = true;
            this.btnViewMarks.Click += new System.EventHandler(this.btnViewMarks_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(617, 323);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 60);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // LecturerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewMarks);
            this.Controls.Add(this.btnManageExams);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnManageCourses);
            this.Controls.Add(this.btnManageStudents);
            this.Controls.Add(this.btnManageMarks);
            this.Controls.Add(this.btnViewTimetable);
            this.Name = "LecturerDashboard";
            this.Text = "LecturerDashboard";
            this.Load += new System.EventHandler(this.LecturerDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewTimetable;
        private System.Windows.Forms.Button btnManageMarks;
        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnManageExams;
        private System.Windows.Forms.Button btnViewMarks;
        private System.Windows.Forms.Button btnLogout;
    }
}