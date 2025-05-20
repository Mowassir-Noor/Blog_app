using BlogApp.Data;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlogApp.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly BlogRepository _repository;
        private List<User> _users;
        
        public UserManagementForm()
        {
            InitializeComponent();
            _repository = new BlogRepository();
        }
        
        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            // Set form title
            Text = "User Management";
            
            // Load users
            LoadUsers();
        }
        
        private void LoadUsers()
        {
            // Clear existing items
            lvUsers.Items.Clear();
            _users = _repository.GetAllUsers();
            
            // Set up list view columns if they don't exist
            if (lvUsers.Columns.Count == 0)
            {
                lvUsers.Columns.Add("Username", 120);
                lvUsers.Columns.Add("Display Name", 150);
                lvUsers.Columns.Add("Email", 200);
                lvUsers.Columns.Add("Admin", 60);
                lvUsers.Columns.Add("Created Date", 120);
                lvUsers.Columns.Add("Last Login", 120);
            }
            
            // Add users to the list view with modern styling
            foreach (User user in _users)
            {
                ListViewItem item = new ListViewItem(user.Username);
                item.SubItems.Add(user.DisplayName);
                item.SubItems.Add(user.Email);
                item.SubItems.Add(user.IsAdmin ? "Yes" : "No");
                item.SubItems.Add(user.CreatedDate.ToShortDateString());
                item.SubItems.Add(user.LastLoginDate > DateTime.MinValue ? user.LastLoginDate.ToShortDateString() : "Never");
                item.Tag = user.Id; // Store ID for reference
                
                // Alternate row colors for better readability
                item.BackColor = lvUsers.Items.Count % 2 == 0 
                    ? Color.White 
                    : Color.FromArgb(245, 245, 245);
                
                lvUsers.Items.Add(item);
            }
            
            // Update status
            lblStatus.Text = $"Total Users: {_users.Count}";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserEditForm editForm = new UserEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Reload users
                LoadUsers();
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int userId = (int)lvUsers.SelectedItems[0].Tag;
            User user = _users.Find(u => u.Id == userId);
            
            if (user != null)
            {
                UserEditForm editForm = new UserEditForm(user);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload users
                    LoadUsers();
                }
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int userId = (int)lvUsers.SelectedItems[0].Tag;
            User user = _users.Find(u => u.Id == userId);
            
            // Check if trying to delete the current admin user
            if (user != null && user.Username == "admin")
            {
                MessageBox.Show("The default admin user cannot be deleted.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (user != null)
            {
                string username = lvUsers.SelectedItems[0].Text;
                
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the user '{username}'?\n\nNote: Any posts by this user will remain but will no longer be associated with a user account.", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    _repository.DeleteUser(userId);
                    LoadUsers();
                }
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
