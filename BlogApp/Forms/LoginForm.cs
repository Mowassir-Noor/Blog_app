using BlogApp.Data;
using BlogApp.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlogApp.Forms
{
    public partial class LoginForm : Form
    {
        private readonly BlogRepository _repository;
        
        // Event for when a user successfully logs in
        public event EventHandler<User> LoginSuccessful;

        public LoginForm()
        {
            InitializeComponent();
            _repository = new BlogRepository();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Username and password are required";
                lblError.Visible = true;
                return;
            }

            // Attempt login
            User user = _repository.AuthenticateUser(username, password);

            if (user != null)
            {
                // Trigger the event to notify that login was successful
                LoginSuccessful?.Invoke(this, user);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblError.Text = "Invalid username or password";
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                // Auto-fill username from registration
                txtUsername.Text = registerForm.RegisteredUsername;
                txtPassword.Focus();
            }
        }
    }
}
