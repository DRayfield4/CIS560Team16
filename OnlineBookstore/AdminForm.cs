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

            switch (uxAggregatingQueriesComboBox.SelectedIndex)
            {
                case 0: // Total sales revenue for each genre
                    break;
                case 1: // Top 10 bestselling authors
                    break;
                case 2: // Monthly revenue over certain amount of years
                    uxStartDatePicker.Visible = true;
                    uxEndDatePicker.Visible = true;
                    uxStartDateLabel.Visible = true;
                    uxEndDateLabel.Visible = true;
                    break;
                case 3: // Distribution of frequent customers
                    uxStartDatePicker.Visible = true;
                    uxEndDatePicker.Visible = true;
                    uxStartDateLabel.Visible = true;
                    uxEndDateLabel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void uxResultButton_Click(object sender, EventArgs e)
        {
            switch (uxAggregatingQueriesComboBox.SelectedItem.ToString())
            {
                case "1) Total sales revenue for each genre":
                    ExecuteQuery1();
                    break;
                case "2) Top 10 bestselling authors":
                    ExecuteQuery2();
                    break;
                case "3) Monthly revenue over certain amount of years":
                    DateTime startDate3 = uxStartDatePicker.Value;
                    DateTime endDate3 = uxEndDatePicker.Value;
                    ExecuteQuery3(startDate3, endDate3);
                    break;
                case "4) Distribution of frequent customers":
                    DateTime startDate4 = uxStartDatePicker.Value;
                    DateTime endDate4 = uxEndDatePicker.Value;
                    ExecuteQuery4(startDate4, endDate4);
                    break;
                default:
                    MessageBox.Show("Please don't touch me unless you select a valid query!");
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
                    AVG(od.Price) AS AveragePrice, 
                    COUNT(*) AS TotalBooksSold 
                FROM Genres g
                INNER JOIN Books b ON g.GenreID = b.GenreID
                INNER JOIN OrderDetails od ON b.ISBN = od.ISBN
                GROUP BY g.GenreName";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) // getting ISBN error here
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

            using (SqlConnection conn = new SqlConnection(connectionString)) // Same ISBN error
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
                )
                SELECT 
                    CASE 
                        WHEN NumberOfOrders = 1 THEN 'Single Purchase'
                        WHEN NumberOfOrders > 1 AND NumberOfOrders <= 5 THEN 'Multiple Purchases'
                        ELSE 'Frequent Purchases' 
                    END AS CustomerFrequencyCategory,
                    COUNT(*) AS NumberOfCustomers,
                    COUNT(*) * 100.0 / (SELECT COUNT(*) FROM CustomerFrequency) AS PercentageOfTotalCustomers
                FROM CustomerFrequency
                GROUP BY CASE 
                    WHEN NumberOfOrders = 1 THEN 'Single Purchase'
                    WHEN NumberOfOrders > 1 AND NumberOfOrders <= 5 THEN 'Multiple Purchases'
                    ELSE 'Frequent Purchases' 
                END";

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
                        double percentageOfTotalCustomers = (double)reader["PercentageOfTotalCustomers"];

                        uxResultListBox.Items.Add($"{category}: {numberOfCustomers} Customers ({percentageOfTotalCustomers:N2}%)");
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
    }
}
