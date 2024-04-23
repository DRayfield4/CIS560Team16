using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace OnlineBookstore
{
    public partial class AdminLogInForm : Form
    {
        public AdminLogInForm()
        {
            InitializeComponent();
        }

        private void uxAdminLogInButton_Click(object sender, EventArgs e)
        {
            string email = uxAdminEmailTextbox.Text;
            string password = uxAdminPasswordTextbox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter an email and password.");
                return;
            }

            if (ValidateAdminLogin(email, password))
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid admin credentials.");
            }
        }

        private bool ValidateAdminLogin(string email, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash AND IsAdmin = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                conn.Open();
                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void uxReturnToSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }
    }
}
