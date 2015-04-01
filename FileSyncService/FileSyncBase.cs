using System;
using System.IO;

namespace FileSyncService
{
    public class FileSyncBase
    {
        public FileSyncBase()
        {
            LocalRootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Directory.CreateDirectory(LocalRootPath + "\\SteveHayes");
            RemoteRootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SteveHayes";
        }

        public string LocalRootPath { get; set; }

        public string RemoteRootPath { get; set; }
    }
}
