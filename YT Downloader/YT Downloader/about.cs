using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT_Downloader
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
            label2.Text = "Version: "+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".0.0","");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/NxRbMSdq9v");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/hyperpixel34/");
        }
    }
}
