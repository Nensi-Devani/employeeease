using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeEase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // to close the app
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show(); // show register form
            this.Hide(); // to hide login form
        }

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkShowPassword.Checked ? '\0' : '*';
        }
    }
}
