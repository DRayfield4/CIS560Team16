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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Test if database connection is working -- ignore
        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseTest dbTest = new DatabaseTest();
            try
            {
                dbTest.TestConnection();
                label1.Text = "Connection successful!";
                label1.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                label1.Text = "Failed to connect: " + ex.Message;
                label1.ForeColor = Color.Red;
            }
        }

        private void EventHandlerSignUpButton(object sender, EventArgs e)
        {
            string email = uxEmailTextbox.Text;
            string password = uxPasswordTextbox.Text;
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter an email and password.");
                return;
            }

            string hashedPassword = HashPassword(password);
            if (InsertUserIntoDatabase(email, hashedPassword))
            {
                Form2 homeForm = new Form2();
                homeForm.Show();
                this.Close();
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
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool InsertUserIntoDatabase(string email, string passwordHash)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "INSERT INTO Users (Email, PasswordHash) VALUES (@Email, @PasswordHash)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        return true; // Success
                    }
                    catch (SqlException)
                    {
                        return false; // Fail
                    }
                }
            }
        }

        private void uxGuestButton_Click(object sender, EventArgs e)
        {
            Form2 homeForm = new Form2();
            homeForm.Show();
            this.Close();
        }
    }
}