using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Security.Cryptography;
using YourNamespace;
using System.Text;

namespace OnlineBookstore
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void EventHandlerSignUpButton(object sender, EventArgs e)
        {
            string email = uxEmailTextbox.Text;
            string password = uxPasswordTextbox.Text;
            bool isAdmin = uxIsAdminCheckbox.Checked;

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter an email and password.");
                return;
            }

            string hashedPassword = HashPassword(password);
            if (InsertUserIntoDatabase(email, hashedPassword, isAdmin))
            {
                HomepageForm homeForm = new HomepageForm(isAdmin);
                homeForm.Show();
            }
            else
            {
                MessageBox.Show("Sign up failed. Email might already be used.");
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

        private bool InsertUserIntoDatabase(string email, string passwordHash, bool isAdmin)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "INSERT INTO Users (Email, PasswordHash, IsAdmin) VALUES (@Email, @PasswordHash, @IsAdmin)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        return true; // Success
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Error: " + ex.Message);
                        return false; // Fail
                    }
                }
            }
        }

        private void uxGuestButton_Click(object sender, EventArgs e)
        {
            bool isadmin = uxIsAdminCheckbox.Checked;
            HomepageForm homeForm = new HomepageForm(isadmin);
            homeForm.Show();
            this.Close();
        }

        private void uxAdminAccesButton_Click(object sender, EventArgs e)
        {
            AdminLogInForm adminLoginForm = new AdminLogInForm();
            adminLoginForm.Show();
            this.Hide();
        }
    }
}