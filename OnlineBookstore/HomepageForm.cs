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
using System.Collections;

namespace OnlineBookstore
{
    public partial class HomepageForm : Form
    {
        private int _maxbook = 0;
        private decimal price;
        public HomepageForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.HomepageForm_Load);
        }



        private void HomepageForm_Load(object sender, EventArgs e)
        {

            uxBuy.Enabled = false;
            uxRemove.Enabled = false;
            //disables buttons

            LoadBooks();
            _maxbook = uxBookList.Items.Count; //gets max book count
            uxDisplaying.Text = _maxbook + " of " + _maxbook;
        }

        private void LoadBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT ISBN, Title, Price FROM Books WHERE IsRemoved = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable books = new DataTable();
                adapter.Fill(books);

                uxBookList.DisplayMember = "Title";
                uxBookList.ValueMember = "ISBN";
                uxBookList.DataSource = books;
            }
        }


        private void uxSearchButton_Click(object sender, EventArgs e)
        {
            //if user serches for "" should they be able to return a list of everythign just in a different order?
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
            List<string> selectedBooks = new List<string>();
            foreach (var item in uxBuyList.Items)
            {
                selectedBooks.Add(item.ToString());
            }

            BuyForm buyForm = new BuyForm(selectedBooks);
            buyForm.Show();
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
                using (SqlDataReader reader = cmd.ExecuteReader())
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
                using (SqlDataReader reader = cmd.ExecuteReader())
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


        private void uxAdd_Click(object sender, EventArgs e)
        {
            if (uxBookList.SelectedItem != null)
            {
                DataRowView selectedBook = uxBookList.SelectedItem as DataRowView;
                if (selectedBook != null)
                {
                    string title = selectedBook["Title"].ToString();
                    decimal price = Convert.ToDecimal(selectedBook["Price"]);
                    string displayText = $"{title} - ${price:F2}";

                    uxBuyList.Items.Add(displayText);
                    updatePrice(price);
                }
            }
        }

        private void updatePrice(decimal prices)
        {
            price += prices;
            uxPrice.Text = "Total: $" + price.ToString();
        }

        private void uxRemove_Click(object sender, EventArgs e)
        {
            string item2 = uxBuyList.Items[uxBuyList.SelectedIndex].ToString();
            int index = item2.IndexOf('$') + 1;
            string substring = item2.Substring(index);
            price -= decimal.Parse(substring);
            uxPrice.Text = "Total: $" + price.ToString();
            uxBuyList.Items.RemoveAt(uxBuyList.SelectedIndex);
            if (uxBuyList.Items.Count <= 0)
            {
                uxRemove.Enabled = false;
            }
        }

        private void uxBuyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxBuyList.Items.Count >= 1)
            {
                uxRemove.Enabled = true;
            }
        }
    }
}