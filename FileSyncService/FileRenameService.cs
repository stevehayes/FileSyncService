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
                var localRootPathOld = e.OldFullPath;
                var remoteRootPath = string.Format("{0}\\{1}", RemoteRootPath, e.Name);
                var directoryExists = Directory.Exists(remoteRootPath);
                
                if (directoryExists)
                {
                    Directory.Move(localRootPath, remoteRootPath);
                }
                else
                {
                    File.Move(localRootPathOld + ".txt", remoteRootPath);
                }
            }
            catch
            {
                // DoLogging() 
            }
        }
    }
}
