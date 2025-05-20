namespace BlogApp.Forms
{
    partial class ViewPostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            panel1 = new Panel();
            lblPublished = new Label();
            label7 = new Label();
            lblModified = new Label();
            label5 = new Label();
            lblCreated = new Label();
            label3 = new Label();
            lblCategory = new Label();
            label6 = new Label();
            lblAuthor = new Label();
            label1 = new Label();
            txtContent = new TextBox();
            btnClose = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(5);
            lblTitle.Size = new Size(682, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Post Title";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblPublished);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lblModified);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblCreated);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblCategory);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lblAuthor);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(682, 83);
            panel1.TabIndex = 1;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPublished.Location = new Point(487, 46);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(30, 20);
            lblPublished.TabIndex = 9;
            lblPublished.Text = "Yes";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(409, 46);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 8;
            label7.Text = "Published:";
            // 
            // lblModified
            // 
            lblModified.AutoSize = true;
            lblModified.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblModified.Location = new Point(487, 17);
            lblModified.Name = "lblModified";
            lblModified.Size = new Size(84, 20);
            lblModified.TabIndex = 7;
            lblModified.Text = "2023-01-02";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(409, 17);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 6;
            label5.Text = "Modified:";
            // 
            // lblCreated
            // 
            lblCreated.AutoSize = true;
            lblCreated.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCreated.Location = new Point(274, 17);
            lblCreated.Name = "lblCreated";
            lblCreated.Size = new Size(84, 20);
            lblCreated.TabIndex = 5;
            lblCreated.Text = "2023-01-01";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(211, 17);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 4;
            label3.Text = "Created:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategory.Location = new Point(78, 46);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(82, 20);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Technology";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(6, 46);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 2;
            label6.Text = "Category:";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblAuthor.Location = new Point(78, 17);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(76, 20);
            lblAuthor.TabIndex = 1;
            lblAuthor.Text = "John Doe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 17);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Author:";
            // 
            // txtContent
            // 
            txtContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtContent.Location = new Point(12, 145);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(658, 325);
            txtContent.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(576, 495);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ViewPostForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 536);
            Controls.Add(btnClose);
            Controls.Add(txtContent);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            MinimumSize = new Size(700, 583);
            Name = "ViewPostForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View Post";
            Load += ViewPostForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel panel1;
        private TextBox txtContent;
        private Button btnClose;
        private Label lblAuthor;
        private Label label1;
        private Label lblCategory;
        private Label label6;
        private Label lblCreated;
        private Label label3;
        private Label lblModified;
        private Label label5;
        private Label lblPublished;
        private Label label7;
    }
}
