using BlogApp.Data;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BlogApp.Forms
{
    public partial class EditPostForm : Form
    {
        private readonly BlogRepository _repository;
        private readonly BlogPost _post;
        private bool _isNewPost;
        private readonly User _currentUser;

        public EditPostForm(User currentUser, BlogPost post = null)
        {
            InitializeComponent();
            _repository = new BlogRepository();
            _currentUser = currentUser;
            
            if (post == null)
            {
                _post = new BlogPost();
                _post.UserId = _currentUser.Id; // Set the user ID for the new post
                _post.Author = _currentUser.DisplayName; // Use the current user's display name
                _isNewPost = true;
                Text = "New Blog Post";
            }
            else
            {
                _post = post;
                _isNewPost = false;
                Text = "Edit Blog Post";
            }
        }

        private void EditPostForm_Load(object sender, EventArgs e)
        {
            // Load categories for combobox
            LoadCategories();
            
            // Set author field to current user's display name and disable it
            if (_isNewPost)
            {
                txtAuthor.Text = _currentUser.DisplayName;
            }
            
            // For security, only allow admins to change the author
            txtAuthor.Enabled = _currentUser.IsAdmin;
            
            // If editing, populate the form fields
            if (!_isNewPost)
            {
                txtTitle.Text = _post.Title;
                txtContent.Text = _post.Content;
                txtAuthor.Text = _post.Author;
                
                // Select category if it exists in the combobox
                if (!string.IsNullOrEmpty(_post.Category))
                {
                    int index = comboCategories.FindStringExact(_post.Category);
                    if (index != -1)
                    {
                        comboCategories.SelectedIndex = index;
                    }
                }
                
                chkPublished.Checked = _post.IsPublished;
            }
        }
        
        private void LoadCategories()
        {
            // Add text box option for new category
            comboCategories.Items.Add("-- New Category --");
            
            // Get existing categories from database
            List<string> categories = _repository.GetAllCategories();
            foreach (string category in categories)
            {
                comboCategories.Items.Add(category);
            }
            
            // Select the first item
            comboCategories.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate form
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Content is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContent.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Author is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return;
            }
            
            string category = string.Empty;
            
            // Check if a new category was entered
            if (comboCategories.SelectedIndex == 0 && !string.IsNullOrWhiteSpace(txtNewCategory.Text))
            {
                category = txtNewCategory.Text.Trim();
            }
            else if (comboCategories.SelectedIndex > 0)
            {
                category = comboCategories.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select or enter a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboCategories.Focus();
                return;
            }
            
            // Update post object
            _post.Title = txtTitle.Text.Trim();
            _post.Content = txtContent.Text.Trim();
            _post.Author = txtAuthor.Text.Trim();
            _post.Category = category;
            _post.IsPublished = chkPublished.Checked;
            _post.ModifiedDate = DateTime.Now;
            
            // Always ensure the post is associated with the current user
            if (_post.UserId == null)
            {
                _post.UserId = _currentUser.Id;
            }
            
            // Save to database
            if (_isNewPost)
            {
                _repository.AddPost(_post);
            }
            else
            {
                _repository.UpdatePost(_post);
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show/hide new category textbox
            bool showNewCategory = comboCategories.SelectedIndex == 0;
            lblNewCategory.Visible = showNewCategory;
            txtNewCategory.Visible = showNewCategory;
        }
    }
}
