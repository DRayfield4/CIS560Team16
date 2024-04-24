using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sql;

namespace OnlineBookstore
{
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AddBookForm_Load);
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT GenreID, GenreName FROM Genres ORDER BY GenreName";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable genres = new DataTable();
                adapter.Fill(genres);
                uxAddGenreComboBox.DataSource = genres;
                uxAddGenreComboBox.DisplayMember = "GenreName";
                uxAddGenreComboBox.ValueMember = "GenreID";
            }
        }

        private int EnsureAuthorExists(string authorName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string checkQuery = "SELECT AuthorID FROM Authors WHERE AuthorName = @AuthorName";
            string insertQuery = "INSERT INTO Authors (AuthorName) OUTPUT INSERTED.AuthorID VALUES (@AuthorName)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Check if the author already exists
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@AuthorName", authorName);
                    object result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }

                // Insert the author since they don't exist
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@AuthorName", authorName);
                    return (int)insertCmd.ExecuteScalar();
                }
            }
        }


        private void uxAddBookButton_Click(object sender, EventArgs e)
        {
            string isbn = uxAddISBNTextBox.Text;
            string title = uxAddTitleTextBox.Text;
            string author = uxAddAuthorTextBox.Text;
            int genreId = (int)uxAddGenreComboBox.SelectedValue;
            string edition = uxAddEditionTextBox.Text;
            decimal price = decimal.Parse(uxAddPriceTextBox.Text);
            DateTime publicationDate = uxAddPublicationDateDatePicker.Value;
            string publisher = uxAddPublisherTextbox.Text;

            int authorId = EnsureAuthorExists(author);

            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "INSERT INTO Books (ISBN, Title, AuthorID, GenreID, Edition, Price, PublicationDate, Publisher) VALUES (@ISBN, @Title, @AuthorID, @GenreID, @Edition, @Price, @PublicationDate, @Publisher)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@AuthorID", authorId);
                cmd.Parameters.AddWithValue("@GenreID", genreId);
                cmd.Parameters.AddWithValue("@Edition", edition);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@PublicationDate", publicationDate);
                cmd.Parameters.AddWithValue("@Publisher", publisher);
                cmd.Parameters.AddWithValue("@IsRemoved", 0);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Book added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add the book.");
                }
            }
        }
    }
}
