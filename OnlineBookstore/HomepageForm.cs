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
using System.Globalization;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace OnlineBookstore
{
    public partial class HomepageForm : Form
    {
        private bool _isadmin = false;
        private int _maxbook = 0;
        public HomepageForm(bool isadmin)
        {
            InitializeComponent();
            _isadmin = isadmin;

        }



        private void HomepageForm_Load(object sender, EventArgs e)
        {

            uxBuy.Enabled = false;
            uxRemove.Enabled = false;
            //disables buttons
            if(_isadmin == false)
            {
                uxAdminAccess.Hide();
            }
            //hids admin button if not admin


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
            _maxbook = uxBookList.Items.Count; //gets max book count
            uxDisplaying.Text = _maxbook + " of " + _maxbook;
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
                MessageBox.Show("this message should play");
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
            uxDisplaying.Text = uxBookList.Items.Count + " of " + _maxbook;
        }
        private void uxBuy_Click(object sender, EventArgs e)
        {

            //in the future would open the buy form and somehow send all of the buylist to it
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

        private void uxAdd_Click(object sender, EventArgs e)
        {
            uxBuyList.Items.Add(uxFilter.SelectedItem);
            if (uxRemove.Enabled = false && uxBuyList.Items.Count >= 1)
            {
                uxRemove.Enabled = true;
            }
            updatePrice();
        }
        private void updatePrice()
        {
            double price = 0.0;
            foreach (string item in uxBuyList.Items)
            {
                price += double.Parse(item.Substring(item.IndexOf('$') + 1));   
            }
            uxPrice.Text = "Total: $" + price.ToString(); 
        }
        private void uxRemove_Click(object sender, EventArgs e)
        {
            if(uxBuyList.Items.Count - 1 <= 0)
            {
                uxRemove.Enabled = false;
            }
            updatePrice();
        } 

        private void uxBuyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxBuyList.Items.Count >= 1)//if nothing selected remove button disabled
            {
                uxRemove.Enabled = true;
            }

        }

        private void uxDisplaying_Click(object sender, EventArgs e)
        {

        }
    }
}
