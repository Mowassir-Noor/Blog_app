using BlogApp.Data;
using BlogApp.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BlogApp.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly BlogRepository _repository;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RegisteredUsername { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
            _repository = new BlogRepository();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                ShowError("All fields are required");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Passwords do not match");
                return;
            }

            // Check if username already exists
            User existingUser = _repository.GetUserByUsername(txtUsername.Text.Trim());
            if (existingUser != null)
            {
                ShowError("Username already exists");
                return;
            }

            // Create new user
            User newUser = new User
            {
                Username = txtUsername.Text.Trim(),
                PasswordHash = User.HashPassword(txtPassword.Text),
                Email = txtEmail.Text.Trim(),
                DisplayName = txtDisplayName.Text.Trim(),
                IsAdmin = false,
                CreatedDate = DateTime.Now,
                LastLoginDate = DateTime.Now
            };

            _repository.AddUser(newUser);
            
            RegisteredUsername = newUser.Username;
            MessageBox.Show("Registration successful! You can now login.", 
                "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
