using BlogApp.Models;
using System;
using System.Windows.Forms;

namespace BlogApp.Forms
{
    public partial class ViewPostForm : Form
    {
        private readonly BlogPost _post;
        
        public ViewPostForm(BlogPost post)
        {
            InitializeComponent();
            _post = post;
        }
        
        private void ViewPostForm_Load(object sender, EventArgs e)
        {
            // Set the form title
            Text = _post.Title;
            
            // Populate form fields
            lblTitle.Text = _post.Title;
            lblAuthor.Text = _post.Author;
            lblCategory.Text = _post.Category;
            lblCreated.Text = _post.CreatedDate.ToString("yyyy-MM-dd HH:mm");
            lblModified.Text = _post.ModifiedDate.ToString("yyyy-MM-dd HH:mm");
            lblPublished.Text = _post.IsPublished ? "Yes" : "No";
            txtContent.Text = _post.Content;
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
