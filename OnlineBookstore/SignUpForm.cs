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

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter an email and password.");
                return;
            }

            string hashedPassword = HashPassword(password);
            int userId = GetUserOrCreate(email, hashedPassword, isAdmin);
            if (userId > 0)
            {
                HomepageForm homeForm = new HomepageForm(userId);
                homeForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sign up or login failed. Please check your details or try a different email.");
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

        private int GetUserOrCreate(string email, string passwordHash, bool isAdmin)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            // Check if the user already exists
            string checkQuery = "SELECT UserID FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash";

            // If not exists, insert new user
            string insertQuery = "INSERT INTO Users (Email, PasswordHash, IsAdmin) OUTPUT INSERTED.UserID VALUES (@Email, @PasswordHash, @IsAdmin)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // First, try to get an existing user
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    object result = command.ExecuteScalar();

                    if (result != null)
                        return (int)result;  // User exists, return existing UserID
                }

                // If no existing user, create a new one
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                    try
                    {
                        return (int)command.ExecuteScalar();  // Return new UserID
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Error: " + ex.Message);
                        return -1;  // Error or duplicate key
                    }
                }
            }
        }

        private void uxAdminAccesButton_Click(object sender, EventArgs e)
        {
            AdminLogInForm adminLoginForm = new AdminLogInForm();
            adminLoginForm.Show();
            this.Hide();
        }
    }
}