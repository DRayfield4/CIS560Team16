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
using System.Diagnostics;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data.SqlClient;

namespace OnlineBookstore
{
    // Class users interact with -- buying and looking for books
    public partial class HomepageForm : Form
    {
        // The total count of books in the database
        private int _maxbook = 0;

        // The total of the books a user is purchasing
        private decimal price;

        // The user ID
        private int _userID;

        // Constructor that initializes user ID
        public HomepageForm(int userID)
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.HomepageForm_Load);
            _userID = userID;
        }

        // On load up of the homepage, disables certain buttons that need conditions to be met for them to enable -- loads all books into listbox
        private void HomepageForm_Load(object sender, EventArgs e)
        {

            uxBuy.Enabled = false;
            uxRemove.Enabled = false;

            LoadBooks();
            _maxbook = uxBookList.Items.Count;
            uxDisplaying.Text = _maxbook + " of " + _maxbook;
        }

        // Loads all the books that aren't removed into the list box
        private void LoadBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT ISBN, Title, Price FROM Books WHERE IsRemoved = 0";

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
        
        // Event handler for pressing the search/filter button -- has different cases for each filter option
        private void uxSearchButton_Click(object sender, EventArgs e)
        {
            string searchterm = uxSearchBox.Text.Trim();
            uxBookList.DataSource = null;

            if (string.IsNullOrWhiteSpace(searchterm))
            {
                if (uxFilter.SelectedItem?.ToString() == "Genre")
                {
                    string selectedGenre = uxGenreComboBox.Text;
                    ExecuteQueryFiltered("GenreName", selectedGenre);
                }
                else
                {
                    LoadBooks();
                }
            }
            else
            {
                if (uxFilter.SelectedItem?.ToString() == "Genre")
                {
                    string selectedGenre = uxGenreComboBox.Text;
                    ExecuteQueryFiltered("GenreName", selectedGenre);
                }
                else
                {
                    switch (uxFilter.SelectedItem?.ToString())
                    {
                        case "Title":
                            ExecuteQueryFiltered("Title", searchterm);
                            break;
                        case "Author":
                            ExecuteQueryFiltered("AuthorName", searchterm);
                            break;
                        case "ISBN":
                            ExecuteQueryFiltered("ISBN", searchterm);
                            break;
                        case "Price":
                            ExecuteQueryFiltered("Price", searchterm);
                            break;
                        case "Publisher":
                            ExecuteQueryFiltered("Publisher", searchterm);
                            break;
                        default:
                            MessageBox.Show("Invalid filter selection.");
                            break;
                    }
                }
            }
            uxSearchBox.Text = "";

            uxDisplaying.Text = uxBookList.Items.Count + " of " + _maxbook;
        }

        // Formats how books are displayed depending on which filter option is chosen
        private void FormatBookDisplay(object sender, ListControlConvertEventArgs e)
        {
            DataRowView row = e.ListItem as DataRowView;
            if (row != null)
            {
                string title = row["Title"].ToString();
                string author = row["AuthorName"].ToString();
                string isbn = row["ISBN"].ToString();
                string price = String.Format("{0:C}", row["Price"]);
                string publisher = row["Publisher"].ToString();
                string genre = row.Row.Table.Columns.Contains("GenreName") ? row["GenreName"].ToString() : "";

                switch (uxFilter.SelectedItem.ToString())
                {
                    case "Title":
                        e.Value = $"{title} by {author}";
                        break;
                    case "Author":
                        e.Value = $"Author: {author} - {title}";
                        break;
                    case "ISBN":
                        e.Value = $"{isbn} - {title}";
                        break;
                    case "Genre":
                        e.Value = $"Genre: {genre} - {title} by {author}";
                        break;
                    case "Price":
                        e.Value = $"{price} - {title} by {author}";
                        break;
                    case "Publisher":
                        e.Value = $"Publisher: {publisher} - {title} by {author}";
                        break;
                }
            }
        }

        // Performs SQL queries for the filters -- needed special Publisher, AuthorName, and GenreName cases
        private void ExecuteQueryFiltered(string fieldName, string filter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            DataTable books = new DataTable();
            string query = "";

            switch (fieldName)
            {
                case "Title":
                case "ISBN":
                case "Price":
                case "Publisher":
                    query = $@"SELECT ISBN, Title, Authors.AuthorName, Price, Publisher
                               FROM Books
                               INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                               WHERE {fieldName} LIKE @Filter AND IsRemoved = 0
                               ORDER BY {(fieldName == "Price" ? "Title" : fieldName)}";
                    break;
                case "AuthorName":
                    query = $@"SELECT ISBN, Title, Authors.AuthorName, Price, Publisher
                               FROM Books
                               INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                               WHERE Authors.AuthorName LIKE @Filter AND Books.IsRemoved = 0
                               ORDER BY Title";
                    break;
                case "GenreName":
                    query = $@"SELECT ISBN, Title, Authors.AuthorName, Genres.GenreName, Price, Publisher
                               FROM Books
                               INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                               INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                               WHERE Genres.GenreName LIKE @Filter AND Books.IsRemoved = 0
                               ORDER BY Title";
                    break;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Filter", $"%{filter}%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(books);

                uxBookList.DisplayMember = "Title";
                uxBookList.ValueMember = "ISBN";
                uxBookList.DataSource = books;
                uxBookList.Format += new ListControlConvertEventHandler(FormatBookDisplay);
            }
        }
        
        // Event handler for clicking the buy button -- loads the buy form to checkout
        private void uxBuy_Click(object sender, EventArgs e)
        {
            List<string> selectedBooks = new List<string>();
            foreach (var item in uxBuyList.Items)
            {
                selectedBooks.Add(item.ToString());
            }

            BuyForm buyForm = new BuyForm(selectedBooks, _userID);
            buyForm.Show();
        }

        // Event handler for clicking the add button -- adds books to cart
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

                    uxBuy.Enabled = uxBuyList.Items.Count > 0;
                }
            }
        }

        // Updates the total price of the books the user has selected
        private void updatePrice(decimal prices)
        {
            price += prices;
            uxPrice.Text = "Total: $" + price.ToString();
        }

        // Event handler to remove books from cart
        private void uxRemove_Click(object sender, EventArgs e)
        {
            if (uxBuyList.SelectedIndex != -1)
            {
                string item2 = uxBuyList.Items[uxBuyList.SelectedIndex].ToString();
                int index = item2.IndexOf('$') + 1;
                string substring = item2.Substring(index);
                price -= decimal.Parse(substring);
                uxPrice.Text = "Total: $" + price.ToString();
                uxBuyList.Items.RemoveAt(uxBuyList.SelectedIndex);

                uxBuy.Enabled = uxBuyList.Items.Count > 0;
            }

            if (uxBuyList.Items.Count <= 0)
            {
                uxRemove.Enabled = false;
            }
        }

        // Event handler that enables the buy and remove buttons once something is in user's cart
        private void uxBuyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxBuyList.Items.Count >= 1)
            {
                uxRemove.Enabled = true;
                uxBuy.Enabled = true;
            }
        }

        // Event handler for detecting if the genre search filter was selected
        private void uxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if filtering by genre. If so, display genre ComboBox
            uxGenreComboBox.Visible = uxFilter.SelectedItem?.ToString() == "Genre";
            if (uxGenreComboBox.Visible)
            {
                LoadGenres();
            }
        }

        // Load a new combobox with all the genres if it was chosen to filter by
        private void LoadGenres()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT GenreID, GenreName FROM Genres ORDER BY GenreName";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable genres = new DataTable();
                adapter.Fill(genres);

                uxGenreComboBox.DisplayMember = "GenreName";
                uxGenreComboBox.ValueMember = "GenreID";
                uxGenreComboBox.DataSource = genres;
            }
        }

        // Back button to the signup page
        private void uxBackButton_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }
    }
}