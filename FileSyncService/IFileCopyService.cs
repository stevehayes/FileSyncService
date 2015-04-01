using System.IO;

namespace FileSyncService
{
    public interface IFileCopyService
    {
        void CopyFile(FileSystemEventArgs e);
    }
}