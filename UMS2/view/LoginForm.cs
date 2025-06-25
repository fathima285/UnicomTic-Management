using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS2.Service;

namespace UMS2.view
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var service = new UserService();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var result = service.ValidateLogin(username, password);
            if (result.success)
            {
                this.Hide();
                switch (result.role)
                {
                    case "Admin":
                        new AdminDashboardForm().Show();
                        break;
                    case "Student":
                        new StudentDashboard(username).Show();
                        break;
                    case "Lecturer":
                        new LecturerDashboard().Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var reg = new RegisterForm();
            reg.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
