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

            SignUpForm mainForm = new SignUpForm(); // Create an instance of Form1
            HomepageForm homeForm = new HomepageForm(); // Create an instance of Form2

            // Show Form1
            mainForm.Show();

            Application.Run();
        }
    }
}