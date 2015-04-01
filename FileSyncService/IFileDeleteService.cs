using System.IO;

namespace FileSyncService
{
    public interface IFileDeleteService
    {
        void DeleteFile(FileSystemEventArgs e);
    }
}