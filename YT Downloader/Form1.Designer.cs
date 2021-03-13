
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
            this.path = new System.Windows.Forms.TextBox();
            this.add_video = new System.Windows.Forms.Button();
            this.del_video = new System.Windows.Forms.Button();
            this.link = new System.Windows.Forms.TextBox();
            this.video_listbox = new System.Windows.Forms.ListBox();
            this.video_btn = new System.Windows.Forms.RadioButton();
            this.audio_btn = new System.Windows.Forms.RadioButton();
            this.audio_cover = new System.Windows.Forms.RadioButton();
            this.format = new System.Windows.Forms.GroupBox();
            this.YTMusic = new System.Windows.Forms.RadioButton();
            this.download = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überUnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.download_progress_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.format.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(51, 31);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(481, 20);
            this.path.TabIndex = 0;
            this.path.Text = "Ausgabeordner";
            // 
            // add_video
            // 
            this.add_video.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.add_video.Location = new System.Drawing.Point(540, 59);
            this.add_video.Name = "add_video";
            this.add_video.Size = new System.Drawing.Size(16, 32);
            this.add_video.TabIndex = 2;
            this.add_video.Text = "+";
            this.add_video.UseVisualStyleBackColor = true;
            this.add_video.Click += new System.EventHandler(this.add_video_Click);
            // 
            // del_video
            // 
            this.del_video.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.del_video.Location = new System.Drawing.Point(556, 59);
            this.del_video.Name = "del_video";
            this.del_video.Size = new System.Drawing.Size(16, 32);
            this.del_video.TabIndex = 3;
            this.del_video.Text = "-";
            this.del_video.UseVisualStyleBackColor = true;
            this.del_video.Click += new System.EventHandler(this.del_video_Click);
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(51, 66);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(481, 20);
            this.link.TabIndex = 4;
            // 
            // video_listbox
            // 
            this.video_listbox.FormattingEnabled = true;
            this.video_listbox.Location = new System.Drawing.Point(12, 97);
            this.video_listbox.Name = "video_listbox";
            this.video_listbox.Size = new System.Drawing.Size(560, 173);
            this.video_listbox.TabIndex = 5;
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
            // format
            // 
            this.format.Controls.Add(this.YTMusic);
            this.format.Controls.Add(this.audio_cover);
            this.format.Controls.Add(this.video_btn);
            this.format.Controls.Add(this.audio_btn);
            this.format.Location = new System.Drawing.Point(51, 276);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(238, 67);
            this.format.TabIndex = 7;
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
            // download
            // 
            this.download.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.download.Location = new System.Drawing.Point(350, 295);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(182, 37);
            this.download.TabIndex = 9;
            this.download.Text = "Download!";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // browse
            // 
            this.browse.Image = ((System.Drawing.Image)(resources.GetObject("browse.Image")));
            this.browse.Location = new System.Drawing.Point(540, 24);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(32, 32);
            this.browse.TabIndex = 1;
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Pfad:";
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
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.öffnenToolStripMenuItem.Text = "Importieren";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.speichernToolStripMenuItem.Text = "Exportieren";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // überUnsToolStripMenuItem
            // 
            this.überUnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.überUnsToolStripMenuItem.Name = "überUnsToolStripMenuItem";
            this.überUnsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.überUnsToolStripMenuItem.Text = "Über uns";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 381);
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(560, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 403);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.download);
            this.Controls.Add(this.format);
            this.Controls.Add(this.video_listbox);
            this.Controls.Add(this.link);
            this.Controls.Add(this.del_video);
            this.Controls.Add(this.add_video);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.path);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JustDownloader";
            this.format.ResumeLayout(false);
            this.format.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button add_video;
        private System.Windows.Forms.Button del_video;
        private System.Windows.Forms.TextBox link;
        private System.Windows.Forms.ListBox video_listbox;
        private System.Windows.Forms.RadioButton video_btn;
        private System.Windows.Forms.RadioButton audio_btn;
        private System.Windows.Forms.RadioButton audio_cover;
        private System.Windows.Forms.GroupBox format;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton YTMusic;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überUnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel download_progress_label;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

