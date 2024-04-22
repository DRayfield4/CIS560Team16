namespace OnlineBookstore
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 mainForm = new Form1(); // Create an instance of Form1
            Form2 homeForm = new Form2(); // Create an instance of Form2

            // Show Form1
            mainForm.Show();

            Application.Run();
        }
    }
}