namespace FileManager
{
    partial class Form1
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
            this.ListOfItemsLeft = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ListOfItemsRight = new System.Windows.Forms.ListBox();
            this.CurrentPathLeft = new System.Windows.Forms.TextBox();
            this.CurrentPathRight = new System.Windows.Forms.TextBox();
            this.EscapeRight = new System.Windows.Forms.Button();
            this.EscapeLeft = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.Move = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Archive = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.BackGroundForRename = new System.Windows.Forms.Panel();
            this.Cancel = new System.Windows.Forms.Button();
            this.TextOnPanel = new System.Windows.Forms.Label();
            this.EnteringNewName = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.BackGroundForRename.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListOfItemsLeft
            // 
            this.ListOfItemsLeft.FormattingEnabled = true;
            this.ListOfItemsLeft.ItemHeight = 16;
            this.ListOfItemsLeft.Location = new System.Drawing.Point(6, 93);
            this.ListOfItemsLeft.Name = "ListOfItemsLeft";
            this.ListOfItemsLeft.ScrollAlwaysVisible = true;
            this.ListOfItemsLeft.Size = new System.Drawing.Size(712, 612);
            this.ListOfItemsLeft.TabIndex = 0;
            this.ListOfItemsLeft.SelectedIndexChanged += new System.EventHandler(this.ListOfItemsLeft_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 753);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // ListOfItemsRight
            // 
            this.ListOfItemsRight.FormattingEnabled = true;
            this.ListOfItemsRight.ItemHeight = 16;
            this.ListOfItemsRight.Location = new System.Drawing.Point(724, 93);
            this.ListOfItemsRight.Name = "ListOfItemsRight";
            this.ListOfItemsRight.ScrollAlwaysVisible = true;
            this.ListOfItemsRight.Size = new System.Drawing.Size(691, 612);
            this.ListOfItemsRight.TabIndex = 4;
            // 
            // CurrentPathLeft
            // 
            this.CurrentPathLeft.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentPathLeft.Enabled = false;
            this.CurrentPathLeft.Location = new System.Drawing.Point(6, 65);
            this.CurrentPathLeft.Name = "CurrentPathLeft";
            this.CurrentPathLeft.Size = new System.Drawing.Size(689, 22);
            this.CurrentPathLeft.TabIndex = 5;
            // 
            // CurrentPathRight
            // 
            this.CurrentPathRight.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentPathRight.Enabled = false;
            this.CurrentPathRight.Location = new System.Drawing.Point(724, 65);
            this.CurrentPathRight.Name = "CurrentPathRight";
            this.CurrentPathRight.Size = new System.Drawing.Size(668, 22);
            this.CurrentPathRight.TabIndex = 6;
            // 
            // EscapeRight
            // 
            this.EscapeRight.Location = new System.Drawing.Point(1390, 65);
            this.EscapeRight.Name = "EscapeRight";
            this.EscapeRight.Size = new System.Drawing.Size(26, 24);
            this.EscapeRight.TabIndex = 8;
            this.EscapeRight.Text = "↑";
            this.EscapeRight.UseVisualStyleBackColor = true;
            this.EscapeRight.Click += new System.EventHandler(this.EscapeRight_Click);
            // 
            // EscapeLeft
            // 
            this.EscapeLeft.Location = new System.Drawing.Point(694, 65);
            this.EscapeLeft.Name = "EscapeLeft";
            this.EscapeLeft.Size = new System.Drawing.Size(26, 24);
            this.EscapeLeft.TabIndex = 7;
            this.EscapeLeft.Text = "↑";
            this.EscapeLeft.UseVisualStyleBackColor = true;
            this.EscapeLeft.Click += new System.EventHandler(this.EscapeLeft_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(724, 711);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(668, 22);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1390, 711);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "🔍";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 711);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(689, 22);
            this.textBox2.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(694, 711);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "🔍";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(6, 739);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(278, 42);
            this.Copy.TabIndex = 13;
            this.Copy.Text = "Copy";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Move
            // 
            this.Move.Location = new System.Drawing.Point(290, 739);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(278, 42);
            this.Move.TabIndex = 14;
            this.Move.Text = "Move";
            this.Move.UseVisualStyleBackColor = true;
            this.Move.Click += new System.EventHandler(this.Move_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(574, 739);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(278, 42);
            this.Edit.TabIndex = 15;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(858, 739);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(278, 42);
            this.Delete.TabIndex = 16;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Archive
            // 
            this.Archive.Location = new System.Drawing.Point(1142, 739);
            this.Archive.Name = "Archive";
            this.Archive.Size = new System.Drawing.Size(278, 42);
            this.Archive.TabIndex = 17;
            this.Archive.Text = "Archive";
            this.Archive.UseVisualStyleBackColor = true;
            this.Archive.Click += new System.EventHandler(this.Archive_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1418, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem3.Text = "2";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem4.Text = "1";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem5.Text = "1";
            // 
            // BackGroundForRename
            // 
            this.BackGroundForRename.Controls.Add(this.Cancel);
            this.BackGroundForRename.Controls.Add(this.TextOnPanel);
            this.BackGroundForRename.Controls.Add(this.EnteringNewName);
            this.BackGroundForRename.Controls.Add(this.Enter);
            this.BackGroundForRename.Location = new System.Drawing.Point(799, 409);
            this.BackGroundForRename.Name = "BackGroundForRename";
            this.BackGroundForRename.Size = new System.Drawing.Size(383, 99);
            this.BackGroundForRename.TabIndex = 19;
            this.BackGroundForRename.Visible = false;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(294, 53);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 34);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Visible = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // TextOnPanel
            // 
            this.TextOnPanel.AutoSize = true;
            this.TextOnPanel.Location = new System.Drawing.Point(11, 21);
            this.TextOnPanel.Name = "TextOnPanel";
            this.TextOnPanel.Size = new System.Drawing.Size(241, 17);
            this.TextOnPanel.TabIndex = 2;
            this.TextOnPanel.Text = "Enter a new name of selected object:";
            this.TextOnPanel.Visible = false;
            // 
            // EnteringNewName
            // 
            this.EnteringNewName.Location = new System.Drawing.Point(14, 64);
            this.EnteringNewName.Name = "EnteringNewName";
            this.EnteringNewName.Size = new System.Drawing.Size(273, 22);
            this.EnteringNewName.TabIndex = 1;
            this.EnteringNewName.Visible = false;
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(294, 12);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(74, 34);
            this.Enter.TabIndex = 0;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Visible = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1418, 781);
            this.Controls.Add(this.BackGroundForRename);
            this.Controls.Add(this.Archive);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EscapeRight);
            this.Controls.Add(this.EscapeLeft);
            this.Controls.Add(this.CurrentPathRight);
            this.Controls.Add(this.CurrentPathLeft);
            this.Controls.Add(this.ListOfItemsRight);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ListOfItemsLeft);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BackGroundForRename.ResumeLayout(false);
            this.BackGroundForRename.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfItemsLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox ListOfItemsRight;
        private System.Windows.Forms.TextBox CurrentPathLeft;
        private System.Windows.Forms.TextBox CurrentPathRight;
        private System.Windows.Forms.Button EscapeLeft;
        private System.Windows.Forms.Button EscapeRight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button Move;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Archive;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.Panel BackGroundForRename;
        private System.Windows.Forms.Label TextOnPanel;
        private System.Windows.Forms.TextBox EnteringNewName;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Button Cancel;
    }
}

