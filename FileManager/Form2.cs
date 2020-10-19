using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form2 : Form
    {
        private Form1 form;
        public Form2(Form1 frm1)
        {
            InitializeComponent();
            form = frm1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form2_FormClosing;
            form.FormClosing += Form1_FormClosing;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form.BackColor = colorDialog.Color;

            }
        }

        private void BackgroundPicture_Click(object sender, EventArgs e)
        {
            Bitmap image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(openFileDialog.FileName);
                    form.BackgroundImage = image;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ChangeTheme(Color BackColor, Color ForeColor, Form1 form)
        {
            form.BackColor = BackColor;
            form.CurrentPathLeft.BackColor = BackColor;
            form.CurrentPathLeft.ForeColor = ForeColor;
            form.CurrentPathRight.BackColor = BackColor;
            form.CurrentPathRight.ForeColor = ForeColor;
            form.ListOfItemsLeft.BackColor = BackColor;
            form.ListOfItemsLeft.ForeColor = ForeColor;
            form.ListOfItemsRight.BackColor = BackColor;
            form.ListOfItemsRight.ForeColor = ForeColor;
            form.Copy.BackColor = BackColor;
            form.Copy.ForeColor = ForeColor;
            form.Move.BackColor = BackColor;
            form.Move.ForeColor = ForeColor;
            form.Edit.BackColor = BackColor;
            form.Edit.ForeColor = ForeColor;
            form.Delete.BackColor = BackColor;
            form.Delete.ForeColor = ForeColor;
            form.Archive.BackColor = BackColor;
            form.Archive.ForeColor = ForeColor;
            form.SearchLeft.BackColor = BackColor;
            form.SearchLeft.ForeColor = ForeColor;
            form.SearchRight.BackColor = BackColor;
            form.SearchRight.ForeColor = ForeColor;
            form.StartSearchingLeft.BackColor = BackColor;
            form.StartSearchingLeft.ForeColor = ForeColor;
            form.StartSearchingRight.BackColor = BackColor;
            form.StartSearchingRight.ForeColor = ForeColor;
            form.menuStrip.BackColor = BackColor;
            form.filesToolStripMenuItem.BackColor = BackColor;
            form.filesToolStripMenuItem.ForeColor = ForeColor;
            form.configurationToolStripMenuItem.BackColor = BackColor;
            form.configurationToolStripMenuItem.ForeColor = ForeColor;
            form.infoToolStripMenuInfoFirst.BackColor = BackColor;
            form.infoToolStripMenuInfoFirst.ForeColor = ForeColor;
            form.settingsToolStripMenuItem.BackColor = BackColor;
            form.settingsToolStripMenuItem.ForeColor = ForeColor;
            form.toolStripMenuFileFirst.BackColor = BackColor;
            form.toolStripMenuFileFirst.ForeColor = ForeColor;
            form.toolStripMenuFileSecond.BackColor = BackColor;
            form.toolStripMenuFileSecond.ForeColor = ForeColor;
            form.toolStripMenuConfigurationFirst.BackColor = BackColor;
            form.toolStripMenuConfigurationFirst.ForeColor = ForeColor;
            form.toolStripMenuInfoFirst.BackColor = BackColor;
            form.toolStripMenuInfoFirst.ForeColor = ForeColor;
        }

        private void WhiteTheme_Click(object sender, EventArgs e)
        {
            ChangeTheme(Color.White, Color.Black, form);
            form.theme = "WHITE";
        }

        private void BlackTheme_Click(object sender, EventArgs e)
        {
            ChangeTheme(Color.Black, Color.Green, form);
            form.theme = "BLACK";
        }

        private void ChooseAFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                form.Font = fontDialog.Font;
                form.menuStrip.Font = fontDialog.Font;
            }
        }

        private void ChooseAFormTransparency_Click(object sender, EventArgs e)
        {
            Form3 change_transparency_form = new Form3(form);
            change_transparency_form.Show();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            ChangeTheme(Color.White, Color.Black, form);
            form.theme = "WHITE";
            form.BackgroundImage = null;
            form.Opacity = 1;
            form.Font = form.DefaultFont;
            form.menuStrip.Font = form.DefaultFont; 
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseForm()
        {
            //при закрытии формы с настройками будем производить сериализацию настроек основной формы
            form.userPrefs.theme = form.theme;
            form.userPrefs.backColorForm = form.BackColor;
            form.userPrefs.backgroundImage = form.BackgroundImage;
            form.userPrefs.font = form.Font;
            form.userPrefs.menuStripFont = form.menuStrip.Font;
            form.userPrefs.opacity = form.Opacity;
            Stream fstream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FileManagerSettings.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            form.binFormat.Serialize(fstream, form.userPrefs);
            fstream.Close();
        }

        private void Form2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }
    }
}
