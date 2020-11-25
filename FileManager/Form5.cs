using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace FileManager
{
    public partial class Form5 : Form
    {
        CancellationTokenSource cts;
        CancellationToken token;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //ссылки для отладки:
            //https://zoom.us/client/latest/ZoomInstaller.exe
            //https://discord.com/api/download?platform=win
        }
        private void DownloadFile(String Url, String ResultFileName, CancellationToken token)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(Url);
            HttpWebResponse ws = (HttpWebResponse)wr.GetResponse();
            Stream str = ws.GetResponseStream();

            byte[] inBuf = new byte[1000000000];
            int bytesReadTotal = 0;

            FileStream fstr = new FileStream(ResultFileName, FileMode.Create, FileAccess.Write);

            while (true)
            {
                int n = str.Read(inBuf, 0, 1000000000);
                if ((n == 0) || (n == -1))
                {
                    break;
                }
                if (token.IsCancellationRequested)
                {
                    MessageBox.Show("Загрузка остановлена по требованию!");
                    return;
                }
                fstr.Write(inBuf, 0, n);
                bytesReadTotal += n;
            }
            str.Close();
            fstr.Close();
            MessageBox.Show("Файл успешно загружен!");
        }
        private async void DownloadFileAsync(String Url, String ResultFileName, CancellationToken token)
        {
            await Task.Run(() => DownloadFile(Url, ResultFileName, token));
        }

        private void Download_Click(object sender, EventArgs e)
        {
            if (LinkToFile.Text != "")
            {
                try
                {
                    cts = new CancellationTokenSource();
                    token = cts.Token;
                    if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = saveFileDialog.FileName;
                    DownloadFileAsync(LinkToFile.Text, filename, token);
                }
                catch { };
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
