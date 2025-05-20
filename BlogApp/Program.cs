using BlogApp.Forms;
using BlogApp.Models;

namespace BlogApp;

static class Program
{
    // Global current user
    public static User CurrentUser { get; set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        bool continueRunning = true;
        
        while (continueRunning)
        {
            // Show login form first
            LoginForm loginForm = new LoginForm();
            
            // Handle successful login event
            loginForm.LoginSuccessful += (sender, user) =>
            {
                CurrentUser = user;
            };
            
            // Show the login form
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // If login is successful, show the main form
                MainForm mainForm = new MainForm();
                DialogResult result = mainForm.ShowDialog();
                
                // If result is Abort, it means logout was requested
                continueRunning = (result == DialogResult.Abort);
            }
            else
            {
                // If login is cancelled, exit the application
                continueRunning = false;
            }
        }
    }
}