using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OnlineBookstore
{
    public partial class HomepageForm : Form
    {
        private bool _isadmin = false;
        public HomepageForm(bool isadmin)
        {
            _isadmin = isadmin;
            InitializeComponent();
        }



        private void HomepageForm_Load(object sender, EventArgs e)
        {
            //cant test if this works but quite sure it dosnt. 
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
            @"SELECT 
                b.Title AS BookTitle, 
                a.AuthorName
            FROM Authors a
            INNER JOIN Books b ON a.AuthorID = b.AuthorID
            ORDER BY b.Title";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string bookTitle = reader["BookTitle"].ToString();
                        string AuthorID = reader["AuthorID"].ToString();

                        uxBookList.Items.Add($"{bookTitle} by {AuthorID}");
                    }
                }
            }
        }

        private void uxAdminAccess_Click(object sender, EventArgs e)
        {
            if (_isadmin == true)
            {
                AdminLogInForm adminLoginForm = new AdminLogInForm();
                adminLoginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin access required");
            }

        }


        private void uxSearchButton_Click(object sender, EventArgs e)
        {
            string searchterm = uxSearchBox.Text.ToString();
            uxBookList.Items.Clear();
            switch (uxFilter.SelectedItem.ToString())
            {
                case "Title":
                    ExecuteQueryTitle(searchterm);
                    break;
                case "Author":
                    ExecuteQueryAuthor(searchterm);
                    break;
                case "ISBN":
                    ExecuteQueryISBN(searchterm);
                    break;
                case "Genre":
                    ExecuteQueryGenre(searchterm);
                    break;
                case "Price":
                    ExecuteQueryPrice(searchterm);
                    break;
                case "Publisher":
                    ExecuteQueryPublisher(searchterm);
                    break;
                default:
                    MessageBox.Show("Something went wrong");
                    break;
            }
        }
        private void uxBuy_Click(object sender, EventArgs e)
        {
            //in the future would open the buy form
        }
        //important all sql queres here
        #region Queries to complete
        private void ExecuteQueryTitle(string filter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"QUERY";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) // getting ISBN error here
                {
                    while (reader.Read())
                    {

                        uxBookList.Items.Add($"");
                    }
                }
            }
        }
        private void ExecuteQueryAuthor(string filter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"QUERY";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) // getting ISBN error here
                {
                    while (reader.Read())
                    {

                        uxBookList.Items.Add($"");
                    }
                }
            }
        }
        private void ExecuteQueryISBN(string filter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"QUERY";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) // getting ISBN error here
                {
                    while (reader.Read())
                    {

                        uxBookList.Items.Add($"");
                    }
                }
            }
        }
        private void ExecuteQueryGenre(string filter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"QUERY";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) // getting ISBN error here
                {
                    while (reader.Read())
                    {

                        uxBookList.Items.Add($"");
                    }
                }
            }
        }
        private void ExecuteQueryPrice(string filter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"QUERY";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) // getting ISBN error here
                {
                    while (reader.Read())
                    {

                        uxBookList.Items.Add($"");
                    }
                }
            }
        }
        private void ExecuteQueryPublisher(string filter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"QUERY";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) // getting ISBN error here
                {
                    while (reader.Read())
                    {

                        uxBookList.Items.Add($"");
                    }
                }
            }
        }
        #endregion 
        //important all sql queres here

        #region ignore
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            uxBuyList.Items.Add(uxFilter.SelectedItem);
        }

    }
}
