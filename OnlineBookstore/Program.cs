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

            SignUpForm mainForm = new SignUpForm();
            mainForm.Show();

            Application.Run();
        }
    }
}