using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WebClient clientdownload = new WebClient();
                Console.WriteLine("Bitte warten, Update wird heruntergeladen...");
                clientdownload.DownloadFile(new Uri("https://github.com/hyperpixel34/JustDownloader/releases/latest/download/release.zip"), "Release.zip");
                string zipPath = @"release.zip";
                string extractPath = @"";
                string directory = "Release";
                Console.WriteLine("Update wird installiert...");
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    var result = from currEntry in archive.Entries
                                 where Path.GetDirectoryName(currEntry.FullName) == directory
                                 where !String.IsNullOrEmpty(currEntry.Name)
                                 select currEntry;


                    foreach (ZipArchiveEntry entry in result)
                    {
                        if (entry.Name != "Updater.exe")
                        {
                            Console.WriteLine(entry.Name);
                            entry.ExtractToFile(Path.Combine(extractPath, entry.Name), true);
                        }
                    }
                }
            }
            catch
            {
                Console.ReadKey();
            }
            System.IO.File.Delete("Release.zip");
            System.Diagnostics.Process.Start("JustDownloader.exe");
            Environment.Exit(0);
        }
    }
}
