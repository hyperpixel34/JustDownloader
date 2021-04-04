using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            startDownload();
        }

        private void startDownload()
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("https://github.com/hyperpixel34/JustDownloader/releases/download/V1.5/justdownloader_v1.5.zip"), @"update.zip");
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)async delegate {
                GitHubClient client = new GitHubClient(new ProductHeaderValue("JustDownloader"));
                IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("hyperpixel34", "JustDownloader");
                label1.Text = "Update wird installiert...";
                string zipPath = @"update.zip";
                string extractPath = @"";
                string directory = "justdownloader_"+ releases[0].TagName.Replace("V","v");
                progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    var result = from currEntry in archive.Entries
                                 where Path.GetDirectoryName(currEntry.FullName) == directory
                                 where !String.IsNullOrEmpty(currEntry.Name)
                                 select currEntry;


                    foreach (ZipArchiveEntry entry in result)
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.Name), true);
                    }
                }
                System.IO.File.Delete("update.zip");
                System.Diagnostics.Process.Start("JustDownloader.exe");
                Environment.Exit(0);
            });
        }
    }
}
