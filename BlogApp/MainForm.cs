using BlogApp.Data;
using BlogApp.Forms;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BlogApp
{
    public partial class MainForm : Form
    {
        private readonly BlogRepository _repository;
        private List<BlogPost> _currentPosts;
        private User _currentUser;

        public MainForm()
        {
            InitializeComponent();
            _repository = new BlogRepository();
            _currentPosts = new List<BlogPost>();
            _currentUser = Program.CurrentUser; // Get the current logged-in user
            
            // Set default dialog result to Cancel
            DialogResult = DialogResult.Cancel;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Update title with user info
            Text = $"Blog Manager - Welcome {_currentUser.DisplayName}";
            
            // Set up menu and status bar
            SetupMenuStrip();
            SetupStatusStrip();
            
            // Load categories for filter
            LoadCategories();
            
            // Load all posts
            LoadPosts();
        }
        
        private void SetupMenuStrip()
        {
            // Update menu visibility based on permissions
            bool isAdmin = _currentUser.IsAdmin;
            manageUsersToolStripMenuItem.Visible = isAdmin;
            
            // Set username in menu
            lblUserDisplay.Text = _currentUser.DisplayName;
        }
        
        private void SetupStatusStrip()
        {
            // Update status bar
            toolStripStatusLabel1.Text = $"Logged in as: {_currentUser.DisplayName}";
        }
        
        private void LoadCategories()
        {
            // Add "All Categories" option
            comboCategories.Items.Add("All Categories");
            
            // Get categories from database
            List<string> categories = _repository.GetAllCategories();
            foreach (string category in categories)
            {
                comboCategories.Items.Add(category);
            }
            
            // Select "All Categories" by default
            comboCategories.SelectedIndex = 0;
        }
        
        private void LoadPosts(string categoryFilter = null)
        {
            // Clear the current list
            listPosts.Items.Clear();
            _currentPosts.Clear();
            
            // Get posts based on filter
            _currentPosts = string.IsNullOrEmpty(categoryFilter) || categoryFilter == "All Categories" 
                ? _repository.GetAllPosts() 
                : _repository.GetPostsByCategory(categoryFilter);
            
            // Add posts to the list view with modern theme
            foreach (BlogPost post in _currentPosts)
            {
                ListViewItem item = new ListViewItem(post.Title);
                item.SubItems.Add(post.Author);
                item.SubItems.Add(post.Category);
                item.SubItems.Add(post.CreatedDate.ToShortDateString());
                item.SubItems.Add(post.IsPublished ? "Yes" : "No");
                item.Tag = post.Id; // Store ID for reference
                
                // Alternate row colors
                item.BackColor = listPosts.Items.Count % 2 == 0 
                    ? Color.White 
                    : Color.FromArgb(245, 245, 245);
                
                listPosts.Items.Add(item);
            }
            
            // Update status
            lblStatus.Text = $"Total Posts: {_currentPosts.Count}";
        }
        
        private void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboCategories.SelectedItem?.ToString();
            LoadPosts(selectedCategory == "All Categories" ? null : selectedCategory);
        }
          private void btnNewPost_Click(object sender, EventArgs e)
        {
            var editForm = new EditPostForm(_currentUser);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Reload data after adding
                string selectedCategory = comboCategories.SelectedItem?.ToString();
                LoadPosts(selectedCategory == "All Categories" ? null : selectedCategory);
                LoadCategories(); // Refresh categories in case a new one was added
            }
        }
        
        private void btnEditPost_Click(object sender, EventArgs e)
        {
            if (listPosts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a post to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int postId = (int)listPosts.SelectedItems[0].Tag;
            BlogPost post = _repository.GetPostById(postId);
            
            // Check if user has permission to edit
            if (post != null && (post.UserId == _currentUser.Id || _currentUser.IsAdmin))
            {
                var editForm = new EditPostForm(_currentUser, post);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload data after editing
                    string selectedCategory = comboCategories.SelectedItem?.ToString();
                    LoadPosts(selectedCategory == "All Categories" ? null : selectedCategory);
                    LoadCategories(); // Refresh categories in case a new one was added
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to edit this post.", 
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            if (listPosts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a post to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int postId = (int)listPosts.SelectedItems[0].Tag;
            BlogPost post = _repository.GetPostById(postId);
            
            // Check if user has permission to delete
            if (post != null && (post.UserId == _currentUser.Id || _currentUser.IsAdmin))
            {
                string postTitle = listPosts.SelectedItems[0].Text;
                
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the post '{postTitle}'?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    _repository.DeletePost(postId);
                    
                    // Reload data after deleting
                    string selectedCategory = comboCategories.SelectedItem?.ToString();
                    LoadPosts(selectedCategory == "All Categories" ? null : selectedCategory);
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to delete this post.", 
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void btnViewPost_Click(object sender, EventArgs e)
        {
            if (listPosts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a post to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int postId = (int)listPosts.SelectedItems[0].Tag;
            BlogPost post = _repository.GetPostById(postId);
            
            if (post != null)
            {
                var viewForm = new ViewPostForm(post);
                viewForm.ShowDialog();
            }
        }
        
        private void listPosts_DoubleClick(object sender, EventArgs e)
        {
            // Handle double-click as view post
            btnViewPost_Click(sender, e);
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Filter the displayed posts based on search text
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                // If search box is empty, show all posts in the current category
                string selectedCategory = comboCategories.SelectedItem?.ToString();
                LoadPosts(selectedCategory == "All Categories" ? null : selectedCategory);
                return;
            }
            
            string searchText = txtSearch.Text.ToLower();
            
            // Get all posts for the current category filter
            string currentCategory = comboCategories.SelectedItem?.ToString();
            List<BlogPost> allPosts = currentCategory == "All Categories" || currentCategory == null
                ? _repository.GetAllPosts()
                : _repository.GetPostsByCategory(currentCategory);
            
            // Filter by search text
            _currentPosts = allPosts.Where(post => 
                post.Title.ToLower().Contains(searchText) || 
                post.Content.ToLower().Contains(searchText) || 
                post.Author.ToLower().Contains(searchText)
            ).ToList();
            
            // Update list view with modern styling
            listPosts.Items.Clear();
            foreach (BlogPost post in _currentPosts)
            {
                ListViewItem item = new ListViewItem(post.Title);
                item.SubItems.Add(post.Author);
                item.SubItems.Add(post.Category);
                item.SubItems.Add(post.CreatedDate.ToShortDateString());
                item.SubItems.Add(post.IsPublished ? "Yes" : "No");
                item.Tag = post.Id;
                
                // Alternate row colors
                item.BackColor = listPosts.Items.Count % 2 == 0 
                    ? Color.White 
                    : Color.FromArgb(245, 245, 245);
                
                listPosts.Items.Add(item);
            }
            
            // Update status
            lblStatus.Text = $"Search Results: {_currentPosts.Count}";
        }
          private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Log out the user
            Program.CurrentUser = null;
            
            // Close the main form which will return to Program.cs
            // and let it handle showing the login form again
            DialogResult = DialogResult.Abort; // Special result to indicate logout
            Close();
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }
        
        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open user management form (admin only)
            if (_currentUser.IsAdmin)
            {
                var userManagementForm = new UserManagementForm();
                userManagementForm.ShowDialog();
            }
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show about dialog
            MessageBox.Show("Blog Application\nVersion 1.0\n\nDeveloped as a Windows Forms sample application.", 
                "About Blog Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
