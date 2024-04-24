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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void uxAggregatingQueriesComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            uxResultListBox.Items.Clear();

            // Case for selecting the separator
            if (uxAggregatingQueriesComboBox.SelectedItem.ToString().Contains("----------------------------------------------------------"))
            {
                uxStartDatePicker.Visible = false;
                uxEndDatePicker.Visible = false;
                uxStartDateLabel.Visible = false;
                uxEndDateLabel.Visible = false;
                MessageBox.Show("Please select a valid query option.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Enable date pickers only for queries that require dates
                bool showDatePickers = uxAggregatingQueriesComboBox.SelectedIndex == 2 || uxAggregatingQueriesComboBox.SelectedIndex == 3;
                uxStartDatePicker.Visible = showDatePickers;
                uxEndDatePicker.Visible = showDatePickers;
                uxStartDateLabel.Visible = showDatePickers;
                uxEndDateLabel.Visible = showDatePickers;
            }
        }

        private void uxResultButton_Click(object sender, EventArgs e)
        {
            uxResultListBox.Items.Clear();

            string selectedQuery = uxAggregatingQueriesComboBox.SelectedItem.ToString();

            if (selectedQuery.Contains("---") || selectedQuery.Contains("Select"))
            {
                MessageBox.Show("Invalid option. Please select a valid query.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (selectedQuery)
            {
                case "1) Total sales revenue for each genre":
                    ExecuteQuery1();
                    break;
                case "2) Top 10 bestselling authors":
                    ExecuteQuery2();
                    break;
                case "3) Monthly revenue over certain amount of years":
                    ExecuteQuery3(uxStartDatePicker.Value, uxEndDatePicker.Value);
                    break;
                case "4) Distribution of frequent customers":
                    ExecuteQuery4(uxStartDatePicker.Value, uxEndDatePicker.Value);
                    break;
                case "- Display all users":
                    ExecuteQueryAllUsers();
                    break;
                case "- Display all books":
                    ExecuteQueryAllBooks();
                    break;
                case "- Display highest selling years":
                    ExecuteQueryHighestSellingYears();
                    break;
                default:
                    MessageBox.Show("Please select a valid query to run.", "Invalid Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void ExecuteQuery1()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"SELECT 
                    g.GenreName, 
                    SUM(od.Price) AS TotalRevenue,
                    CAST(AVG(od.Price) AS DECIMAL(10, 2)) AS AveragePrice,
                    COUNT(*) AS TotalBooksSold 
                FROM Genres g
                INNER JOIN Books b ON g.GenreID = b.GenreID
                INNER JOIN OrderDetails od ON b.ISBN = od.ISBN
                GROUP BY g.GenreName
                ORDER BY TotalRevenue DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string genreName = reader["GenreName"].ToString();
                        decimal totalRevenue = (decimal)reader["TotalRevenue"];
                        decimal averagePrice = (decimal)reader["AveragePrice"];
                        int totalBooksSold = (int)reader["TotalBooksSold"];

                        uxResultListBox.Items.Add($"{genreName}: Revenue = {totalRevenue}, Avg Price = {averagePrice}, Books Sold = {totalBooksSold}");
                    }
                }
            }
        }

        private void ExecuteQuery2()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"SELECT TOP 10
                    a.AuthorName, 
                    COUNT(*) AS TotalBooksSold, 
                    SUM(od.Price) AS TotalRevenue 
                FROM Authors a
                INNER JOIN Books b ON a.AuthorID = b.AuthorID
                INNER JOIN OrderDetails od ON b.ISBN = od.ISBN
                GROUP BY a.AuthorName 
                ORDER BY TotalBooksSold DESC, TotalRevenue DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string authorName = reader["AuthorName"].ToString();
                        int totalBooksSold = (int)reader["TotalBooksSold"];
                        decimal totalRevenue = (decimal)reader["TotalRevenue"];

                        uxResultListBox.Items.Add($"{authorName}: Books Sold = {totalBooksSold}, Total Revenue = {totalRevenue:C}");
                    }
                }
            }
        }

        private void ExecuteQuery3(DateTime startDate, DateTime endDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"WITH MonthlyRevenue AS (
                    SELECT 
                        YEAR(o.OrderDate) AS Year,
                        MONTH(o.OrderDate) AS Month,
                        SUM(od.Price) AS TotalRevenue
                    FROM Orders o
                    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                    WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                    GROUP BY YEAR(o.OrderDate), MONTH(o.OrderDate)
                ),
                RevenueChanges AS (
                    SELECT
                        Year,
                        Month,
                        TotalRevenue,
                        LAG(TotalRevenue) OVER (ORDER BY Year, Month) AS PreviousMonthRevenue
                    FROM MonthlyRevenue
                )
                SELECT
                    Year,
                    Month,
                    TotalRevenue,
                    PreviousMonthRevenue,
                    CASE 
                        WHEN PreviousMonthRevenue > 0 THEN
                            (TotalRevenue - PreviousMonthRevenue) / PreviousMonthRevenue * 100.0
                        ELSE 0
                    END AS MonthlyChangePercentage
                FROM RevenueChanges
                ORDER BY Year, Month;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int year = (int)reader["Year"];
                        int month = (int)reader["Month"];
                        decimal totalRevenue = (decimal)reader["TotalRevenue"];
                        decimal? previousMonthRevenue = reader["PreviousMonthRevenue"] as decimal?; // Null maye change this
                        decimal monthlyChangePercentage = reader.IsDBNull(reader.GetOrdinal("MonthlyChangePercentage")) ? 0 : (decimal)reader["MonthlyChangePercentage"];

                        uxResultListBox.Items.Add($"Year: {year}, Month: {month}, Revenue: {totalRevenue:C}, Previous: {previousMonthRevenue:C}, Change: {monthlyChangePercentage:N2}%");
                    }
                }
            }
        }

        private void ExecuteQuery4(DateTime startDate, DateTime endDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                    @"WITH CustomerFrequency AS (
                        SELECT 
                            c.CustomerID,
                            COUNT(o.OrderID) AS NumberOfOrders
                        FROM Customers c
                        INNER JOIN Orders o ON c.CustomerID = o.CustomerID
                        WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                        GROUP BY c.CustomerID
                      ),
                      TotalCustomers AS (
                        SELECT COUNT(*) AS Total FROM Customers  -- Total customers in the database
                      )
                    SELECT 
                        CASE 
                            WHEN NumberOfOrders = 1 THEN 'Single Purchase'
                            WHEN NumberOfOrders > 1 AND NumberOfOrders <= 5 THEN 'Multiple Purchases'
                            ELSE 'Frequent Purchases' 
                        END AS CustomerFrequencyCategory,
                        COUNT(*) AS NumberOfCustomers,
                        COUNT(*) * 100.0 / TotalCustomers.Total AS PercentageOfTotalCustomers
                    FROM CustomerFrequency
                    CROSS JOIN TotalCustomers  -- Get total customers count for percentage calculation
                    GROUP BY 
                        CASE 
                            WHEN NumberOfOrders = 1 THEN 'Single Purchase'
                            WHEN NumberOfOrders > 1 AND NumberOfOrders <= 5 THEN 'Multiple Purchases'
                            ELSE 'Frequent Purchases' 
                        END, TotalCustomers.Total";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string category = reader["CustomerFrequencyCategory"].ToString();
                        int numberOfCustomers = (int)reader["NumberOfCustomers"];
                        double percentageOfTotalCustomers = Convert.ToDouble(reader["PercentageOfTotalCustomers"]);

                        uxResultListBox.Items.Add($"{category}: {numberOfCustomers} Customers ({percentageOfTotalCustomers:N2}%)");
                    }
                }
            }
        }

        private void ExecuteQueryAllUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query = "SELECT UserID, Email, IsAdmin FROM Users ORDER BY UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userID = (int)reader["UserID"];
                        string email = reader["Email"].ToString();
                        bool isAdmin = (bool)reader["IsAdmin"];

                        uxResultListBox.Items.Add($"User ID: {userID}, Email: {email}, Admin: {isAdmin}");
                    }
                }
            }
        }

        private void ExecuteQueryAllBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"SELECT b.Title, a.AuthorName 
                  FROM Books b
                  JOIN Authors a ON b.AuthorID = a.AuthorID
                  ORDER BY b.Title";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = 1;
                    while (reader.Read())
                    {
                        string title = reader["Title"].ToString();
                        string authorName = reader["AuthorName"].ToString();

                        uxResultListBox.Items.Add($"{count}) {title} by {authorName}");
                        count++;
                    }
                }
            }
        }

        private void ExecuteQueryHighestSellingYears()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBookstoreDb"].ConnectionString;
            string query =
                @"SELECT 
                    YEAR(o.OrderDate) AS SalesYear, 
                    SUM(od.Price) AS TotalSales,
                    COUNT(*) AS TotalBooksSold
                  FROM Orders o
                  INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                  GROUP BY YEAR(o.OrderDate)
                  ORDER BY TotalSales DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int salesYear = (int)reader["SalesYear"];
                        decimal totalSales = (decimal)reader["TotalSales"];
                        int totalBooksSold = (int)reader["TotalBooksSold"];

                        uxResultListBox.Items.Add($"Year: {salesYear}, Total Sales: ${totalSales:N2}, Books Sold: {totalBooksSold}");
                    }
                }
            }
        }

        private void uxAddBookButton_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
        }

        private void uxUpdateBookButton_Click(object sender, EventArgs e)
        {
            UpdateBookForm updateBookForm = new UpdateBookForm();
            updateBookForm.ShowDialog();
        }

        private void uxRemoveBookButton_Click(object sender, EventArgs e)
        {
            RemoveBookForm removeBookForm = new RemoveBookForm();
            removeBookForm.ShowDialog();
        }

        private void uxBackButton_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }
    }
}
