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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // to close the app
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show(); // to show login form
            this.Hide(); // to hide register form
        }
    }
}
