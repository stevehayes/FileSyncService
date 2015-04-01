using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace FileSyncService
{
    public class FileSyncBase
    {
        public FileSyncBase()
        {
            LocalRootPath = ConfigurationManager.AppSettings["localRootPath"];
            RemoteRootPath = ConfigurationManager.AppSettings["rocalRootPath"];
        }

        public string LocalRootPath { get; set; }

        public string RemoteRootPath { get; set; }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
