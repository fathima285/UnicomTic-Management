namespace UMS2.view
{
    partial class AdminForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnhide = new System.Windows.Forms.Button();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnsignup = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.lbl01 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(360, 384);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Enter += new System.EventHandler(this.txtusername_Enter);
            this.button1.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // btnhide
            // 
            this.btnhide.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnhide.Location = new System.Drawing.Point(588, 253);
            this.btnhide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(67, 23);
            this.btnhide.TabIndex = 12;
            this.btnhide.Text = "Hide";
            this.btnhide.UseVisualStyleBackColor = true;
            this.btnhide.Click += new System.EventHandler(this.btnhide_Click);
            this.btnhide.Enter += new System.EventHandler(this.txtusername_Enter);
            this.btnhide.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // btnshow
            // 
            this.btnshow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnshow.Location = new System.Drawing.Point(588, 253);
            this.btnshow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(67, 23);
            this.btnshow.TabIndex = 11;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            this.btnshow.Enter += new System.EventHandler(this.txtusername_Enter);
            this.btnshow.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // btnsignup
            // 
            this.btnsignup.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnsignup.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnsignup.Location = new System.Drawing.Point(302, 324);
            this.btnsignup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsignup.Name = "btnsignup";
            this.btnsignup.Size = new System.Drawing.Size(222, 45);
            this.btnsignup.TabIndex = 10;
            this.btnsignup.Text = "Sign Up";
            this.btnsignup.UseVisualStyleBackColor = false;
            this.btnsignup.Click += new System.EventHandler(this.btnsignup_Click);
            this.btnsignup.Enter += new System.EventHandler(this.txtusername_Enter);
            this.btnsignup.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // txtpassword
            // 
            this.txtpassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtpassword.Location = new System.Drawing.Point(263, 256);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(306, 22);
            this.txtpassword.TabIndex = 9;
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter);
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            // 
            // txtusername
            // 
            this.txtusername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtusername.Location = new System.Drawing.Point(263, 198);
            this.txtusername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(306, 22);
            this.txtusername.TabIndex = 8;
            this.txtusername.TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            this.txtusername.Enter += new System.EventHandler(this.txtusername_Enter);
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // lbl01
            // 
            this.lbl01.Font = new System.Drawing.Font("Modern No. 20", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl01.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl01.Location = new System.Drawing.Point(230, 92);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(368, 78);
            this.lbl01.TabIndex = 7;
            this.lbl01.Text = "Create Account";
            this.lbl01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01.Click += new System.EventHandler(this.lbl01_Click);
            this.lbl01.Enter += new System.EventHandler(this.txtusername_Enter);
            this.lbl01.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 513);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnhide);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.btnsignup);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.lbl01);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btnsignup;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label lbl01;
    }
}