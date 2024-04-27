using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBookstore
{
    // Class for the sign up form
    public partial class SignUpForm : Form
    {
        // Constructor
        public SignUpForm()
        {
            InitializeComponent();
        }

        // Event handler for clicking the signup button -- must enter credentials
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

        // Encrypts a password with SHA256
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

        // Checks if a user is already in the database. If not, adds them
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

                // Try to get an existing user
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    object result = command.ExecuteScalar();

                    if (result != null)
                        return (int)result;
                }

                // If user doesn't exist, create a new one
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                    try
                    {
                        return (int)command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("User already exists.");
                        return -1;
                    }
                }
            }
        }

        // Event handler for clicking the admin access button -- loads the admin login form
        private void uxAdminAccesButton_Click(object sender, EventArgs e)
        {
            AdminLogInForm adminLoginForm = new AdminLogInForm();
            adminLoginForm.Show();
            this.Hide();
        }
    }
}