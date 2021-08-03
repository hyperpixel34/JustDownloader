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
using System.Globalization;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;
using System.IO;

namespace YT_Downloader
{
    public partial class Form1 : Form
    {
        private List<string> video_links = new List<string>();
        public string formataudio = "mp3";
        public string formatvideo = "mp4";
        public string videoQuality = "720p";
        public string[] langpack;


        public Form1()
        {
            UpdaterAsync();
            InitializeComponent();
            path.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos); // Einsetzen des Pfades zum Video Ordner in die path Listbox
            pictureBox1.Image = extractor.GetIconFromGroup("connect.dll", 10201, 48).ToBitmap();
            pictureBox3.Image = extractor.GetIconFromGroup("imageres.dll", 109, 48).ToBitmap();

            if (CultureInfo.CurrentCulture.ToString().Substring(0, 2) == "de")
            {
                langpack = new string[] { "Das ist kein YouTube Video", "Fehler", "Keine Internetverbindung!", "Zugriff verweigert", "Bitte warten...", "Video ", " von ", " wird heruntergeladen", " wird konvertiert", "Das Herunterladen wurde erfolgreich abgeschlossen.\nSoll der Ausgabeordner geöffnet werden?", " wird hinzugefügt", "Ein Update ist verfügbar.\nSoll es heruntergeladen werden?", "Update verfügbar", "Bitte Videos hinzufügen", "Über uns", "Datei", "Importieren", "Exportieren", "Video mit Audiospur", "Nur Audio", "Audio mit Cover", "YouTube Music", "Pfad: ", "Audioformat", "Videoformat", "Download", "Optionen", "Format", "Qualität", "Untertitel", "Untertitel herunterladen" };
            }
            else
            {
                langpack = new string[] { "This is not a YouTube video", "Error", "No internet connection!", "Access denied", "Please wait...", "Video ", " from ", " being downloaded", " being converted", "Download completed successfully.\nShould the output folder be opened? ", " is added", "An update is available.\nShould it be downloaded?", "Update available", "Please add some videos", "About Us", "File", "Import", "Export", "Video with audio track", "Audio only", "Audio with cover", "YouTube Music", "Path: ", "Audio format", "Video format", "Download", "Options", "Format", "Quality", "Subtitles", "Download Subtitles" };
            }

            foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                comboBox1.Items.Add(c.DisplayName);
            }

            download_progress_label.Text = langpack[13];
            überUnsToolStripMenuItem.Text = langpack[14];
            dateiToolStripMenuItem.Text = langpack[15];
            öffnenToolStripMenuItem.Text = langpack[16];
            speichernToolStripMenuItem.Text = langpack[17];
            video_btn.Text = langpack[18];
            audio_btn.Text = langpack[19];
            audio_cover.Text = langpack[20];
            YTMusic.Text = langpack[21];
            label2.Text = langpack[22];
            groupBox1.Text = langpack[23];
            groupBox2.Text = langpack[24];
            tabPage1.Text = langpack[25];
            tabPage2.Text = langpack[26];
            format.Text = langpack[27];
            quality.Text = langpack[28];
            subtitles.Text = langpack[29];
            dl_sub.Text = langpack[30];
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
                video_links.Add(video.Url);
                // Löschen des Inhalts der Textbox
                link.Clear();
            }
            catch (ArgumentException)
            {
                try
                {
                    var youtube = new YoutubeClient();
                    var playlist = await youtube.Playlists.GetVideosAsync(link.Text).CollectAsync();

                    foreach (var video in playlist)
                    {
                        video_listbox.Items.Add(video.Title);
                        // Hinzufügen des Videolinks in eine Liste 
                        video_links.Add(video.Url);
                        // Löschen des Inhalts der Textbox
                        link.Clear();
                    }
                }

                catch (System.Reflection.TargetInvocationException)
                {
                    pictureBox2.Image = Properties.Resources.error;
                    MessageBox.Show(langpack[0], langpack[1], MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn der eingegebene Link ungültig ist
                }

                catch (System.Net.Http.HttpRequestException)
                {
                    pictureBox2.Image = Properties.Resources.error;
                    MessageBox.Show(langpack[2], langpack[1], MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
                }
            }
            catch (System.Net.Http.HttpRequestException)
            {
                pictureBox2.Image = Properties.Resources.error;
                MessageBox.Show(langpack[2], langpack[1], MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
            }
            pictureBox2.Image = Properties.Resources.empty;
        }

        private void del_video_Click(object sender, EventArgs e) // Löschen eines Eintrages
        {
            int index = video_listbox.SelectedIndex;

            if (index < 0)
            {
                return;
            }
            
            video_listbox.Items.RemoveAt(video_listbox.SelectedIndex);
            video_links.RemoveAt(index);
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
                    WEBM.Enabled = false;
                    FLAC.Enabled = false;
                    OGG.Enabled = false;

                    MP4.Enabled = false;
                    FLV.Enabled = false;
                    AVI.Enabled = false;
                    MOV.Enabled = false;
                    WEBM_VIDEO.Enabled = false;
                    MPEG.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                    radioButton5.Enabled = false;
                    radioButton6.Enabled = false;
                    radioButton7.Enabled = false;

                    if (video_btn.Checked)
                    {
                        for (int i = 0; i < video_links.Count; i++)
                        {
                            pictureBox2.Image = Properties.Resources.download;
                            download_progress_label.Text = langpack[4];
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen

                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var audioInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                            IVideoStreamInfo streamInfo;

                            try
                            {
                                streamInfo = streamManifest.GetVideoStreams().First(s => s.VideoQuality.Label == videoQuality);
                            }
                            catch
                            {
                                streamInfo = streamManifest.GetVideoStreams().GetWithHighestVideoQuality();
                            }

                            var title = video.Title;
                            var streamInfos = new IStreamInfo[] { audioInfo, streamInfo };
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download 
                            download_progress_label.Text = langpack[5] + (Convert.ToInt32(i) + 1) + langpack[6] + video_links.Count + langpack[7];

                            string videoPath;

                            if (videoQuality == "2160p")
                            {
                                await youtube.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder($"{path.Text}\\" + RemoveIllegalCharacters(title) + $".webm").Build(), progressHandler);
                                videoPath = $"{path.Text}\\" + RemoveIllegalCharacters(title) + $".webm";
                            }
                            else
                            {
                                await youtube.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder($"{path.Text}\\" + RemoveIllegalCharacters(title) + $".{formatvideo}").Build(), progressHandler);
                                videoPath = $"{path.Text}\\" + RemoveIllegalCharacters(title) + $".{formatvideo}";
                            }

                            if (dl_sub.Checked)
                            {
                                var srt = await youtube.Videos.ClosedCaptions.GetManifestAsync(video_links[i]);
                                string langCode = CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(c => c.DisplayName == comboBox1.Text).Name;

                                var info = srt.TryGetByLanguage(langCode);

                                if (info != null)
                                {                                    
                                    await youtube.Videos.ClosedCaptions.DownloadAsync(info, "cc.srt");
                                    //Clipboard.SetText($"\"{Directory.GetCurrentDirectory()}\\ffmpeg.exe\" -y -i \"{videoPath}\" -filter:v subtitles=\"{"cc.srt"}\" \"{$"{path.Text}\\" + RemoveIllegalCharacters(title) + $"_srt.{formatvideo}"}\"");
                                    ProcessStartInfo cmdi = new ProcessStartInfo($"{Directory.GetCurrentDirectory()}\\ffmpeg.exe");
                                    cmdi.CreateNoWindow = true;
                                    cmdi.WindowStyle = ProcessWindowStyle.Hidden;
                                    cmdi.Arguments = $"-y -i \"{videoPath}\" -filter:v subtitles=\"{"cc.srt"}\" \"{$"{path.Text}\\" + RemoveIllegalCharacters(title) + $"_srt.{formatvideo}"}\"";
                                    await Task.Run(() =>
                                    {
                                        Process cmd = Process.Start(cmdi);
                                        cmd.WaitForExit();
                                    });
                                    System.IO.File.Delete(videoPath);
                                    //System.IO.File.Delete("cc.srt");
                                }
                            }

                            // https://www.youtube.com/watch?v=xk0Cbdvq-oc
                            // https://www.youtube.com/watch?v=5tK_3s-74r4
                            // https://www.youtube.com/watch?v=DNYwaCL8krE
                        }
                    }

                    if (audio_btn.Checked)
                    {
                        for (int i = 0; i < video_links.Count; i++)
                        {
                            pictureBox2.Image = Properties.Resources.download;
                            download_progress_label.Text = langpack[4];
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen
                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                            var streamInfos = new IStreamInfo[] { streamInfo };

                            var title = video.Title;
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download (nur Audiospur)
                            download_progress_label.Text = langpack[5] + (Convert.ToInt32(i) + 1) + langpack[6] + video_links.Count + langpack[7];
                            MessageBox.Show(formataudio);
                            await youtube.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder($"{path.Text}\\" + RemoveIllegalCharacters(title) + $".{formataudio}").Build(), progressHandler);

                            // Konvertiert die Audiospur (in Form einer mp4 Datei) in eine mp3 Datei und löscht anschließend die mp4
                            download_progress_label.Text = langpack[5] + (Convert.ToInt32(i) + 1) + langpack[6] + video_links.Count + langpack[8];
                        }
                    }

                    if (audio_cover.Checked)
                    {
                        for (int i = 0; i < video_links.Count; i++)
                        {
                            pictureBox2.Image = Properties.Resources.download;
                            download_progress_label.Text = langpack[4];
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen
                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                            var streamInfos = new IStreamInfo[] { streamInfo };

                            var title = video.Title;
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download (Nur Audiospur)
                            download_progress_label.Text = langpack[5] + (Convert.ToInt32(i) + 1) + langpack[6] + video_links.Count + langpack[7];
                            await youtube.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder($"{path.Text}\\" + RemoveIllegalCharacters(title) + $".{formataudio}").Build(), progressHandler);

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
                                if (System.IO.File.Exists($"{path.Text}\\maxresdefault.jpg") == true)
                                {
                                    TagLib.Id3v2.Tag.DefaultVersion = 3;
                                    TagLib.Id3v2.Tag.ForceDefaultVersion = true;
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
                            download_progress_label.Text = langpack[4];
                            var youtube = new YoutubeClient();

                            // Ermittelt Videoinformationen
                            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video_links[i]);
                            var video = await youtube.Videos.GetAsync(video_links[i]);
                            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                            var title = video.Title;
                            var progressHandler = new Progress<double>(p => progressBar1.Value = (int)(p * 100));

                            // Startet den Download
                            download_progress_label.Text = langpack[5] + (Convert.ToInt32(i) + 1) + langpack[6] + video_links.Count + langpack[7];
                            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{path.Text}\\{RemoveIllegalCharacters(title)}.{streamInfo.Container}", progressHandler);

                            // Konvertiert die Audiospur (in Form einer mp4 Datei) in eine mp3 Datei und löscht anschließend die mp4
                            download_progress_label.Text = langpack[5] + (Convert.ToInt32(i) + 1) + langpack[6] + video_links.Count + langpack[8];
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

                                // Cover und Infos hinzufügen
                                TagLib.Id3v2.Tag.DefaultVersion = 3;
                                TagLib.Id3v2.Tag.ForceDefaultVersion = true;
                                TagLib.File trackFile = TagLib.File.Create($"{path.Text}\\{RemoveIllegalCharacters(title)}.{formataudio}");
                                Picture picture = new Picture(string.Format("{0}\\maxresdefault.jpg", path.Text));
                                string[] desc = video.Description.Split('\n');
                                picture.Type = PictureType.FrontCover;
                                picture.MimeType = "image/jpeg";
                                trackFile.Tag.Title = video.Title;
                                try
                                {
                                    trackFile.Tag.Album = desc[4];
                                }
                                catch
                                {

                                }
                                trackFile.Tag.Artists = new string[1] { video.Author.ToString().Replace(" - Topic","") }; 
                                trackFile.Tag.Performers = new string[1] { video.Author.ToString().Replace(" - Topic", "") };
                                
                                uint year;
                                for (int a = 0; a<desc.Length; a++)
                                {

                                    if (desc[a].Contains("℗"))
                                    {
                                        try
                                        {
                                            year = (uint)Convert.ToInt32(desc[a].Substring(2, 4));
                                            trackFile.Tag.Year = year;
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else if (desc[a].Contains("Released on:"))
                                    {
                                        year = (uint)Convert.ToInt32(desc[a].Substring(13, 4));
                                        trackFile.Tag.Year = year;
                                    }
                                    
                                }
                                trackFile.Tag.Pictures = new TagLib.IPicture[1] { picture };
                                trackFile.Save();

                                System.IO.File.Delete($"{path.Text}\\maxresdefault.jpg");
                                System.IO.File.Delete($"{path.Text}\\{RemoveIllegalCharacters(title)}.{streamInfo.Container}");
                            });
                        }
                    }

                    download_progress_label.Text = langpack[13];
                    // Löscht alle Items aus video_listbox und video_links
                    video_listbox.Items.Clear();
                    video_links.Clear();
                    pictureBox2.Image = Properties.Resources.success;
                    pictureBox1.Image = extractor.GetIconFromGroup("connect.dll", 10201, 48).ToBitmap();
                    pictureBox3.Image = extractor.GetIconFromGroup("imageres.dll", 109, 48).ToBitmap();
                    var result = MessageBox.Show(langpack[9], "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information); // Zeigt eine Messagebox an
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
                    WEBM.Enabled = true;
                    FLAC.Enabled = true;
                    OGG.Enabled = true;

                    MP4.Enabled = true;
                    FLV.Enabled = true;
                    AVI.Enabled = true;
                    MOV.Enabled = true;
                    WEBM.Enabled = true;
                    MPEG.Enabled = true;
                    WEBM_VIDEO.Enabled = true;

                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton6.Enabled = true;
                    radioButton7.Enabled = true;
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    MessageBox.Show(langpack[2], langpack[1], MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
                    download_progress_label.Text = "";
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(langpack[3], langpack[1], MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
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
                        download_progress_label.Text = langpack[5] + (Convert.ToInt32(i) + 1) + langpack[6] + openedFile.Count() + langpack[10];
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
                    MessageBox.Show("Das ist kein YouTube Video\n"+openedFile[i], langpack[1], MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn der eingegebene Link ungültig ist
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    pictureBox2.Image = Properties.Resources.error;
                    MessageBox.Show(langpack[2], langpack[1], MessageBoxButtons.OK, MessageBoxIcon.Error); // Messagebox die sich öffnet wenn keine Internetverbindung verfügbar ist
                }
                download_progress_label.Text = langpack[13];
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

        #region Dateiformat
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

        #endregion
        private async Task UpdaterAsync() // Auto Update funktion
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("SomeName"));
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("hyperpixel34", "JustDownloader");

            if ("V"+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".0.0", "") != releases[0].TagName)
            {
                var result = MessageBox.Show(langpack[11],langpack[12], MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("Updater.exe");
                    Environment.Exit(0);
                }
            }
        }

        private void MP4_CheckedChanged(object sender, EventArgs e)
        {
            formatvideo = "mp4";
        }

        private void AVI_CheckedChanged(object sender, EventArgs e)
        {
            formatvideo = "avi";
        }

        private void WEBM_VIDEO_CheckedChanged(object sender, EventArgs e)
        {
            formatvideo = "webm";
        }

        private void FLV_CheckedChanged(object sender, EventArgs e)
        {
            formatvideo = "flv";
        }

        private void MOV_CheckedChanged(object sender, EventArgs e)
        {
            formatvideo = "mov";
        }

        private void MPEG_CheckedChanged(object sender, EventArgs e)
        {
            formatvideo = "mpeg";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "144p";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "240p";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "360p";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "720p";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "1080p";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "1440p";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "2160p";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            videoQuality = "4320p";
        }

        private void m4a_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "m4a";
        }

        private void wma_CheckedChanged(object sender, EventArgs e)
        {
            formataudio = "wma";
        }

        private void dl_sub_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = dl_sub.Checked;
        }
    }
}

//https://www.youtube.com/watch?v=WMQAz-6rD5I