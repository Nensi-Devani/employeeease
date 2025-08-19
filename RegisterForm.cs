using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// to use database
using System.Data;
using System.Data.SqlClient;


namespace EmployeeEase
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nensi Devani\Documents\employeeease.mdf;Integrated Security=True;Connect Timeout=30");

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

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkShowPassword.Checked ? '\0' : '*'; // to hide and show password
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUname.Text == "" || txtPass.Text == "")
                MessageBox.Show("Please fill all the fields ...", "Error Message !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else { 
                if(connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        // to check if the user already exist
                        string selectUname = "SELECT COUNT(*) FROM users WHERE username = @user";

                        using (SqlCommand checkUser = new SqlCommand(selectUname, connect))
                        {
                            checkUser.Parameters.AddWithValue("@user", txtUname.Text.Trim());
                            int count = (int)checkUser.ExecuteScalar();
                            if(count >= 1)
                            {
                                MessageBox.Show(txtUname.Text.Trim() +" is already taken !!!", "Error Message !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;

                                string insertData = "INSERT INTO users (username, password, date_register) VALUES(@username, @password, @dateReg)";

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@username", txtUname.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", txtPass.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dateReg", today);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered Successfully !", "Information Messsage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Form1 loginForm = new Form1();
                                    loginForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}
