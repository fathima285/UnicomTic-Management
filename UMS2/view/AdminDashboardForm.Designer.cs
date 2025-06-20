namespace UMS2.view
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            this.pnl_center = new System.Windows.Forms.Panel();
            this.pnl_select = new System.Windows.Forms.Panel();
            this.btn_marks = new System.Windows.Forms.Button();
            this.btn_exam = new System.Windows.Forms.Button();
            this.btn_class = new System.Windows.Forms.Button();
            this.btn_student = new System.Windows.Forms.Button();
            this.btn_subject = new System.Windows.Forms.Button();
            this.btn_lecturer = new System.Windows.Forms.Button();
            this.btn_course = new System.Windows.Forms.Button();
            this.pnl_up = new System.Windows.Forms.Panel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pnl_select.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_center
            // 
            this.pnl_center.BackColor = System.Drawing.SystemColors.Info;
            this.pnl_center.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_center.BackgroundImage")));
            this.pnl_center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_center.Location = new System.Drawing.Point(233, 80);
            this.pnl_center.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_center.Name = "pnl_center";
            this.pnl_center.Size = new System.Drawing.Size(710, 642);
            this.pnl_center.TabIndex = 5;
            this.pnl_center.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_center_Paint);
            // 
            // pnl_select
            // 
            this.pnl_select.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnl_select.Controls.Add(this.btn_marks);
            this.pnl_select.Controls.Add(this.btn_exam);
            this.pnl_select.Controls.Add(this.btn_class);
            this.pnl_select.Controls.Add(this.btn_student);
            this.pnl_select.Controls.Add(this.btn_subject);
            this.pnl_select.Controls.Add(this.btn_lecturer);
            this.pnl_select.Controls.Add(this.btn_course);
            this.pnl_select.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_select.Location = new System.Drawing.Point(0, 80);
            this.pnl_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_select.Name = "pnl_select";
            this.pnl_select.Size = new System.Drawing.Size(233, 642);
            this.pnl_select.TabIndex = 3;
            this.pnl_select.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_select_Paint);
            // 
            // btn_marks
            // 
            this.btn_marks.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_marks.Location = new System.Drawing.Point(22, 382);
            this.btn_marks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_marks.Name = "btn_marks";
            this.btn_marks.Size = new System.Drawing.Size(178, 30);
            this.btn_marks.TabIndex = 6;
            this.btn_marks.Text = "Marks Management";
            this.btn_marks.UseVisualStyleBackColor = false;
            this.btn_marks.Click += new System.EventHandler(this.btn_marks_Click);
            // 
            // btn_exam
            // 
            this.btn_exam.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_exam.Location = new System.Drawing.Point(22, 339);
            this.btn_exam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exam.Name = "btn_exam";
            this.btn_exam.Size = new System.Drawing.Size(178, 30);
            this.btn_exam.TabIndex = 5;
            this.btn_exam.Text = "Exam Management";
            this.btn_exam.UseVisualStyleBackColor = false;
            this.btn_exam.Click += new System.EventHandler(this.btn_exam_Click);
            // 
            // btn_class
            // 
            this.btn_class.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_class.Location = new System.Drawing.Point(22, 295);
            this.btn_class.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_class.Name = "btn_class";
            this.btn_class.Size = new System.Drawing.Size(178, 40);
            this.btn_class.TabIndex = 4;
            this.btn_class.Text = "Class Timetable Management";
            this.btn_class.UseVisualStyleBackColor = false;
            this.btn_class.Click += new System.EventHandler(this.btn_class_Click);
            // 
            // btn_student
            // 
            this.btn_student.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_student.Location = new System.Drawing.Point(22, 250);
            this.btn_student.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_student.Name = "btn_student";
            this.btn_student.Size = new System.Drawing.Size(178, 30);
            this.btn_student.TabIndex = 3;
            this.btn_student.Text = "Student Management";
            this.btn_student.UseVisualStyleBackColor = false;
            this.btn_student.Click += new System.EventHandler(this.btn_student_Click);
            // 
            // btn_subject
            // 
            this.btn_subject.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_subject.Location = new System.Drawing.Point(22, 206);
            this.btn_subject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_subject.Name = "btn_subject";
            this.btn_subject.Size = new System.Drawing.Size(178, 30);
            this.btn_subject.TabIndex = 2;
            this.btn_subject.Text = "Subject Management";
            this.btn_subject.UseVisualStyleBackColor = false;
            this.btn_subject.Click += new System.EventHandler(this.btn_subject_Click);
            // 
            // btn_lecturer
            // 
            this.btn_lecturer.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_lecturer.Location = new System.Drawing.Point(22, 162);
            this.btn_lecturer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_lecturer.Name = "btn_lecturer";
            this.btn_lecturer.Size = new System.Drawing.Size(178, 30);
            this.btn_lecturer.TabIndex = 1;
            this.btn_lecturer.Text = "Lecturer Management";
            this.btn_lecturer.UseVisualStyleBackColor = false;
            this.btn_lecturer.Click += new System.EventHandler(this.btn_lecturer_Click);
            // 
            // btn_course
            // 
            this.btn_course.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_course.Location = new System.Drawing.Point(22, 115);
            this.btn_course.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_course.Name = "btn_course";
            this.btn_course.Size = new System.Drawing.Size(178, 30);
            this.btn_course.TabIndex = 0;
            this.btn_course.Text = "Course Management";
            this.btn_course.UseVisualStyleBackColor = false;
            this.btn_course.Click += new System.EventHandler(this.btn_course_Click);
            // 
            // pnl_up
            // 
            this.pnl_up.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_up.Location = new System.Drawing.Point(0, 0);
            this.pnl_up.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_up.Name = "pnl_up";
            this.pnl_up.Size = new System.Drawing.Size(943, 80);
            this.pnl_up.TabIndex = 4;
            this.pnl_up.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_up_Paint);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 722);
            this.Controls.Add(this.pnl_center);
            this.Controls.Add(this.pnl_select);
            this.Controls.Add(this.pnl_up);
            this.Name = "AdminDashboardForm";
            this.Text = "AdminDashboardForm";
            this.pnl_select.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_center;
        private System.Windows.Forms.Panel pnl_select;
        private System.Windows.Forms.Button btn_marks;
        private System.Windows.Forms.Button btn_exam;
        private System.Windows.Forms.Button btn_class;
        private System.Windows.Forms.Button btn_student;
        private System.Windows.Forms.Button btn_subject;
        private System.Windows.Forms.Button btn_lecturer;
        private System.Windows.Forms.Button btn_course;
        private System.Windows.Forms.Panel pnl_up;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}