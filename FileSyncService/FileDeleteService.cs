﻿using System;
using System.IO;

namespace FileSyncService
{
    public class FileDeleteService : FileSyncBase, IFileDeleteService
    {
        public void DeleteFile(FileSystemEventArgs e)
        {
            try
            {
                var remoteRoot = e.FullPath.Replace(LocalRootPath, RemoteRootPath);
                var directoryExists = DirectoryExists(remoteRoot);

                if (directoryExists)
                {
                    Directory.Delete(remoteRoot, true);
                }
                else
                {
                    File.Delete(remoteRoot);
                }

            }
            catch
            {
                // DoLogging();
            }    
        }
    }
}