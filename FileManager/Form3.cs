using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form3 : Form
    {
        private Form1 form;
        public Form3(Form1 frm1)
        {
            InitializeComponent();
            form = frm1;
            trackBar.Value = Int32.Parse((form.Opacity * 100).ToString());
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            form.Opacity = trackBar.Value * 0.01;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
