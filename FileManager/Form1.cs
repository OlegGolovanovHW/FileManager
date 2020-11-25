using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
//using System.IO.Compression.FileSystem;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace FileManager
{
    public partial class Form1 : Form
    {
        FileSystemWatcher WatcherLeft = new FileSystemWatcher();
        FileSystemWatcher WatcherRight = new FileSystemWatcher();
        public List<string> current_files_left; //список всех файлов в текущей директории
        public List<string> current_files_right;
        public List<string> gzipped_files = new List<string>(); //нужно сериализовать
        public string the_name_of_the_current_folder_or_file_left;
        public string the_name_of_the_current_folder_or_file_right;
        public string sourceFileNameToCopy;
        public string sourceFileNameToMove;
        public string sourceFileToCopy;
        public string sourceFileToMove;
        public string sourceFolderNameToCopy;
        public string sourceFolderNameToMove;
        public string sourceFolderToCopy;
        public string sourceFolderToMove;
        public string destFileToCopy;
        public string destFileToMove;
        public string destFolderToMove;
        public string destFolderToCopy;
        public string RenamingObjectDirectory;
        public string theme;
        public bool first_click_on_copy = true;
        public bool second_click_on_copy = false;
        public bool first_click_on_move = true;
        public bool second_click_on_move = false;
        public bool left_panel_was_clicked_last = false;
        public bool right_panel_was_clicked_last = false;
        public bool the_file_is_copying = false;
        public bool the_folder_is_copying = false;
        public bool the_file_is_moving = false;
        public bool the_folder_is_moving = false;
        public int bytesCopied;
        public const int BufferSize = 16384;
        public byte[] buffer = new byte[BufferSize];
        public Font DefaultFont = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
        public FileManagerSettings userPrefs;
        public BinaryFormatter binFormat = new BinaryFormatter();

        [Serializable]
        public class FileManagerSettings
        {
            public Color backColorForm;
            public Image backgroundImage;
            public string theme;
            public Font font;
            public Font menuStripFont;
            public double opacity;
            public FileManagerSettings(Form1 frm1)
            {
                theme = frm1.theme;
                backColorForm = frm1.BackColor;
                backgroundImage = frm1.BackgroundImage;
                font = frm1.Font;
                menuStripFont = frm1.menuStrip.Font;
                opacity = frm1.Opacity;
            }
            public FileManagerSettings()
            {

            }
        }



        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FileManagerSettings.dat"))
            {
                Stream fstream = File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FileManagerSettings.dat");
                userPrefs = (FileManagerSettings)binFormat.Deserialize(fstream);
                fstream.Close();
                //восстанавливаем вид формы
                if (userPrefs.theme == "WHITE")
                {
                    Form2.ChangeTheme(Color.White, Color.Black, this);
                    this.theme = "WHITE";
                }
                else if (userPrefs.theme == "BLACK")
                {
                    Form2.ChangeTheme(Color.Black, Color.Green, this);
                    this.theme = "BLACK";
                }
                this.BackColor = userPrefs.backColorForm;
                this.BackgroundImage = userPrefs.backgroundImage;
                this.Font = userPrefs.font;
                this.menuStrip.Font = userPrefs.menuStripFont;
                this.Opacity = userPrefs.opacity;
            }
            else
            {
                userPrefs = new FileManagerSettings(this);
            }
            //загружаем приводы
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach(DriveInfo info in drives)
            {
                ListOfItemsLeft.Items.Add(info.Name);
                ListOfItemsRight.Items.Add(info.Name);
            }
            WatcherLeft.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            WatcherLeft.Filter = "";
            WatcherLeft.Changed += WatcherLeft_Change;
            WatcherLeft.Created += WatcherLeft_Change;
            WatcherLeft.Deleted += WatcherLeft_Change;
            WatcherLeft.Renamed += WatcherLeft_Change;

            WatcherRight.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            WatcherRight.Filter = "";
            WatcherRight.Changed += WatcherRight_Change;
            WatcherRight.Created += WatcherRight_Change;
            WatcherRight.Deleted += WatcherRight_Change;
            WatcherRight.Renamed += WatcherRight_Change;
            //обработка двойного клика мышью по папке или файлу 
            ListOfItemsLeft.Click += new EventHandler(ListOfItemsLeft_Click);
            ListOfItemsRight.Click += new EventHandler(ListOfItemsRight_Click);
            ListOfItemsLeft.DoubleClick += new EventHandler(ListOfItemsLeft_DoubleClick);
            ListOfItemsRight.DoubleClick += new EventHandler(ListOfItemsRight_DoubleClick);

        }
        private void WatcherLeft_Change(object source, FileSystemEventArgs e)
        {
            ListOfItemsLeft.Items.Clear();
            GetAndDisplayDirectory(ListOfItemsLeft, CurrentPathLeft, the_name_of_the_current_folder_or_file_left, ref current_files_left);
        }
        private void WatcherRight_Change(object source, FileSystemEventArgs e)
        {
            ListOfItemsRight.Items.Clear();
            GetAndDisplayDirectory(ListOfItemsRight, CurrentPathRight, the_name_of_the_current_folder_or_file_right, ref current_files_right);
        } 

        private void ListOfItemsLeft_Click(object sender, EventArgs e)
        {
            if (CurrentPathLeft.Text != "")
            {
                WatcherLeft.Path = CurrentPathLeft.Text;
            }
            ListOfItemsRight.ClearSelected();
            left_panel_was_clicked_last = true;
            right_panel_was_clicked_last = false;
        }

        private void ListOfItemsRight_Click(object sender, EventArgs e)
        {
            if (CurrentPathRight.Text != "")
            {
                WatcherRight.Path = CurrentPathRight.Text;
            }
            ListOfItemsLeft.ClearSelected();
            left_panel_was_clicked_last = false;
            right_panel_was_clicked_last = true;
        }

        private void ListOfItemsLeft_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickHandler(ListOfItemsLeft, CurrentPathLeft, the_name_of_the_current_folder_or_file_left, ref current_files_left); //обновляем содержимое директории
        }

        private void ListOfItemsRight_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickHandler(ListOfItemsRight, CurrentPathRight, the_name_of_the_current_folder_or_file_right, ref current_files_right); //обновляем содержимое директории
        }

        private void EscapeLeft_Click(object sender, EventArgs e)
        {
            EscapeHandler(ListOfItemsLeft, CurrentPathLeft, the_name_of_the_current_folder_or_file_left, ref current_files_left);
        }

        private void EscapeRight_Click(object sender, EventArgs e)
        {
            EscapeHandler(ListOfItemsRight, CurrentPathRight, the_name_of_the_current_folder_or_file_right, ref current_files_right);
        }

        public void EscapeHandler(ListBox ListOfItems, RichTextBox CurrentPath, string the_name_of_the_current_folder_or_file, ref List<string> current_files)
        {
            
            if (CurrentPath.Text.Length > 0)
            {
                int k = CurrentPath.Text.Length - 2;
                int cnt = 0;
                bool isDrive = true;
                while (k > 0)
                {
                    if (CurrentPath.Text[k] == '\\')
                    {
                        isDrive = false;
                        break;
                    }
                    cnt++;
                    k--;
                }
                if (isDrive)
                {
                    CurrentPath.Text = "";
                    ListOfItems.Items.Clear();
                    DriveInfo[] drives = DriveInfo.GetDrives();
                    foreach (DriveInfo info in drives)
                    {
                        ListOfItems.Items.Add(info.Name);
                    }
                }
                else
                {
                    CurrentPath.Text = CurrentPath.Text.Remove(CurrentPath.Text.Length - cnt - 1, cnt + 1);
                    ListOfItems.Items.Clear();
                    GetAndDisplayDirectory(ListOfItems, CurrentPath, the_name_of_the_current_folder_or_file, ref current_files);
                }
            }      
        }

        public void DoubleClickHandler(ListBox ListOfItems, RichTextBox CurrentPath, string the_name_of_the_current_folder_or_file, ref List<string> current_files) //открытие папки
        {
            if (ListOfItems.SelectedItem != null) //если некоторый предмет был выбран  
            {
                the_name_of_the_current_folder_or_file = ListOfItems.SelectedItem.ToString(); //записываем его имя
                if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(0)) //если не файл - открываем папку
                {
                    ListOfItems.Items.Clear();
                    if (the_name_of_the_current_folder_or_file[the_name_of_the_current_folder_or_file.Length - 1] == '\\')
                    {
                        CurrentPath.Text += the_name_of_the_current_folder_or_file;
                    }
                    else
                    {
                        CurrentPath.Text += the_name_of_the_current_folder_or_file + "\\";
                    }
                    //обновляем содержимое директории
                    GetAndDisplayDirectory(ListOfItems, CurrentPath, the_name_of_the_current_folder_or_file, ref current_files);
                }
                else
                {
                    Process.Start(CurrentPath.Text + the_name_of_the_current_folder_or_file); //иначе, если файл, открываем
                }
            }
        }
        
        public int IsFile(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files) //
        {
            if (ListOfItems.SelectedItem != null)
            {
                bool isFile = false;
                if (current_files != null) //является предмет папкой или файлом
                {
                    foreach (string curr_file in current_files)
                    {
                        if (CurrentPath.Text + ListOfItems.SelectedItem.ToString() == curr_file)
                        {
                            isFile = true;
                        }
                    }
                }
                return (isFile ? 1 : 0); 
            }
            else
            {
                return -1; //значит элемент не выбран
            }
        }

        public void GetAndDisplayDirectory(ListBox ListOfItems, RichTextBox CurrentPath, string the_name_of_the_current_folder_or_file, ref List<string> current_files)
        {
            if (ListOfItems == ListOfItemsLeft)
            {
                WatcherLeft.Path = CurrentPathLeft.Text;
                WatcherLeft.EnableRaisingEvents = true;
            }
            else if (ListOfItems == ListOfItemsRight)
            {
                WatcherRight.Path = CurrentPathRight.Text;
                WatcherRight.EnableRaisingEvents = true;
            }

            string[] allfolders = Directory.GetDirectories(CurrentPath.Text); //получаем список всех папок в директории
            foreach (string folder in allfolders) //Добавляем названия всех папок в список, отвечающий за текущюю директорию
            {
                int i = folder.Length - 1;
                string str0 = "";
                while (folder[i] != '\\')
                {
                    str0 += folder[i];
                    i--;
                }
                string fldr = "";
                for (int j = str0.Length - 1; j >= 0; j--)
                {
                    fldr += str0[j];
                }
                ListOfItems.Items.Add(fldr);
            }
            string[] allfiles = Directory.GetFiles(CurrentPath.Text); //получаем список всех файлов в директории
            current_files = new List<string>(allfiles); //сохраняем список файлов из текущей директории
            foreach (string filename in allfiles) //Добавляем названия всех файлов в список, отвечающий за текущюю директорию
            {
                ListOfItems.Items.Add(ExtractingNameFromObjectPath(filename));
            }
        }

        public string ExtractingNameFromObjectPath(string ObjectPath)
        {
            string s0 = "";
            string FileName = "";
            int i = ObjectPath.Length - 1;
            while (ObjectPath[i] != '\\')
            {
                s0 += ObjectPath[i];
                i--;
            }
            for (int j = s0.Length - 1; j >= 0; j--)
            {
                FileName += s0[j];
            }
            return FileName;
        }
        
        private string ExtractingDirectoryFromObjectPath(string ObjectPath)
        {
            return ObjectPath.Substring(0, ObjectPath.Length - ExtractingNameFromObjectPath(ObjectPath).Length);
        }

        private string ExtractingExtensionFromFilePath(string FilePath)
        {
            string s0 = "";
            string extension = "";
            int i = FilePath.Length - 1;
            while (i >= 0 && FilePath[i] != '.')
            {
                s0 += FilePath[i];
                i--;
            }
            s0 += ".";
            for (int j = s0.Length - 1; j >= 0; j--)
            {
                extension += s0[j];
            }
            return extension;
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            CopyOrMoveInterface(Copy, ref first_click_on_copy, ref second_click_on_copy);
        }
        private void CopyOrMoveInterface(Button button, ref bool first_click_on_button, ref bool second_click_on_button)
        {
            if (first_click_on_button && (ListOfItemsLeft.SelectedItem != null || ListOfItemsRight.SelectedItem != null))
            {
                if (button == Copy)
                {
                    button.Text = "Copy [object in buffer]";
                    Move.Enabled = false;
                }
                else if (button == Move)
                {
                    button.Text = "Move [object in buffer]";
                    Copy.Enabled = false;
                }
                if (ListOfItemsLeft.SelectedItem != null)
                {
                    if (IsFile(ListOfItemsLeft, CurrentPathLeft, ref current_files_left).Equals(1)) //если копируем/перемещаем файл
                    {
                        if (button == Copy)
                        {
                            sourceFileNameToCopy = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFileToCopy = CurrentPathLeft.Text + sourceFileNameToCopy;
                            the_file_is_copying = true;
                            the_folder_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFileNameToMove = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFileToMove = CurrentPathLeft.Text + sourceFileNameToMove;
                            the_file_is_moving = true;
                            the_folder_is_moving = false;
                        }
                    }
                    else //если копируем/перемещаем папку
                    {
                        if (button == Copy)
                        {
                            sourceFolderNameToCopy = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFolderToCopy = CurrentPathLeft.Text + sourceFolderNameToCopy;
                            the_folder_is_copying = true;
                            the_file_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFolderNameToMove = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFolderToMove = CurrentPathLeft.Text + sourceFolderNameToMove;
                            the_folder_is_moving = true;
                            the_file_is_moving = false;
                        }
                    }
                }
                else if (ListOfItemsRight.SelectedItem != null)
                {
                    if (IsFile(ListOfItemsRight, CurrentPathRight, ref current_files_right).Equals(1))
                    {
                        if (button == Copy)
                        {
                            sourceFileNameToCopy = ListOfItemsRight.SelectedItem.ToString();
                            sourceFileToCopy = CurrentPathRight.Text + sourceFileNameToCopy;
                            the_file_is_copying = true;
                            the_folder_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFileNameToMove = ListOfItemsRight.SelectedItem.ToString();
                            sourceFileToMove = CurrentPathRight.Text + sourceFileNameToMove;
                            the_file_is_moving = true;
                            the_folder_is_moving = false;
                        }
                    }
                    else
                    {
                        if (button == Copy)
                        {
                            sourceFolderNameToCopy = ListOfItemsRight.SelectedItem.ToString();
                            sourceFolderToCopy = CurrentPathRight.Text + sourceFolderNameToCopy;
                            the_folder_is_copying = true;
                            the_file_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFolderNameToMove = ListOfItemsRight.SelectedItem.ToString();
                            sourceFolderToMove = CurrentPathRight.Text + sourceFolderNameToMove;
                            the_folder_is_moving = true;
                            the_file_is_moving = false;
                        }
                    }
                }
                first_click_on_button = false;
                second_click_on_button = true;
            }
            else if (second_click_on_button)
            {
                if (button == Copy)
                {
                    button.Text = "Copy";
                    Move.Enabled = true;
                }
                else if (button == Move)
                {
                    button.Text = "Move";
                    Copy.Enabled = true;
                }
                if (left_panel_was_clicked_last)
                {
                    SomePanelWasClickedLast(ListOfItemsLeft, CurrentPathLeft, ref current_files_left);
                }
                else if (right_panel_was_clicked_last)
                {
                    SomePanelWasClickedLast(ListOfItemsRight, CurrentPathRight, ref current_files_right);
                }
                first_click_on_button = true;
                second_click_on_button = false;
                the_file_is_copying = false;
                the_file_is_moving = false;
                the_folder_is_copying = false;
                the_folder_is_moving = false;
            }
        }
        private void SomePanelWasClickedLast(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files)
        {
            if (ListOfItems.SelectedItem != null) //если нажали на какой-то элемент панели
            {
                //если нажали на папку, то копируем наш объект в эту папку
                if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(0))
                {
                    if (the_file_is_copying)
                    {
                        destFileToCopy = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFileNameToCopy;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToCopy, destFileToCopy);
                    }
                    else if (the_folder_is_copying)
                    {
                        destFolderToCopy = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFolderNameToCopy;
                        CopyingAFolderToTheSpecifiedDirectory(sourceFolderToCopy, destFolderToCopy);
                    }
                    if (the_file_is_moving)
                    {
                        destFileToMove = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFileNameToMove;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToMove, destFileToMove);
                        File.Delete(sourceFileToMove);
                    }
                    else if (the_folder_is_moving)
                    {
                        destFolderToMove = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFolderNameToMove;
                        CopyingAFileToTheSpecifiedDirectory(sourceFolderToMove, destFolderToMove);
                        Directory.Delete(sourceFolderToMove, true);
                    }
                }
                //если на файл, то копируем объект в текущую директорию
                else
                {
                    if (the_file_is_copying)
                    {
                        destFileToCopy = CurrentPath.Text + sourceFileNameToCopy;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToCopy, destFileToCopy);
                    }
                    else if (the_folder_is_copying)
                    {
                        destFolderToCopy = CurrentPath.Text + sourceFolderNameToCopy;
                        CopyingAFolderToTheSpecifiedDirectory(sourceFolderToCopy, destFolderToCopy);
                    }
                    if (the_file_is_moving)
                    {
                        destFileToMove = CurrentPath.Text + sourceFileNameToMove;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToMove, destFileToMove);
                        File.Delete(sourceFileToMove);
                    }
                    else if (the_folder_is_moving)
                    {
                        destFolderToMove = CurrentPath.Text + sourceFolderNameToMove;
                        CopyingAFolderToTheSpecifiedDirectory(sourceFolderToMove, destFolderToMove);
                        Directory.Delete(sourceFolderToMove, true);
                    }
                }
            }
            else //иначе, если мы кликнули по панели, но не по папке или файлу, просто копируем объект в текущую директорию
            {
                if (the_file_is_copying)
                {
                    destFileToCopy = CurrentPath.Text + sourceFileNameToCopy;
                    CopyingAFileToTheSpecifiedDirectory(sourceFileToCopy, destFileToCopy);
                }
                else if (the_folder_is_copying)
                {
                    destFolderToCopy = CurrentPath.Text + sourceFolderNameToCopy;
                    CopyingAFolderToTheSpecifiedDirectory(sourceFolderToCopy, destFolderToCopy);
                }
                if (the_file_is_moving)
                {
                    destFileToMove = CurrentPath.Text + sourceFileNameToMove;
                    CopyingAFileToTheSpecifiedDirectory(sourceFileToMove, destFileToMove);
                    File.Delete(sourceFileToMove);
                }
                else if (the_folder_is_moving)
                {
                    destFolderToMove = CurrentPath.Text + sourceFolderNameToMove;
                    CopyingAFolderToTheSpecifiedDirectory(sourceFolderToMove, destFolderToMove);
                    Directory.Delete(sourceFolderToMove, true);
                }
            }
        }
        private void CopyingAFileToTheSpecifiedDirectory(string path_to_source_file, string path_to_specific_directory) //копируем файл в заданную директорию
        {
            if (path_to_specific_directory != path_to_source_file) //если будет попытка скопировать файл в ту же директорию, то ничего не произойдёт
            {
                //копируем файл в заданную директорию
                using (FileStream inStream = File.Open(path_to_source_file, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (FileStream outStream = File.Open(path_to_specific_directory, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    do
                    {
                        bytesCopied = inStream.Read(buffer, 0, BufferSize);
                        if (bytesCopied > 0)
                        {
                            outStream.Write(buffer, 0, bytesCopied);
                        }
                    } while (bytesCopied > 0);
                }
            }
        }

        private void CopyingAFolderToTheSpecifiedDirectory(string path_to_source_folder, string path_to_specific_directory) //копируем папку в заданную директорию
        {
            if (path_to_source_folder != path_to_specific_directory)
            {
                Directory.CreateDirectory(path_to_specific_directory);
                string[] allfiles = Directory.GetFiles(path_to_source_folder); //получаем все файлы расположенные в копируемой папке
                foreach(string file in allfiles)
                {
                    CopyingAFileToTheSpecifiedDirectory(file, path_to_specific_directory + "\\" + ExtractingNameFromObjectPath(file));
                }
                string[] allfolders = Directory.GetDirectories(path_to_source_folder); //получаем все папки расположенные в копируемой папке
                foreach(string folder in allfolders)
                {
                    CopyingAFolderToTheSpecifiedDirectory(folder, path_to_specific_directory + "\\" + ExtractingNameFromObjectPath(folder));
                } 
            }
        }


        private void ListOfItemsLeft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Move_Click(object sender, EventArgs e)
        {
            CopyOrMoveInterface(Move, ref first_click_on_move, ref second_click_on_move);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (ListOfItemsLeft.SelectedItem != null)
            {
                DeleteInterface(ListOfItemsLeft, CurrentPathLeft, ref current_files_left);
            }
            else if (ListOfItemsRight.SelectedItem != null)
            {
                DeleteInterface(ListOfItemsRight, CurrentPathRight, ref current_files_right);
            }
        }
        private void DeleteInterface(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files)
        {
            if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(1))
            {
                File.Delete(CurrentPath.Text + ListOfItems.SelectedItem.ToString());
            }
            else if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(0))
            {
                Directory.Delete(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), true);
            }
        }        

        private void Edit_Click(object sender, EventArgs e)
        {
            if (ListOfItemsLeft.SelectedItem != null || ListOfItemsRight.SelectedItem != null)
            {
                BackGroundForRename.Visible = true;
                EnteringNewName.Visible = true;
                Enter.Visible = true;
                Cancel.Visible = true;
                TextOnPanel.Visible = true;
            }
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (EnteringNewName.Text != "")
            {
                BackGroundForRename.Visible = false;
                EnteringNewName.Visible = false;
                Enter.Visible = false;
                Cancel.Visible = false;
                TextOnPanel.Visible = false;
                if (ListOfItemsLeft.SelectedItem != null)
                {
                    RenamingObjectDirectory = CurrentPathLeft.Text + ListOfItemsLeft.SelectedItem.ToString();
                    if (IsFile(ListOfItemsLeft, CurrentPathLeft, ref current_files_left).Equals(0))
                    {
                        Directory.Move(RenamingObjectDirectory, CurrentPathLeft.Text + EnteringNewName.Text);
                    }
                    else if (IsFile(ListOfItemsLeft, CurrentPathLeft, ref current_files_left).Equals(1))
                    {
                        File.Move(RenamingObjectDirectory, CurrentPathLeft.Text + EnteringNewName.Text + ExtractingExtensionFromFilePath(RenamingObjectDirectory));
                    }
                }
                else if (ListOfItemsRight.SelectedItem != null)
                {
                    RenamingObjectDirectory = CurrentPathRight.Text + ListOfItemsRight.SelectedItem.ToString();
                    if (IsFile(ListOfItemsRight, CurrentPathRight, ref current_files_right).Equals(0))
                    {
                        Directory.Move(RenamingObjectDirectory, CurrentPathRight.Text + EnteringNewName.Text);
                    }
                    else if (IsFile(ListOfItemsRight, CurrentPathRight, ref current_files_right).Equals(1))
                    {
                        File.Move(RenamingObjectDirectory, CurrentPathRight.Text + EnteringNewName.Text + ExtractingExtensionFromFilePath(RenamingObjectDirectory));
                    }
                }
                EnteringNewName.Text = "";
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            BackGroundForRename.Visible = false;
            EnteringNewName.Visible = false;
            Enter.Visible = false;
            Cancel.Visible = false;
            TextOnPanel.Visible = false;
            EnteringNewName.Text = "";
        }

        private void Archive_Click(object sender, EventArgs e)
        {
            ArchiveInterface(ListOfItemsLeft, CurrentPathLeft, ref current_files_left, ref gzipped_files);
            ArchiveInterface(ListOfItemsRight, CurrentPathRight, ref current_files_right, ref gzipped_files);
        }
        
        private void ArchiveInterface(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files, ref List<string> gzipped_files) //зачем current_files через ref передавать????
        {
            if (ListOfItems.SelectedItem != null)
            {
                if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(1))
                {
                    if (ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()) == ".zip") //декомпрессия папки 
                    {
                        CompressingOrDecompressingFolder(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length), false);
                    }
                    else if (ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()) == ".gz") //иначе выполняем декомпрессию файла
                    {
                        string original_extension = "";
                        foreach(string gzipped_file in gzipped_files)
                        {
                            if (ExtractingNameFromObjectPath(gzipped_file).Substring(0, ExtractingNameFromObjectPath(gzipped_file).Length - ExtractingExtensionFromFilePath(gzipped_file).Length - 1) == ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length - 1)) //возможно будет баг
                            {
                                original_extension = ExtractingExtensionFromFilePath(gzipped_file);
                                break;
                            }
                        }
                        CompressingOrDecompressingFile(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length) + original_extension, false);
                    }
                    else //иначе выполняем компрессию файла
                    {
                        gzipped_files.Add(CurrentPath.Text + ListOfItems.SelectedItem.ToString());
                        CompressingOrDecompressingFile(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length) + ".gz", true);
                    }                                     
                }
                else //иначе компрессия папки
                {
                    CompressingOrDecompressingFolder(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString() + ".zip", true);
                }
            }                    
        }

        private void CompressingOrDecompressingFile(string sourceFile, string destFile, bool compress)
        {
            using (Stream inFileStream = File.Open(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream outFileStream = File.Open(destFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (GZipStream gzipStream = new GZipStream(compress ? outFileStream : inFileStream, compress ? CompressionMode.Compress : CompressionMode.Decompress))
            {
                Stream inStream = compress ? inFileStream : gzipStream;
                Stream outStream = compress ? gzipStream : outFileStream;
                int bytesRead = 0;
                do
                {
                    bytesRead = inStream.Read(buffer, 0, BufferSize);
                    outStream.Write(buffer, 0, bytesRead);                 
                } while (bytesRead > 0);
                if (compress)
                {
                    MessageBox.Show("Сжатие файла " + sourceFile + " завершено. Исходный размер: " + inFileStream.Length.ToString() + " сжатый размер: " + outFileStream.Length.ToString() + ".");
                }
                else
                {
                    MessageBox.Show("Было произведено восстановление сжатого файла " + sourceFile);
                }
            }
        }

        private void CompressingOrDecompressingFolder(string sourcePath, string destPath, bool compress)
        {
            if (compress)
            {
                ZipFile.CreateFromDirectory(sourcePath, destPath);
            }
            else
            {
                ZipFile.ExtractToDirectory(sourcePath, destPath);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }

        private void SearchForm_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void DownloadFiles_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
