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
    public partial class UpdateBookForm : Form
    {
        public UpdateBookForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.UpdateBookForm_Load);
        }

        private void UpdateBookForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadGenres();
        }

        private void LoadBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT ISBN, Title, AuthorName FROM Books JOIN Authors ON Books.AuthorID = Authors.AuthorID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable books = new DataTable();
                adapter.Fill(books);

                uxBooksListBox.DisplayMember = "Display";
                uxBooksListBox.ValueMember = "ISBN";
                foreach (DataRow row in books.Rows)
                {
                    uxBooksListBox.Items.Add(new { Display = $"{row["Title"]} by {row["AuthorName"]}", ISBN = row["ISBN"] });
                }
            }
        }

        private void LoadGenres()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT GenreID, GenreName FROM Genres ORDER BY GenreName";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable genres = new DataTable();
                adapter.Fill(genres);
                uxUpdateGenreComboBox.DataSource = genres;
                uxUpdateGenreComboBox.DisplayMember = "GenreName";
                uxUpdateGenreComboBox.ValueMember = "GenreID";
            }
        }

        private void uxBooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxBooksListBox.SelectedItem != null)
            {
                string selectedISBN = (uxBooksListBox.SelectedItem as dynamic).ISBN;
                LoadBookDetails(selectedISBN);
            }
        }

        private void LoadBookDetails(string isbn)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = @"
                SELECT ISBN, Title, Authors.AuthorName, GenreID, Edition, Price, PublicationDate, Publisher, IsRemoved
                FROM Books 
                JOIN Authors ON Books.AuthorID = Authors.AuthorID 
                WHERE ISBN = @ISBN";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        uxUpdateISBNTextBox.Text = reader["ISBN"].ToString();
                        uxUpdateTitleTextBox.Text = reader["Title"].ToString();
                        uxUpdateAuthorTextBox.Text = reader["AuthorName"].ToString();
                        uxUpdateEditionTextBox.Text = reader["Edition"].ToString();
                        uxUpdatePriceTextBox.Text = reader["Price"].ToString();
                        uxUpdatePublicationDateDatePicker.Value = Convert.ToDateTime(reader["PublicationDate"]);
                        uxUpdatePublisherTextBox.Text = reader["Publisher"].ToString();
                        uxUpdateGenreComboBox.SelectedValue = reader["GenreID"];
                        uxIsRemovedCheckBox.Checked = Convert.ToBoolean(reader["IsRemoved"]);
                    }
                }
            }
        }

        private void uxUpdateBookButton_Click(object sender, EventArgs e)
        {
            string isbn = uxUpdateISBNTextBox.Text;
            string title = uxUpdateTitleTextBox.Text;
            string author = uxUpdateAuthorTextBox.Text;
            int genreId = (int)uxUpdateGenreComboBox.SelectedValue;
            string edition = uxUpdateEditionTextBox.Text;
            decimal price = decimal.Parse(uxUpdatePriceTextBox.Text);
            DateTime publicationDate = uxUpdatePublicationDateDatePicker.Value;
            string publisher = uxUpdatePublisherTextBox.Text;
            bool isRemoved = uxIsRemovedCheckBox.Checked;

            int authorId = EnsureAuthorExists(author);

            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = @"
                UPDATE Books 
                SET Title = @Title, AuthorID = @AuthorID, GenreID = @GenreID, Edition = @Edition, Price = @Price, 
                    PublicationDate = @PublicationDate, Publisher = @Publisher, IsRemoved = @IsRemoved 
                WHERE ISBN = @ISBN";

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
                cmd.Parameters.AddWithValue("@IsRemoved", isRemoved);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Book updated successfully!");
                    LoadBooks();
                }
                else
                {
                    MessageBox.Show("Update failed. Please check your details.");
                }
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
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@AuthorName", authorName);
                    object result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@AuthorName", authorName);
                    return (int)insertCmd.ExecuteScalar();
                }
            }
        }
    }
}
