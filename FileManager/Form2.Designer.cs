namespace FileManager
{
    partial class Form2
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.theme = new System.Windows.Forms.Label();
            this.BackgroundPicture = new System.Windows.Forms.Button();
            this.WhiteTheme = new System.Windows.Forms.Button();
            this.font = new System.Windows.Forms.Label();
            this.ResetSettings = new System.Windows.Forms.Label();
            this.ChooseAFont = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.BackgroundColor = new System.Windows.Forms.Button();
            this.BlackTheme = new System.Windows.Forms.Button();
            this.background = new System.Windows.Forms.Label();
            this.ChooseAFormTransparency = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.theme, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BackgroundPicture, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.WhiteTheme, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.font, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ResetSettings, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ChooseAFont, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Reset, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BackgroundColor, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BlackTheme, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.background, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChooseAFormTransparency, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.OK, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(425, 185);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // theme
            // 
            this.theme.AutoSize = true;
            this.theme.Location = new System.Drawing.Point(3, 46);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(40, 13);
            this.theme.TabIndex = 1;
            this.theme.Text = "Theme";
            // 
            // BackgroundPicture
            // 
            this.BackgroundPicture.Location = new System.Drawing.Point(144, 3);
            this.BackgroundPicture.Name = "BackgroundPicture";
            this.BackgroundPicture.Size = new System.Drawing.Size(135, 40);
            this.BackgroundPicture.TabIndex = 2;
            this.BackgroundPicture.Text = "Background Picture";
            this.BackgroundPicture.UseVisualStyleBackColor = true;
            this.BackgroundPicture.Click += new System.EventHandler(this.BackgroundPicture_Click);
            // 
            // WhiteTheme
            // 
            this.WhiteTheme.Location = new System.Drawing.Point(144, 49);
            this.WhiteTheme.Name = "WhiteTheme";
            this.WhiteTheme.Size = new System.Drawing.Size(135, 40);
            this.WhiteTheme.TabIndex = 3;
            this.WhiteTheme.Text = "White Theme";
            this.WhiteTheme.UseVisualStyleBackColor = true;
            this.WhiteTheme.Click += new System.EventHandler(this.WhiteTheme_Click);
            // 
            // font
            // 
            this.font.AutoSize = true;
            this.font.Location = new System.Drawing.Point(3, 92);
            this.font.Name = "font";
            this.font.Size = new System.Drawing.Size(98, 13);
            this.font.TabIndex = 4;
            this.font.Text = "Font/Transparency";
            // 
            // ResetSettings
            // 
            this.ResetSettings.AutoSize = true;
            this.ResetSettings.Location = new System.Drawing.Point(3, 138);
            this.ResetSettings.Name = "ResetSettings";
            this.ResetSettings.Size = new System.Drawing.Size(76, 13);
            this.ResetSettings.TabIndex = 5;
            this.ResetSettings.Text = "Reset Settings";
            // 
            // ChooseAFont
            // 
            this.ChooseAFont.Location = new System.Drawing.Point(144, 95);
            this.ChooseAFont.Name = "ChooseAFont";
            this.ChooseAFont.Size = new System.Drawing.Size(135, 40);
            this.ChooseAFont.TabIndex = 6;
            this.ChooseAFont.Text = "Choose a Font";
            this.ChooseAFont.UseVisualStyleBackColor = true;
            this.ChooseAFont.Click += new System.EventHandler(this.ChooseAFont_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(144, 141);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(135, 41);
            this.Reset.TabIndex = 7;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.Location = new System.Drawing.Point(285, 3);
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.Size = new System.Drawing.Size(137, 40);
            this.BackgroundColor.TabIndex = 8;
            this.BackgroundColor.Text = "Background Color";
            this.BackgroundColor.UseVisualStyleBackColor = true;
            this.BackgroundColor.Click += new System.EventHandler(this.BackgroundColor_Click);
            // 
            // BlackTheme
            // 
            this.BlackTheme.Location = new System.Drawing.Point(285, 49);
            this.BlackTheme.Name = "BlackTheme";
            this.BlackTheme.Size = new System.Drawing.Size(137, 40);
            this.BlackTheme.TabIndex = 9;
            this.BlackTheme.Text = "Black Theme";
            this.BlackTheme.UseVisualStyleBackColor = true;
            this.BlackTheme.Click += new System.EventHandler(this.BlackTheme_Click);
            // 
            // background
            // 
            this.background.AutoSize = true;
            this.background.Location = new System.Drawing.Point(3, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(65, 13);
            this.background.TabIndex = 0;
            this.background.Text = "Background";
            // 
            // ChooseAFormTransparency
            // 
            this.ChooseAFormTransparency.Location = new System.Drawing.Point(285, 95);
            this.ChooseAFormTransparency.Name = "ChooseAFormTransparency";
            this.ChooseAFormTransparency.Size = new System.Drawing.Size(137, 40);
            this.ChooseAFormTransparency.TabIndex = 10;
            this.ChooseAFormTransparency.Text = "Choose a Form Transparency";
            this.ChooseAFormTransparency.UseVisualStyleBackColor = true;
            this.ChooseAFormTransparency.Click += new System.EventHandler(this.ChooseAFormTransparency_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(285, 141);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(137, 41);
            this.OK.TabIndex = 11;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 206);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form2";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label background;
        private System.Windows.Forms.Label theme;
        private System.Windows.Forms.Button BackgroundPicture;
        private System.Windows.Forms.Button WhiteTheme;
        private System.Windows.Forms.Label font;
        private System.Windows.Forms.Label ResetSettings;
        private System.Windows.Forms.Button ChooseAFont;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button BackgroundColor;
        private System.Windows.Forms.Button BlackTheme;
        private System.Windows.Forms.Button ChooseAFormTransparency;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.FontDialog fontDialog;
    }
}