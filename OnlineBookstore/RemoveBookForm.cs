using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookstore
{
    // Class for the remove book from database form
    public partial class RemoveBookForm : Form
    {
        // Keeps track of changes so you can undo them if wanted
        private List<string> _undoStack = new List<string>();

        // Constructor -- loads book on load
        public RemoveBookForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.RemoveBookForm_Load);
        }

        // On load up, loads the books
        private void RemoveBookForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        // Loads the books that aren't removed from database
        private void LoadBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT ISBN, Title FROM Books WHERE IsRemoved = 0 ORDER BY Title";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable books = new DataTable();
                adapter.Fill(books);

                uxBooksList.DisplayMember = "Title";
                uxBooksList.ValueMember = "ISBN";
                uxBooksList.DataSource = books;
            }
        }

        // Event handler for "removing" a book from the database
        private void uxRemoveBookButton_Click(object sender, EventArgs e)
        {
            if (uxBooksList.SelectedItem != null)
            {
                var selectedItem = uxBooksList.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    string selectedISBN = selectedItem["ISBN"].ToString();
                    SoftDeleteBook(selectedISBN);
                    _undoStack.Add(selectedISBN);
                }
            }
        }

        // Actual logic for setting a book's IsRemoved to 1 to soft delete it from database
        private void SoftDeleteBook(string isbn)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "UPDATE Books SET IsRemoved = 1 WHERE ISBN = @ISBN";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Book removed successfully!");
                    LoadBooks();
                }
            }
        }

        // Event handler that undos removing a book
        private void uxUndoButton_Click(object sender, EventArgs e)
        {
            if (_undoStack.Count > 0)
            {
                string isbnToRestore = _undoStack.Last();
                _undoStack.RemoveAt(_undoStack.Count - 1);
                UndoSoftDelete(isbnToRestore);
            }
        }

        // Resets the books IsRemoved property, adding it back to the database
        private void UndoSoftDelete(string isbn)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "UPDATE Books SET IsRemoved = 0 WHERE ISBN = @ISBN";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Undo successful!");
                    LoadBooks();
                }
            }
        }
    }
}
