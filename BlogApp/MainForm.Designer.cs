namespace BlogApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblStatus = new Label();
            btnViewPost = new Button();
            btnDeletePost = new Button();
            btnEditPost = new Button();
            btnNewPost = new Button();
            panel2 = new Panel();
            label2 = new Label();
            comboCategories = new ComboBox();
            txtSearch = new TextBox();
            label1 = new Label();
            listPosts = new ListView();
            columnTitle = new ColumnHeader();
            columnAuthor = new ColumnHeader();
            columnCategory = new ColumnHeader();
            columnDate = new ColumnHeader();
            columnPublished = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            adminToolStripMenuItem = new ToolStripMenuItem();
            manageUsersToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            userMenuItem = new ToolStripMenuItem();
            lblUserDisplay = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(btnViewPost);
            panel1.Controls.Add(btnDeletePost);
            panel1.Controls.Add(btnEditPost);
            panel1.Controls.Add(btnNewPost);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 496);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 65);
            panel1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 24);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Ready";
            // 
            // btnViewPost
            // 
            btnViewPost.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewPost.BackColor = Color.FromArgb(0, 122, 204);
            btnViewPost.FlatAppearance.BorderSize = 0;
            btnViewPost.FlatStyle = FlatStyle.Flat;
            btnViewPost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewPost.ForeColor = Color.White;
            btnViewPost.Location = new Point(861, 16);
            btnViewPost.Name = "btnViewPost";
            btnViewPost.Size = new Size(111, 36);
            btnViewPost.TabIndex = 3;
            btnViewPost.Text = "View";
            btnViewPost.UseVisualStyleBackColor = false;
            btnViewPost.Click += btnViewPost_Click;
            // 
            // btnDeletePost
            // 
            btnDeletePost.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeletePost.BackColor = Color.FromArgb(220, 53, 69);
            btnDeletePost.FlatAppearance.BorderSize = 0;
            btnDeletePost.FlatStyle = FlatStyle.Flat;
            btnDeletePost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeletePost.ForeColor = Color.White;
            btnDeletePost.Location = new Point(744, 16);
            btnDeletePost.Name = "btnDeletePost";
            btnDeletePost.Size = new Size(111, 36);
            btnDeletePost.TabIndex = 2;
            btnDeletePost.Text = "Delete";
            btnDeletePost.UseVisualStyleBackColor = false;
            btnDeletePost.Click += btnDeletePost_Click;
            // 
            // btnEditPost
            // 
            btnEditPost.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditPost.BackColor = Color.FromArgb(255, 193, 7);
            btnEditPost.FlatAppearance.BorderSize = 0;
            btnEditPost.FlatStyle = FlatStyle.Flat;
            btnEditPost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditPost.ForeColor = Color.Black;
            btnEditPost.Location = new Point(627, 16);
            btnEditPost.Name = "btnEditPost";
            btnEditPost.Size = new Size(111, 36);
            btnEditPost.TabIndex = 1;
            btnEditPost.Text = "Edit";
            btnEditPost.UseVisualStyleBackColor = false;
            btnEditPost.Click += btnEditPost_Click;
            // 
            // btnNewPost
            // 
            btnNewPost.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNewPost.BackColor = Color.FromArgb(40, 167, 69);
            btnNewPost.FlatAppearance.BorderSize = 0;
            btnNewPost.FlatStyle = FlatStyle.Flat;
            btnNewPost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnNewPost.ForeColor = Color.White;
            btnNewPost.Location = new Point(510, 16);
            btnNewPost.Name = "btnNewPost";
            btnNewPost.Size = new Size(111, 36);
            btnNewPost.TabIndex = 0;
            btnNewPost.Text = "New Post";
            btnNewPost.UseVisualStyleBackColor = false;
            btnNewPost.Click += btnNewPost_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(comboCategories);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(984, 65);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(500, 22);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "Category:";
            // 
            // comboCategories
            // 
            comboCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategories.FlatStyle = FlatStyle.Flat;
            comboCategories.FormattingEnabled = true;
            comboCategories.Location = new Point(585, 19);
            comboCategories.Name = "comboCategories";
            comboCategories.Size = new Size(387, 28);
            comboCategories.TabIndex = 2;
            comboCategories.SelectedIndexChanged += comboCategories_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(77, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(397, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Search:";
            // 
            // listPosts
            // 
            listPosts.BorderStyle = BorderStyle.None;
            listPosts.Columns.AddRange(new ColumnHeader[] { columnTitle, columnAuthor, columnCategory, columnDate, columnPublished });
            listPosts.Dock = DockStyle.Fill;
            listPosts.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listPosts.FullRowSelect = true;
            listPosts.GridLines = false;
            listPosts.Location = new Point(0, 93);
            listPosts.MultiSelect = false;
            listPosts.Name = "listPosts";
            listPosts.Size = new Size(984, 403);
            listPosts.TabIndex = 2;
            listPosts.UseCompatibleStateImageBehavior = false;
            listPosts.View = View.Details;
            listPosts.DoubleClick += listPosts_DoubleClick;
            // 
            // columnTitle
            // 
            columnTitle.Text = "Title";
            columnTitle.Width = 400;
            // 
            // columnAuthor
            // 
            columnAuthor.Text = "Author";
            columnAuthor.Width = 150;
            // 
            // columnCategory
            // 
            columnCategory.Text = "Category";
            columnCategory.Width = 150;
            // 
            // columnDate
            // 
            columnDate.Text = "Date";
            columnDate.Width = 100;
            // 
            // columnPublished
            // 
            columnPublished.Text = "Published";
            columnPublished.Width = 100;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, adminToolStripMenuItem, helpToolStripMenuItem, userMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logoutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(139, 26);
            logoutToolStripMenuItem.Text = "&Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(139, 26);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manageUsersToolStripMenuItem });
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(67, 24);
            adminToolStripMenuItem.Text = "&Admin";
            // 
            // manageUsersToolStripMenuItem
            // 
            manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            manageUsersToolStripMenuItem.Size = new Size(187, 26);
            manageUsersToolStripMenuItem.Text = "&Manage Users";
            manageUsersToolStripMenuItem.Click += manageUsersToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(142, 26);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // userMenuItem
            // 
            userMenuItem.Alignment = ToolStripItemAlignment.Right;
            userMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lblUserDisplay });
            userMenuItem.Name = "userMenuItem";
            userMenuItem.Size = new Size(52, 24);
            userMenuItem.Text = "User";
            // 
            // lblUserDisplay
            // 
            lblUserDisplay.Enabled = false;
            lblUserDisplay.Name = "lblUserDisplay";
            lblUserDisplay.Size = new Size(143, 26);
            lblUserDisplay.Text = "Username";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 539);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(984, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(49, 17);
            toolStripStatusLabel1.Text = "Ready";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 561);
            Controls.Add(listPosts);
            Controls.Add(statusStrip1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1000, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog Manager";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private TextBox txtSearch;
        private ComboBox comboCategories;
        private Label label2;
        private Button btnNewPost;
        private Button btnViewPost;
        private Button btnDeletePost;
        private Button btnEditPost;
        private ListView listPosts;
        private ColumnHeader columnTitle;
        private ColumnHeader columnAuthor;
        private ColumnHeader columnCategory;
        private ColumnHeader columnDate;
        private ColumnHeader columnPublished;
        private Label lblStatus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem manageUsersToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem userMenuItem;
        private ToolStripMenuItem lblUserDisplay;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
