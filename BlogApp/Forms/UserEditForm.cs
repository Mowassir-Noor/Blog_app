using BlogApp.Data;
using BlogApp.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BlogApp.Forms
{
    public partial class UserEditForm : Form
    {
        private readonly BlogRepository _repository;
        private readonly User _user;
        private readonly bool _isNewUser;

        public UserEditForm(User user = null)
        {
            InitializeComponent();
            _repository = new BlogRepository();
            
            if (user == null)
            {
                _user = new User();
                _isNewUser = true;
                Text = "Add New User";
            }
            else
            {
                _user = user;
                _isNewUser = false;
                Text = "Edit User";
            }
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            // If editing existing user
            if (!_isNewUser)
            {
                txtUsername.Text = _user.Username;
                txtEmail.Text = _user.Email;
                txtDisplayName.Text = _user.DisplayName;
                chkIsAdmin.Checked = _user.IsAdmin;
                
                // Disable username field in edit mode
                txtUsername.Enabled = false;
                
                // In edit mode, password is optional
                lblPassword.Text = "Password (leave blank to keep existing):";
                lblConfirmPassword.Text = "Confirm Password (leave blank to keep existing):";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate form
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            
            if (_isNewUser && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required for new users.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            
            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                MessageBox.Show("Display Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisplayName.Focus();
                return;
            }
            
            // Check if username exists for new users
            if (_isNewUser)
            {
                User existingUser = _repository.GetUserByUsername(txtUsername.Text.Trim());
                if (existingUser != null)
                {
                    MessageBox.Show("This username is already taken. Please choose another one.", "Username Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }
            }
            
            // Update user object
            _user.Username = txtUsername.Text.Trim();
            _user.Email = txtEmail.Text.Trim();
            _user.DisplayName = txtDisplayName.Text.Trim();
            _user.IsAdmin = chkIsAdmin.Checked;
            
            // Update password if provided
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _user.PasswordHash = User.HashPassword(txtPassword.Text);
            }
            
            // Save to database
            if (_isNewUser)
            {
                _repository.AddUser(_user);
            }
            else
            {
                _repository.UpdateUser(_user);
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private bool IsValidEmail(string email)
        {
            // Simple email validation regex
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
