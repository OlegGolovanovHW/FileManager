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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace FileManager
{
    public partial class Form4 : Form
    {
        List<Found> found;
        Regex Email = new Regex(@"\b[a-zA-Z0-9._ %+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}\b");
        Regex PhoneNumberRus = new Regex(@"(\d{11}|\d{1}-\d{3}-\d{3}-\d{2}-\d{2})");
        Regex Date = new Regex(@"\d{4}(-|\/)\d{2}\1\d{2}");
        Regex Request;
        private List<string> current_files;
        private Form1 form = new Form1();
        private FileSystemWatcher Watcher = new FileSystemWatcher();
        private string the_name_of_the_current_folder_or_file;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            //загружаем приводы
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo info in drives)
            {
                DisplayMatchesOrCurrentDirectory.Items.Add(info.Name);
            }
            Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            Watcher.Filter = "";
            Watcher.Changed += Watcher_Change;
            Watcher.Created += Watcher_Change;
            Watcher.Deleted += Watcher_Change;
            Watcher.Renamed += Watcher_Change;
            DisplayMatchesOrCurrentDirectory.DoubleClick += new EventHandler(DisplayMatchesOrCurrentDirectory_DoubleClick);
        }
        private void DisplayMatchesOrCurrentDirectory_DoubleClick(object sender, EventArgs e)
        {
            form.DoubleClickHandler(DisplayMatchesOrCurrentDirectory, CurrentPath, the_name_of_the_current_folder_or_file, ref current_files); //обновляем содержимое директории
        }

        private void Watcher_Change(object source, FileSystemEventArgs e)
        {
            DisplayMatchesOrCurrentDirectory.Items.Clear();
            Watcher.Path = CurrentPath.Text;
            Watcher.EnableRaisingEvents = true;
            form.GetAndDisplayDirectory(DisplayMatchesOrCurrentDirectory, CurrentPath, the_name_of_the_current_folder_or_file, ref current_files);
        }

        private void GettingFileNames(string current_path, ref List<string> SearchPaths)
        {
            try
            {
                if (Directory.GetFiles(current_path) != null)
                {
                    string[] files = Directory.GetFiles(current_path);
                    foreach (string file in files)
                    {
                        SearchPaths.Add(file);
                    }
                    
                }
                if (Directory.GetDirectories(current_path) != null)
                {

                    string[] directories = Directory.GetDirectories(current_path);
                    foreach (string directory in directories)
                    {
                        GettingFileNames(directory, ref SearchPaths);
                    }
                }
            }
            catch(System.UnauthorizedAccessException) {};
        }
        private void StartSearch_Click(object sender, EventArgs e)
        {
            List<string> SearchPaths = new List<string>();
            found = new List<Found>();
            if (DisplayMatchesOrCurrentDirectory.SelectedItem != null)
            {
                if (form.IsFile(DisplayMatchesOrCurrentDirectory, CurrentPath, ref current_files) == 1)
                {
                    //если файл, то будем производить поиск в нём
                    SearchPaths.Add(CurrentPath.Text + DisplayMatchesOrCurrentDirectory.SelectedItem.ToString());
                }
                else if (form.IsFile(DisplayMatchesOrCurrentDirectory, CurrentPath, ref current_files) == 0)
                {
                    string current_search_path = CurrentPath.Text + DisplayMatchesOrCurrentDirectory.SelectedItem.ToString();
                    //если папка, то получим всё пути из этой папки, и производим по ним поиск
                    GettingFileNames(current_search_path, ref SearchPaths);
                }
            }
            else
            {
                //поиск будет происходить в текущей папке
                GettingFileNames(CurrentPath.Text, ref SearchPaths);
            }
            string inputed_regex = InputRegex.Text;
            if (inputed_regex != "")
            {
                Request = new Regex(@inputed_regex);
                Parallel.ForEach(SearchPaths, SearchInFileByRegex);
            }
            else
            {
                if (Templates.SelectedNode != null)
                {
                    if (Templates.SelectedNode == Templates.Nodes[0])
                    {
                        Request = Email;
                    }
                    if (Templates.SelectedNode == Templates.Nodes[1])
                    {
                        Request = PhoneNumberRus;
                    }
                    if (Templates.SelectedNode == Templates.Nodes[2])
                    {
                        Request = Date;
                    }
                    //вызовем Parallel.ForEach, в качестве коллекции - список путей до файлов
                    Parallel.ForEach(SearchPaths, SearchInFileByRegex);
                }
            }
            if (found != null)
            {
                DisplayMatchesOrCurrentDirectory.Items.Clear();
                foreach(Found output in found)
                {
                    DisplayMatchesOrCurrentDirectory.Items.Add(output.FileName + ":");
                    string buf = "";
                    int i = 1;
                    foreach(Match m in output.Matches)
                    {
                        DisplayMatchesOrCurrentDirectory.Items.Add("\t" + i.ToString() + ") " + m.Value);
                        i++;
                    }
                    DisplayMatchesOrCurrentDirectory.Items.Add(buf);
                    //DisplayMatchesOrCurrentDirectory.Enabled = false;
                }
            }
        }
        private void SearchInFileByRegex(string FilePath)
        {
            try
            {
                FileInfo file_info = new FileInfo(FilePath);
                long size = file_info.Length;
                if (size <= 50000000) //будем производить поиск в файле весом не более 50 МБ
                using (StreamReader file = File.OpenText(FilePath))
                {
                    string text = file.ReadToEnd();
                    found.Add(new Found(form.ExtractingNameFromObjectPath(FilePath), Request.Matches(text)));
                }
            }
            catch(System.UnauthorizedAccessException) {};
        }

        private void Escape_Click(object sender, EventArgs e)
        {
            form.EscapeHandler(DisplayMatchesOrCurrentDirectory, CurrentPath, the_name_of_the_current_folder_or_file, ref current_files);
            DisplayMatchesOrCurrentDirectory.Enabled = true;
        }
    }
    class Found
    {
        public string FileName;
        public MatchCollection Matches;
        public Found(string file_name, MatchCollection matches)
        {
            FileName = file_name;
            Matches = matches;
        }
    }
}
