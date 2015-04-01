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
                var remotePath = localPath.Replace(LocalRootPath, RemoteRootPath);

                if (Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(remotePath);
                }
                else
                {
                    File.Copy(localPath + ".txt", remotePath + ".txt", true);
                }
            }
            catch
            {
                // DoLogging();
            }
        }
    }
}
