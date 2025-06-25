namespace UMS2.view
{
    partial class StudentDashboard
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
            this.btnViewMarks = new System.Windows.Forms.Button();
            this.btnViewTimetable = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageMarks = new System.Windows.Forms.Button();
            this.btnManageExams = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnViewMarks
            // 
            this.btnViewMarks.Location = new System.Drawing.Point(96, 67);
            this.btnViewMarks.Name = "btnViewMarks";
            this.btnViewMarks.Size = new System.Drawing.Size(130, 23);
            this.btnViewMarks.TabIndex = 0;
            this.btnViewMarks.Text = "ViewMarks";
            this.btnViewMarks.UseVisualStyleBackColor = true;
            this.btnViewMarks.Click += new System.EventHandler(this.btnViewMarks_Click);
            // 
            // btnViewTimetable
            // 
            this.btnViewTimetable.Location = new System.Drawing.Point(96, 124);
            this.btnViewTimetable.Name = "btnViewTimetable";
            this.btnViewTimetable.Size = new System.Drawing.Size(130, 23);
            this.btnViewTimetable.TabIndex = 1;
            this.btnViewTimetable.Text = "ViewTimetable";
            this.btnViewTimetable.UseVisualStyleBackColor = true;
            this.btnViewTimetable.Click += new System.EventHandler(this.btnViewTimetable_Click);
            // 
            // btnManageStudents
            // 
            this.btnManageStudents.Location = new System.Drawing.Point(96, 170);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(130, 23);
            this.btnManageStudents.TabIndex = 2;
            this.btnManageStudents.Text = "ManageStudents";
            this.btnManageStudents.UseVisualStyleBackColor = true;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // btnManageCourses
            // 
            this.btnManageCourses.Location = new System.Drawing.Point(96, 225);
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(130, 23);
            this.btnManageCourses.TabIndex = 3;
            this.btnManageCourses.Text = "ManageCourses";
            this.btnManageCourses.UseVisualStyleBackColor = true;
            this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(443, 186);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(106, 48);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageMarks
            // 
            this.btnManageMarks.Location = new System.Drawing.Point(96, 332);
            this.btnManageMarks.Name = "btnManageMarks";
            this.btnManageMarks.Size = new System.Drawing.Size(130, 25);
            this.btnManageMarks.TabIndex = 5;
            this.btnManageMarks.Text = "ManageMarks";
            this.btnManageMarks.UseVisualStyleBackColor = true;
            this.btnManageMarks.Click += new System.EventHandler(this.btnManageMarks_Click);
            // 
            // btnManageExams
            // 
            this.btnManageExams.Location = new System.Drawing.Point(97, 283);
            this.btnManageExams.Name = "btnManageExams";
            this.btnManageExams.Size = new System.Drawing.Size(129, 23);
            this.btnManageExams.TabIndex = 6;
            this.btnManageExams.Text = "ManageExams";
            this.btnManageExams.UseVisualStyleBackColor = true;
            this.btnManageExams.Click += new System.EventHandler(this.btnManageExams_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(326, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(65, 16);
            this.lblWelcome.TabIndex = 7;
            this.lblWelcome.Text = "Welcome";
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnManageExams);
            this.Controls.Add(this.btnManageMarks);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageCourses);
            this.Controls.Add(this.btnManageStudents);
            this.Controls.Add(this.btnViewTimetable);
            this.Controls.Add(this.btnViewMarks);
            this.Name = "StudentDashboard";
            this.Text = "StudentDashboard";
            this.Load += new System.EventHandler(this.StudentDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewMarks;
        private System.Windows.Forms.Button btnViewTimetable;
        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageMarks;
        private System.Windows.Forms.Button btnManageExams;
        private System.Windows.Forms.Label lblWelcome;
    }
}