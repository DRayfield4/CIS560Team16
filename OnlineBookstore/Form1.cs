using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System;
using YourNamespace;

namespace OnlineBookstore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseTest dbTest = new DatabaseTest();
            try
            {
                dbTest.TestConnection();
                label1.Text = "Connection successful!";
                label1.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                label1.Text = "Failed to connect: " + ex.Message;
                label1.ForeColor = Color.Red;
            }
        }
    }
}