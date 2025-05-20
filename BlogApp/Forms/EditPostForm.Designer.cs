namespace BlogApp.Forms
{
    partial class EditPostForm
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            txtContent = new TextBox();
            label3 = new Label();
            txtAuthor = new TextBox();
            label4 = new Label();
            comboCategories = new ComboBox();
            lblNewCategory = new Label();
            txtNewCategory = new TextBox();
            chkPublished = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Location = new Point(80, 12);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(565, 27);
            txtTitle.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 92);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 2;
            label2.Text = "Content:";
            // 
            // txtContent
            // 
            txtContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtContent.Location = new Point(80, 89);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(565, 289);
            txtContent.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 49);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 4;
            label3.Text = "Author:";
            // 
            // txtAuthor
            // 
            txtAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAuthor.Location = new Point(80, 46);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(565, 27);
            txtAuthor.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 396);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 6;
            label4.Text = "Category:";
            // 
            // comboCategories
            // 
            comboCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategories.FormattingEnabled = true;
            comboCategories.Location = new Point(90, 393);
            comboCategories.Name = "comboCategories";
            comboCategories.Size = new Size(235, 28);
            comboCategories.TabIndex = 4;
            comboCategories.SelectedIndexChanged += comboCategories_SelectedIndexChanged;
            // 
            // lblNewCategory
            // 
            lblNewCategory.AutoSize = true;
            lblNewCategory.Location = new Point(331, 396);
            lblNewCategory.Name = "lblNewCategory";
            lblNewCategory.Size = new Size(42, 20);
            lblNewCategory.TabIndex = 8;
            lblNewCategory.Text = "New:";
            lblNewCategory.Visible = false;
            // 
            // txtNewCategory
            // 
            txtNewCategory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNewCategory.Location = new Point(379, 393);
            txtNewCategory.Name = "txtNewCategory";
            txtNewCategory.Size = new Size(266, 27);
            txtNewCategory.TabIndex = 5;
            txtNewCategory.Visible = false;
            // 
            // chkPublished
            // 
            chkPublished.AutoSize = true;
            chkPublished.Location = new Point(90, 436);
            chkPublished.Name = "chkPublished";
            chkPublished.Size = new Size(95, 24);
            chkPublished.TabIndex = 6;
            chkPublished.Text = "Published";
            chkPublished.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(451, 475);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(551, 475);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditPostForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(657, 516);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkPublished);
            Controls.Add(txtNewCategory);
            Controls.Add(lblNewCategory);
            Controls.Add(comboCategories);
            Controls.Add(label4);
            Controls.Add(txtAuthor);
            Controls.Add(label3);
            Controls.Add(txtContent);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            MinimumSize = new Size(675, 563);
            Name = "EditPostForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Blog Post";
            Load += EditPostForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtContent;
        private Label label3;
        private TextBox txtAuthor;
        private Label label4;
        private ComboBox comboCategories;
        private Label lblNewCategory;
        private TextBox txtNewCategory;
        private CheckBox chkPublished;
        private Button btnSave;
        private Button btnCancel;
    }
}
