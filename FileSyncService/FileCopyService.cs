using System;
using System.IO;

namespace FileSyncService
{
    public class FileCopyService : FileSyncBase, IFileCopyService
    {
        public void CopyFile(FileSystemEventArgs e)
        {
            try
            {
                var localPath = e.FullPath;
                var directoryExists = DirectoryExists(localPath);
                var remotePath = localPath.Replace(LocalRootPath, RemoteRootPath);

                if (directoryExists)
                {
                    Directory.CreateDirectory(remotePath);
                }
                else
                {
                    File.Copy(localPath, remotePath, true);
                }

            }
            catch
            {
                // DoLogging();
            }
        }
    }
}
