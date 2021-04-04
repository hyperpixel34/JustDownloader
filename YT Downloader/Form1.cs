using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using TagLib;
using System.Net;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Linq;
using System.Diagnostics;
using Octokit;

namespace YT_Downloader
{
    public partial class Form1 : Form
    {
        private List<string> video_links = new List<string>();
        private List<string> openedFile = new List<string>();
        public string formataudio = "mp3";



        public Form1()
        {
            UpdateChecker();
            InitializeComponent();
            path.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos); // Einsetzen des Pfades zum Video Ordner in die path Listbox
        }


        public static string RemoveIllegalCharacters(String path) // Methode zum löschen von unzulässigen Zeichen im Pfad
        {
            return path.Replace("~", "").Replace("\"", "").Replace("#", "").Replace("%", "").Replace("&", "").Replace("*", "").Replace(":", "").Replace("<", "").Replace(">", "").Replace("?", "").Replace("/", "").Replace("\\", "").Replace("{", "").Replace("}", "").Replace(".", "").Replace("|", "").Replace("'", "");
        }

        // Methode zum ermitteln der Thumbnail URL (https://www.youtube.com/watch?v=WMQAz-6rD5I ==> https://i.ytimg.com/vi/WMQAz-6rD5I/maxresdefault.jpg)
        public static string getYouTubeThumbnail(string YoutubeUrl) 
        {
            if (YoutubeUrl.StartsWith("https://music."))
            {
                YoutubeUrl.Replace("https://music.", "");
            }
            string youTubeThumb = string.Empty;
            if (YoutubeUrl == "")
                return "";

            if (YoutubeUrl.IndexOf("=") > 0)
            {
                youTubeThumb = YoutubeUrl.Split('=')[1];
            }
            else if (YoutubeUrl.IndexOf("/v/") > 0)
            {
                string strVideoCode = YoutubeUrl.Substring(YoutubeUrl.IndexOf("/v/") + 3);
                int ind = strVideoCode.IndexOf("?");
                youTubeThumb = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
            }
            else if (YoutubeUrl.IndexOf('/') < 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[3];
            }
            else if (YoutubeUrl.IndexOf('/') > 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[1];
            }

            return "https://i.ytimg.com/vi/" + youTubeThumb.Replace("&list", "") + "/maxresdefault.jpg";
        }

        public static string getYouTubeThumbnailLowRes(string YoutubeUrl)
        {
            if (YoutubeUrl.StartsWith("https://music."))
            {
                YoutubeUrl.Replace("https://music.", "");
            }
            string youTubeThumb = string.Empty;
            if (YoutubeUrl == "")
                return "";

            if (YoutubeUrl.IndexOf("=") > 0)
            {
                youTubeThumb = YoutubeUrl.Split('=')[1];
            }
            else if (YoutubeUrl.IndexOf("/v/") > 0)
            {
                string strVideoCode = YoutubeUrl.Substring(YoutubeUrl.IndexOf("/v/") + 3);
                int ind = strVideoCode.IndexOf("?");
                youTubeThumb = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
            }
            else if (YoutubeUrl.IndexOf('/') < 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[3];
            }
            else if (YoutubeUrl.IndexOf('/') > 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[1];
            }

            return "https://i.ytimg.com/vi/" + youTubeThumb.Replace("&list", "") + "/hqresdefault.jpg";
        }

        // FolderBrowse Dialog
        private void browse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path.Text = folderBrowserDialog1.SelectedPath;
            // Wenn auf "X" oder "Abbrechen" geclickt wurde
            if (path.Text == "")
            {
                path.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            }
        }

        // Fügt Videos in video_listbox ein
        private async void add_video_Click(object sender, EventArgs e)
        {
            if (link.Text != "") // Bewirkt das Videos nur hinzugefügt werden können wenn die link textbox nicht leer ist
                pictureBox2.Image = Properties.Resources.ping;
                try
                {
                    var youtube = new YoutubeClient();
                    // Ermittelt Videoinformationen wie z.B. Name 
                    var video = await youtube.Videos.GetAsync(link.Text);
                    // Hinzufügen des Videotitels in die Listbox
                    video_listbox.Items.Add(video.Title);
                    // Hinzufügen des Videolinks in eine Liste 
                    video_links.Add(link.Text);
                    // Löschen des Inhalts der Textbox
                    link.Clear();
                }
                catch (ArgumentException)
                {
                    pictureBox2.Image = Properties.Resources.error;
                    MessageBox.Show("Das ist kein YouTube Video", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn der eingegebene Link ungültig ist
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    pictureBox2.Image = Properties.Resources.error;
                    MessageBox.Show("Keine Internetverbindung!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
                }
            pictureBox2.Image = Properties.Resources.empty;
        }

        private void del_video_Click(object sender, EventArgs e) // Löschen eines Eintrages
        {
            try
            {
                video_listbox.Items.RemoveAt(0);
                video_links.RemoveAt(0);
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(); // Startet den Download
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)async delegate
            {
                try
                {
                    add_video.Enabled = false;
                    del_video.Enabled = false;
                    browse.Enabled = false;
                    link.Enabled = false;
                    video_listbox.Enabled = false;
                    video_btn.Enabled = false;
                    audio_btn.Enabled = false;
                    audio_cover.Enabled = false;
                    download.Enabled = false;
                    YTMusic.Enabled = false;

                    MP3.Enabled = false;
                    WAV.Enabled = false;
                    AIFF.Enabled = false;
                    AAC.Enabled = false;
                    WEBM.Enabled = false;
                    FLAC.Enabled = false;
                    OGG.Enabled = false;

                    if (video_btn.Checked)
                    {
                        for (int i = 0; i < video_links.Count; i++)
                        {
                            pictureBox2.Image = Properties.Resources.download;
                            download_progress_label.Text = "Bitte warten...";
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen
                            Debug.WriteLine(video_links[i]);
                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var streamInfo = streamManifest.GetMuxed().WithHighestVideoQuality();
                            var title = video.Title;
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download 
                            download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + video_links.Count + " wird heruntergeladen";
                            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{path.Text}\\" + RemoveIllegalCharacters(title) + "." + streamInfo.Container, progressHandler);
                        }

                    }
                    if (audio_btn.Checked)
                    {
                        for (int i = 0; i < video_links.Count; i++)
                        {
                            pictureBox2.Image = Properties.Resources.download;
                            download_progress_label.Text = "Bitte warten...";
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen
                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var streamInfo = streamManifest.GetAudioOnly().WithHighestBitrate();
                            var title = video.Title;
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download (nur Audiospur)
                            download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + video_links.Count + " wird heruntergeladen";
                            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{path.Text}\\" + RemoveIllegalCharacters(title) + "." + streamInfo.Container, progressHandler);

                            // Konvertiert die Audiospur (in Form einer mp4 Datei) in eine mp3 Datei und löscht anschließend die mp4
                            download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + video_links.Count + " wird konvertiert";
                            var conversion = new NReco.VideoConverter.FFMpegConverter();
                            pictureBox3.Image = extractor.GetIconFromGroup("imageres.dll", 131, 48).ToBitmap();
                            pictureBox1.Image = extractor.GetIconFromGroup("imageres.dll", 23, 48).ToBitmap();
                            await Task.Run(() =>
                            {
                                conversion.ConvertMedia($"{path.Text}\\" + RemoveIllegalCharacters(title) + "." + streamInfo.Container, $"{path.Text}\\" + RemoveIllegalCharacters(title) + $".{formataudio}", formataudio);
                                System.IO.File.Delete($"{path.Text}\\" + RemoveIllegalCharacters(title) + "." + streamInfo.Container);
                            });
                        }
                    }
                    if (audio_cover.Checked)
                    {
                        for (int i = 0; i < video_links.Count; i++)
                        {
                            pictureBox2.Image = Properties.Resources.download;
                            download_progress_label.Text = "Bitte warten...";
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen
                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var streamInfo = streamManifest.GetAudioOnly().WithHighestBitrate();
                            var title = video.Title;
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download (Nur Audiospur)
                            download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + video_links.Count + " wird heruntergeladen";
                            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{path.Text}\\" + RemoveIllegalCharacters(title) + "." + streamInfo.Container, progressHandler);

                            // Konvertiert die Audiospur (in Form einer mp4 Datei) in eine mp3 Datei und löscht anschließend die mp4
                            download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + video_links.Count + " wird konvertiert";
                            pictureBox3.Image = extractor.GetIconFromGroup("imageres.dll", 131, 48).ToBitmap();
                            pictureBox1.Image = extractor.GetIconFromGroup("imageres.dll", 23, 48).ToBitmap();
                            var conversion = new NReco.VideoConverter.FFMpegConverter();

                            using (var client = new WebClient()) // Downloadet das Thumbnail
                            {
                                try
                                {
                                    client.DownloadFile(getYouTubeThumbnail(video_links[i]), $"{path.Text}\\maxresdefault.jpg");
                                }
                                catch
                                {

                                }
                            }

                            await Task.Run(() =>
                            {

                                conversion.ConvertMedia($"{path.Text}\\" + RemoveIllegalCharacters(title) + "." + streamInfo.Container, $"{path.Text}\\" + RemoveIllegalCharacters(title) + $".{formataudio}", formataudio); ; //https://www.youtube.com/watch?v=v8l_A5v8OTE
                                if (System.IO.File.Exists($"{path.Text}\\maxresdefault.jpg") == true)
                                {
                                    TagLib.File trackFile = TagLib.File.Create($"{path.Text}\\" + RemoveIllegalCharacters(title) + $".{formataudio}");
                                    Picture picture = new Picture($"{path.Text}\\maxresdefault.jpg");
                                    picture.Type = PictureType.FrontCover;
                                    picture.MimeType = "image/jpeg";
                                    trackFile.Tag.Pictures = new TagLib.IPicture[1] { picture };
                                    trackFile.Save();
                                    System.IO.File.Delete($"{path.Text}\\maxresdefault.jpg");
                                }
                                System.IO.File.Delete($"{path.Text}\\{RemoveIllegalCharacters(title)}.{streamInfo.Container}");
                            });
                        }
                    }

                    if (YTMusic.Checked)
                    {
                        for (int i = 0; i < video_links.Count; i++)
                        {
                            pictureBox2.Image = Properties.Resources.download;
                            download_progress_label.Text = "Bitte warten...";
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen
                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var streamInfo = streamManifest.GetMuxed().WithHighestVideoQuality();
                            var title = video.Title;
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download
                            download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + video_links.Count + " wird heruntergeladen";
                            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{path.Text}\\{RemoveIllegalCharacters(title)}.{streamInfo.Container}", progressHandler);

                            // Konvertiert die Audiospur (in Form einer mp4 Datei) in eine mp3 Datei und löscht anschließend die mp4
                            download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + video_links.Count + " wird konvertiert";
                            pictureBox3.Image = extractor.GetIconFromGroup("imageres.dll", 131, 48).ToBitmap();
                            pictureBox1.Image = extractor.GetIconFromGroup("imageres.dll", 23, 48).ToBitmap();
                            var conversion = new NReco.VideoConverter.FFMpegConverter();
                            await Task.Run(() =>
                            {
                                conversion.ConvertMedia($"{path.Text}\\{RemoveIllegalCharacters(title)}.{streamInfo.Container}", $"{path.Text}\\{RemoveIllegalCharacters(title)}.{formataudio}", formataudio);

                                using (var engine = new Engine())
                                {
                                    var mp4 = new MediaFile { Filename = $"{path.Text}\\{RemoveIllegalCharacters(title)}.{streamInfo.Container}" };

                                    engine.GetMetadata(mp4);

                                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(2) };
                                    var outputFile = new MediaFile { Filename = string.Format("{0}\\maxresdefault.jpg", path.Text) }; // https://www.youtube.com/watch?v=WMQAz-6rD5I
                                    engine.GetThumbnail(mp4, outputFile, options);
                                }

                                // Cover hinzufügen
                                TagLib.File trackFile = TagLib.File.Create($"{path.Text}\\{RemoveIllegalCharacters(title)}.{formataudio}");
                                Picture picture = new Picture(string.Format("{0}\\maxresdefault.jpg", path.Text));
                                picture.Type = PictureType.FrontCover;
                                picture.MimeType = "image/jpeg";
                                trackFile.Tag.Pictures = new TagLib.IPicture[1] { picture };
                                trackFile.Save();

                                System.IO.File.Delete($"{path.Text}\\maxresdefault.jpg");
                                System.IO.File.Delete($"{path.Text}\\{RemoveIllegalCharacters(title)}.{streamInfo.Container}");
                            });
                        }
                    }

                    download_progress_label.Text = "Bitte Videos Einfügen";
                    // Löscht alle Items aus video_listbox und video_links
                    video_listbox.Items.Clear();
                    video_links.Clear();
                    pictureBox2.Image = Properties.Resources.success;
                    pictureBox1.Image = extractor.GetIconFromGroup("connect.dll", 10201, 48).ToBitmap();
                    pictureBox3.Image = extractor.GetIconFromGroup("imageres.dll", 109, 48).ToBitmap();
                    var result = MessageBox.Show("Das Herunterladen wurde erfolgreich abgeschlossen.\nSoll der Ausgabeordner geöffnet werden?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information); // Zeigt eine Messagebox an
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("explorer.exe", path.Text); // Wenn beim letzten Dialog mit Ja geantwortet wurde, wird der Downloadordner geöffnet
                    }
                    pictureBox2.Image = Properties.Resources.empty;
                    progressBar1.Value = 0;
                    add_video.Enabled = true;
                    del_video.Enabled = true;
                    browse.Enabled = true;
                    link.Enabled = true;
                    video_listbox.Enabled = true;
                    video_btn.Enabled = true;
                    audio_btn.Enabled = true;
                    audio_cover.Enabled = true;
                    download.Enabled = true;
                    YTMusic.Enabled = true;

                    MP3.Enabled = true;
                    WAV.Enabled = true;
                    AIFF.Enabled = true;
                    AAC.Enabled = true;
                    WEBM.Enabled = true;
                    FLAC.Enabled = true;
                    OGG.Enabled = true;
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    MessageBox.Show("Keine Internetverbindung!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
                    download_progress_label.Text = "";
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Zugriff verweigert", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
                    download_progress_label.Text = "";
                }
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about aboutus = new about();
            aboutus.ShowDialog();
        }

        private async void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String file = openFileDialog1.FileName;
            if (file == "")
            {
                return;
            }
            string[] openedFile = System.IO.File.ReadAllLines(file.Replace("\n", null));
            for (int i = 0; i < openedFile.Count(); i++)
            {
                try
                {
                    pictureBox2.Image = Properties.Resources.ping;
                    if (openedFile[i] != "")
                    {
                        download_progress_label.Text = "Video " + (Convert.ToInt32(i) + 1) + " von " + openedFile.Count() + " wird hinzugefügt";
                        var youtube = new YoutubeClient();
                        // Ermittelt Videoinformationen wie z.B. Name 
                        var video = await youtube.Videos.GetAsync(openedFile[i]);
                        // Hinzufügen des Videotitels in die Listbox
                        video_listbox.Items.Add(video.Title);
                        // Hinzufügen des Videolinks in eine Liste 
                        video_links.Add(openedFile[i]);
                        // Löschen des Inhalts der Textbox
                        link.Clear();
                    }
                }
                catch (ArgumentException)
                {
                    pictureBox2.Image = Properties.Resources.error;
                    MessageBox.Show("Das ist kein YouTube Video\n"+openedFile[i], "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn der eingegebene Link ungültig ist
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    pictureBox2.Image = Properties.Resources.error;
                    MessageBox.Show("Keine Internetverbindung!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
                }
                download_progress_label.Text = "Bitte Videos hinzufügen";
                pictureBox2.Image = Properties.Resources.empty;
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string savefilename = saveFileDialog1.FileName;
            System.Diagnostics.Debug.WriteLine(video_links);
            string video_links_formatted = "";

            for (int i = 0; i < video_links.Count(); i++)
            {
                video_links_formatted += video_links[i] + "\n";
                System.Diagnostics.Debug.WriteLine(video_links[i]);
            }
            System.IO.File.WriteAllText(savefilename, video_links_formatted);
        }

        private void MP3_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "mp3";
        }

        private void WAV_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "wav";
        }

        private void AIFF_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "aiff";
        }

        private void AAC_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "aac";
        }

        private void FLAC_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "flac";
        }

        private void OGG_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "ogg";
        }

        private void WEBM_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "webm";
        }

        private async System.Threading.Tasks.Task UpdateChecker()
        {
            Debug.WriteLine("Checke version");
            GitHubClient client = new GitHubClient(new ProductHeaderValue("JustDownloader"));
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("hyperpixel34", "JustDownloader");

            //Setup the versions

            if (releases[0].TagName != "V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".0.0", ""))
            {
                var result = MessageBox.Show("Eine neuere Version \"" + releases[0].TagName + "\" ist verfügbar.\nSoll sie installiert werden? (Empfohlen)", "Update verfügbar!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("Updater.exe");
                    Environment.Exit(0);
                }
            }
        }
    }
}

//https://www.youtube.com/watch?v=WMQAz-6rD5I