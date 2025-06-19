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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            txtusername.Text = "Username";
            txtpassword.Text = "Password";
            txtusername.ForeColor = Color.Gray;
            txtpassword.ForeColor = Color.Gray;

            btnhide.Visible = false;
        }


        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.UseSystemPasswordChar = false; // If the password is still the placeholder, don't hide it
                return;
            }
            txtpassword.UseSystemPasswordChar = true;
            btnhide.Visible = false;
            btnshow.Visible = true;
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = false;
            btnshow.Visible = false;
            btnhide.Visible = true;
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {

            if (txtusername.Text == "Username" || txtpassword.Text == "Password" || string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Please enter a valid username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Admin admin = new Admin
            {
                Username = txtusername.Text.Trim(),
                Password = txtpassword.Text.Trim()
            };

            AdminController adminController = new AdminController();
            adminController.CreateAdmin(admin);

            this.Hide();
            AdminDashboardForm dashboardAdmin = new AdminDashboardForm();
            dashboardAdmin.ShowDialog();


        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void lbl01_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = string.Empty;
                txtusername.ForeColor = Color.Black;
            }

        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text))
            {
                txtusername.Text = "Username";
                txtusername.ForeColor = Color.Gray;
            }

        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                txtpassword.Text = "Password";
                txtpassword.ForeColor = Color.Gray;
                txtpassword.UseSystemPasswordChar = false; // Show password as plain text
            }

        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {

            if (txtpassword.Text == "Password")
            {
                txtpassword.Text = string.Empty;
                txtpassword.ForeColor = Color.Black;
                txtpassword.UseSystemPasswordChar = true; // Show password as hidden
            }

        }
    }
}
