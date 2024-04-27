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
using System.Net;

namespace OnlineBookstore
{
    // Class for checking out and buying books
    public partial class BuyForm : Form
    {
        // The list of books a user wants to purchase
        private List<string> _booksToPurchase;

        // THe user ID of the customer
        private int _userID;

        // Constructor -- initializes book list and user id
        public BuyForm(List<string> booksToPurchase, int userID)
        {
            InitializeComponent();
            _booksToPurchase = booksToPurchase;
            _userID = userID;
            DisplayBooks();
        }

        // Displays all the books they added to their cart from the homepage
        private void DisplayBooks()
        {
            decimal total = 0m;
            foreach (string book in _booksToPurchase)
            {
                uxBuyList.Items.Add(book);
                int index = book.LastIndexOf('$') + 1;
                string priceStr = book.Substring(index);
                decimal price = decimal.Parse(priceStr);
                total += price;
            }
            uxTotalLabel.Text = $"Total: ${total:F2}";
        }

        // Event handler for pressing confirm and finalizing a purchase
        private void uxConfirmPurchase_Click(object sender, EventArgs e)
        {
            string firstName = uxFirstNameTextBox.Text;
            string lastName = uxLastNameTextBox.Text;
            string address = uxAddressTextBox.Text;
            string phone = uxPhoneNumberTextBox.Text;

            if (InsertCustomerData(firstName, lastName, address, phone))
            {
                MessageBox.Show("Purchase confirmed!");
                this.Close();
            }
        }

        // Adds the user to the customers table after pressing the confirm purchase button and entering credentials
        private bool InsertCustomerData(string firstName, string lastName, string address, string phone)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string customerQuery = "INSERT INTO Customers (UserID, FirstName, LastName, Address, Phone) VALUES (@UserID, @FirstName, @LastName, @Address, @Phone);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(customerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Phone", phone);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return false;
            }
        }
    }
}
