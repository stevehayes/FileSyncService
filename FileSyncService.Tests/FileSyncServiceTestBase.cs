using System;
using System.IO;

namespace FileSyncService.Tests
{
    public class FileSyncServiceTestBase
    {
        public FileSyncServiceTestBase()
        {
            RemoteRootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SteveHayes\\";
        }

        public string RemoteRootPath { get; set; }

        public void CreateFile(string fileName)
        {
            var path = RemoteRootPath + fileName + ".txt";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                    writer.WriteLine(fileName);
                }
                else if (File.Exists(path))
                {
                    writer.WriteLine("-{0}-", fileName);
                }

                writer.Close();
            }
        }
    }
}
