
namespace FileManager
{
    partial class Form4
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Email");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Телефонный номер РФ");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Дата");
            this.DisplayMatchesOrCurrentDirectory = new System.Windows.Forms.ListBox();
            this.InputRegex = new System.Windows.Forms.RichTextBox();
            this.Templates = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartSearch = new System.Windows.Forms.Button();
            this.CurrentPath = new System.Windows.Forms.RichTextBox();
            this.Escape = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DisplayMatchesOrCurrentDirectory
            // 
            this.DisplayMatchesOrCurrentDirectory.FormattingEnabled = true;
            this.DisplayMatchesOrCurrentDirectory.Location = new System.Drawing.Point(12, 110);
            this.DisplayMatchesOrCurrentDirectory.Name = "DisplayMatchesOrCurrentDirectory";
            this.DisplayMatchesOrCurrentDirectory.Size = new System.Drawing.Size(478, 303);
            this.DisplayMatchesOrCurrentDirectory.TabIndex = 0;
            // 
            // InputRegex
            // 
            this.InputRegex.Location = new System.Drawing.Point(12, 27);
            this.InputRegex.Name = "InputRegex";
            this.InputRegex.Size = new System.Drawing.Size(235, 24);
            this.InputRegex.TabIndex = 1;
            this.InputRegex.Text = "";
            // 
            // Templates
            // 
            this.Templates.Indent = 10;
            this.Templates.Location = new System.Drawing.Point(255, 27);
            this.Templates.Name = "Templates";
            treeNode7.BackColor = System.Drawing.Color.White;
            treeNode7.ForeColor = System.Drawing.Color.Black;
            treeNode7.Name = "email";
            treeNode7.Text = "Email";
            treeNode8.BackColor = System.Drawing.Color.White;
            treeNode8.ForeColor = System.Drawing.Color.Black;
            treeNode8.Name = "PhoneNumberRus";
            treeNode8.Text = "Телефонный номер РФ";
            treeNode9.BackColor = System.Drawing.Color.White;
            treeNode9.ForeColor = System.Drawing.Color.Black;
            treeNode9.Name = "Date";
            treeNode9.Text = "Дата";
            this.Templates.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.Templates.Size = new System.Drawing.Size(235, 24);
            this.Templates.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите регулярное выражение(без \" \" и @):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Или выберите готовый шаблон:";
            // 
            // StartSearch
            // 
            this.StartSearch.BackColor = System.Drawing.Color.White;
            this.StartSearch.ForeColor = System.Drawing.Color.Black;
            this.StartSearch.Location = new System.Drawing.Point(12, 57);
            this.StartSearch.Name = "StartSearch";
            this.StartSearch.Size = new System.Drawing.Size(478, 23);
            this.StartSearch.TabIndex = 5;
            this.StartSearch.Text = "StartSearch";
            this.StartSearch.UseVisualStyleBackColor = false;
            this.StartSearch.Click += new System.EventHandler(this.StartSearch_Click);
            // 
            // CurrentPath
            // 
            this.CurrentPath.BackColor = System.Drawing.Color.White;
            this.CurrentPath.Enabled = false;
            this.CurrentPath.Location = new System.Drawing.Point(12, 84);
            this.CurrentPath.Name = "CurrentPath";
            this.CurrentPath.Size = new System.Drawing.Size(461, 20);
            this.CurrentPath.TabIndex = 6;
            this.CurrentPath.Text = "";
            // 
            // Escape
            // 
            this.Escape.Location = new System.Drawing.Point(470, 84);
            this.Escape.Name = "Escape";
            this.Escape.Size = new System.Drawing.Size(20, 20);
            this.Escape.TabIndex = 7;
            this.Escape.Text = "↑";
            this.Escape.UseVisualStyleBackColor = true;
            this.Escape.Click += new System.EventHandler(this.Escape_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 425);
            this.Controls.Add(this.Escape);
            this.Controls.Add(this.CurrentPath);
            this.Controls.Add(this.StartSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Templates);
            this.Controls.Add(this.InputRegex);
            this.Controls.Add(this.DisplayMatchesOrCurrentDirectory);
            this.Name = "Form4";
            this.Text = "SearchInFilesOrDirectoryByRegex";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox InputRegex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartSearch;
        private System.Windows.Forms.RichTextBox CurrentPath;
        public System.Windows.Forms.ListBox DisplayMatchesOrCurrentDirectory;
        public System.Windows.Forms.TreeView Templates;
        private System.Windows.Forms.Button Escape;
    }
}