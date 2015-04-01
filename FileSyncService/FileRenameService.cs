using System;
using System.IO;

namespace FileSyncService
{
    public class FileRenameService : FileSyncBase, IFileRenameService
    {
        public void RenameFile(RenamedEventArgs e)
        {
            try
            {
                var localRootPath = e.FullPath;
                var remoteRootPath = e.FullPath.Replace(LocalRootPath, RemoteRootPath);
                var directoryExists = Directory.Exists(localRootPath);
                
                if (directoryExists)
                {
                    Directory.Move(localRootPath, remoteRootPath);
                }
                else
                {
                    File.Move(localRootPath, remoteRootPath);
                }
            }
            catch
            {
                // DoLogging() 
            }
        }
    }
}
