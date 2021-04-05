
namespace YT_Downloader
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.download_progress_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.download = new System.Windows.Forms.Button();
            this.format = new System.Windows.Forms.GroupBox();
            this.YTMusic = new System.Windows.Forms.RadioButton();
            this.audio_cover = new System.Windows.Forms.RadioButton();
            this.video_btn = new System.Windows.Forms.RadioButton();
            this.audio_btn = new System.Windows.Forms.RadioButton();
            this.video_listbox = new System.Windows.Forms.ListBox();
            this.link = new System.Windows.Forms.TextBox();
            this.del_video = new System.Windows.Forms.Button();
            this.add_video = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OGG = new System.Windows.Forms.RadioButton();
            this.AAC = new System.Windows.Forms.RadioButton();
            this.FLAC = new System.Windows.Forms.RadioButton();
            this.WEBM = new System.Windows.Forms.RadioButton();
            this.AIFF = new System.Windows.Forms.RadioButton();
            this.WAV = new System.Windows.Forms.RadioButton();
            this.MP3 = new System.Windows.Forms.RadioButton();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überUnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.format.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.überUnsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.öffnenToolStripMenuItem.Text = "Importieren";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.speichernToolStripMenuItem.Text = "Exportieren";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Textdokumente|*.txt";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Textdokumente|*.txt";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.download_progress_label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // download_progress_label
            // 
            this.download_progress_label.Name = "download_progress_label";
            this.download_progress_label.Size = new System.Drawing.Size(132, 17);
            this.download_progress_label.Text = "Bitte Videos hinzufügen";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 439);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.download);
            this.tabPage1.Controls.Add(this.format);
            this.tabPage1.Controls.Add(this.video_listbox);
            this.tabPage1.Controls.Add(this.link);
            this.tabPage1.Controls.Add(this.del_video);
            this.tabPage1.Controls.Add(this.add_video);
            this.tabPage1.Controls.Add(this.browse);
            this.tabPage1.Controls.Add(this.path);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Download";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(383, 327);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(54, 50);
            this.pictureBox3.TabIndex = 89;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::YT_Downloader.Properties.Resources.empty;
            this.pictureBox2.Location = new System.Drawing.Point(199, 327);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(178, 50);
            this.pictureBox2.TabIndex = 88;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(139, 327);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 50);
            this.pictureBox1.TabIndex = 87;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 383);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(560, 23);
            this.progressBar1.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "Pfad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "URL:";
            // 
            // download
            // 
            this.download.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.download.Location = new System.Drawing.Point(346, 277);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(182, 37);
            this.download.TabIndex = 83;
            this.download.Text = "Download!";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // format
            // 
            this.format.Controls.Add(this.YTMusic);
            this.format.Controls.Add(this.audio_cover);
            this.format.Controls.Add(this.video_btn);
            this.format.Controls.Add(this.audio_btn);
            this.format.Location = new System.Drawing.Point(47, 258);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(238, 67);
            this.format.TabIndex = 82;
            this.format.TabStop = false;
            this.format.Text = "Format";
            // 
            // YTMusic
            // 
            this.YTMusic.AutoSize = true;
            this.YTMusic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.YTMusic.Location = new System.Drawing.Point(136, 40);
            this.YTMusic.Name = "YTMusic";
            this.YTMusic.Size = new System.Drawing.Size(102, 18);
            this.YTMusic.TabIndex = 3;
            this.YTMusic.TabStop = true;
            this.YTMusic.Text = "Youtube Music";
            this.YTMusic.UseVisualStyleBackColor = true;
            // 
            // audio_cover
            // 
            this.audio_cover.AutoSize = true;
            this.audio_cover.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.audio_cover.Location = new System.Drawing.Point(136, 19);
            this.audio_cover.Name = "audio_cover";
            this.audio_cover.Size = new System.Drawing.Size(110, 18);
            this.audio_cover.TabIndex = 2;
            this.audio_cover.Text = "Audio und Cover";
            this.audio_cover.UseVisualStyleBackColor = true;
            // 
            // video_btn
            // 
            this.video_btn.AutoSize = true;
            this.video_btn.Checked = true;
            this.video_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.video_btn.Location = new System.Drawing.Point(6, 19);
            this.video_btn.Name = "video_btn";
            this.video_btn.Size = new System.Drawing.Size(124, 18);
            this.video_btn.TabIndex = 0;
            this.video_btn.TabStop = true;
            this.video_btn.Text = "Video mit Audiospur";
            this.video_btn.UseVisualStyleBackColor = true;
            // 
            // audio_btn
            // 
            this.audio_btn.AutoSize = true;
            this.audio_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.audio_btn.Location = new System.Drawing.Point(6, 42);
            this.audio_btn.Name = "audio_btn";
            this.audio_btn.Size = new System.Drawing.Size(78, 18);
            this.audio_btn.TabIndex = 1;
            this.audio_btn.Text = "Nur Audio";
            this.audio_btn.UseVisualStyleBackColor = true;
            // 
            // video_listbox
            // 
            this.video_listbox.FormattingEnabled = true;
            this.video_listbox.Location = new System.Drawing.Point(8, 79);
            this.video_listbox.Name = "video_listbox";
            this.video_listbox.Size = new System.Drawing.Size(560, 173);
            this.video_listbox.TabIndex = 81;
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(47, 48);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(481, 20);
            this.link.TabIndex = 80;
            // 
            // del_video
            // 
            this.del_video.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.del_video.Location = new System.Drawing.Point(552, 41);
            this.del_video.Name = "del_video";
            this.del_video.Size = new System.Drawing.Size(16, 32);
            this.del_video.TabIndex = 79;
            this.del_video.Text = "-";
            this.del_video.UseVisualStyleBackColor = true;
            this.del_video.Click += new System.EventHandler(this.del_video_Click);
            // 
            // add_video
            // 
            this.add_video.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.add_video.Location = new System.Drawing.Point(536, 41);
            this.add_video.Name = "add_video";
            this.add_video.Size = new System.Drawing.Size(16, 32);
            this.add_video.TabIndex = 78;
            this.add_video.Text = "+";
            this.add_video.UseVisualStyleBackColor = true;
            this.add_video.Click += new System.EventHandler(this.add_video_Click);
            // 
            // browse
            // 
            this.browse.Image = ((System.Drawing.Image)(resources.GetObject("browse.Image")));
            this.browse.Location = new System.Drawing.Point(536, 6);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(32, 32);
            this.browse.TabIndex = 77;
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(47, 13);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(481, 20);
            this.path.TabIndex = 76;
            this.path.Text = "Ausgabeordner";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Optionen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OGG);
            this.groupBox1.Controls.Add(this.AAC);
            this.groupBox1.Controls.Add(this.FLAC);
            this.groupBox1.Controls.Add(this.WEBM);
            this.groupBox1.Controls.Add(this.AIFF);
            this.groupBox1.Controls.Add(this.WAV);
            this.groupBox1.Controls.Add(this.MP3);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audioformat";
            // 
            // OGG
            // 
            this.OGG.AutoSize = true;
            this.OGG.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OGG.Location = new System.Drawing.Point(99, 68);
            this.OGG.Name = "OGG";
            this.OGG.Size = new System.Drawing.Size(55, 18);
            this.OGG.TabIndex = 6;
            this.OGG.Text = "OGG";
            this.OGG.UseVisualStyleBackColor = true;
            this.OGG.CheckedChanged += new System.EventHandler(this.OGG_CheckedChanged);
            // 
            // AAC
            // 
            this.AAC.AutoSize = true;
            this.AAC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AAC.Location = new System.Drawing.Point(7, 92);
            this.AAC.Name = "AAC";
            this.AAC.Size = new System.Drawing.Size(52, 18);
            this.AAC.TabIndex = 5;
            this.AAC.Text = "AAC";
            this.AAC.UseVisualStyleBackColor = true;
            this.AAC.CheckedChanged += new System.EventHandler(this.AAC_CheckedChanged);
            // 
            // FLAC
            // 
            this.FLAC.AutoSize = true;
            this.FLAC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FLAC.Location = new System.Drawing.Point(99, 44);
            this.FLAC.Name = "FLAC";
            this.FLAC.Size = new System.Drawing.Size(57, 18);
            this.FLAC.TabIndex = 4;
            this.FLAC.Text = "FLAC";
            this.FLAC.UseVisualStyleBackColor = true;
            this.FLAC.CheckedChanged += new System.EventHandler(this.FLAC_CheckedChanged);
            // 
            // WEBM
            // 
            this.WEBM.AutoSize = true;
            this.WEBM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WEBM.Location = new System.Drawing.Point(99, 20);
            this.WEBM.Name = "WEBM";
            this.WEBM.Size = new System.Drawing.Size(65, 18);
            this.WEBM.TabIndex = 3;
            this.WEBM.Text = "WEBM";
            this.WEBM.UseVisualStyleBackColor = true;
            this.WEBM.CheckedChanged += new System.EventHandler(this.WEBM_CheckedChanged);
            // 
            // AIFF
            // 
            this.AIFF.AutoSize = true;
            this.AIFF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AIFF.Location = new System.Drawing.Point(7, 68);
            this.AIFF.Name = "AIFF";
            this.AIFF.Size = new System.Drawing.Size(53, 18);
            this.AIFF.TabIndex = 2;
            this.AIFF.Text = "AIFF";
            this.AIFF.UseVisualStyleBackColor = true;
            this.AIFF.CheckedChanged += new System.EventHandler(this.AIFF_CheckedChanged);
            // 
            // WAV
            // 
            this.WAV.AutoSize = true;
            this.WAV.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WAV.Location = new System.Drawing.Point(7, 44);
            this.WAV.Name = "WAV";
            this.WAV.Size = new System.Drawing.Size(56, 18);
            this.WAV.TabIndex = 1;
            this.WAV.Text = "WAV";
            this.WAV.UseVisualStyleBackColor = true;
            this.WAV.CheckedChanged += new System.EventHandler(this.WAV_CheckedChanged);
            // 
            // MP3
            // 
            this.MP3.AutoSize = true;
            this.MP3.Checked = true;
            this.MP3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MP3.Location = new System.Drawing.Point(7, 20);
            this.MP3.Name = "MP3";
            this.MP3.Size = new System.Drawing.Size(53, 18);
            this.MP3.TabIndex = 0;
            this.MP3.TabStop = true;
            this.MP3.Text = "MP3";
            this.MP3.UseVisualStyleBackColor = true;
            this.MP3.CheckedChanged += new System.EventHandler(this.MP3_CheckedChanged);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // überUnsToolStripMenuItem
            // 
            this.überUnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.überUnsToolStripMenuItem.Name = "überUnsToolStripMenuItem";
            this.überUnsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.überUnsToolStripMenuItem.Text = "Über uns";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 492);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JustDownloader";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.format.ResumeLayout(false);
            this.format.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel download_progress_label;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.GroupBox format;
        private System.Windows.Forms.RadioButton YTMusic;
        private System.Windows.Forms.RadioButton audio_cover;
        private System.Windows.Forms.RadioButton video_btn;
        private System.Windows.Forms.RadioButton audio_btn;
        private System.Windows.Forms.ListBox video_listbox;
        private System.Windows.Forms.TextBox link;
        private System.Windows.Forms.Button del_video;
        private System.Windows.Forms.Button add_video;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OGG;
        private System.Windows.Forms.RadioButton AAC;
        private System.Windows.Forms.RadioButton FLAC;
        private System.Windows.Forms.RadioButton WEBM;
        private System.Windows.Forms.RadioButton AIFF;
        private System.Windows.Forms.RadioButton WAV;
        private System.Windows.Forms.RadioButton MP3;
        private System.Windows.Forms.ToolStripMenuItem überUnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

