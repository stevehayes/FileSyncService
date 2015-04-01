using System.IO;

namespace FileSyncService
{
    public class FileDeleteService : FileSyncBase, IFileDeleteService
    {
        public void DeleteFile(FileSystemEventArgs e)
        {
            var remoteRoot = e.FullPath.Replace(LocalRootPath, RemoteRootPath);

            if (Directory.Exists(remoteRoot))
            {
                Directory.Delete(remoteRoot, true);
            }
            else
            {
                File.Delete(remoteRoot + ".txt");
            }
        }
    }
}
