using System.IO;

namespace FileSyncService
{
    public interface IFileSyncOrchestrator
    {
        void UpdateFileEvent(FileSystemEventArgs e);
        void CreateFileEvent(FileSystemEventArgs e);
        void DeleteFileEvent(FileSystemEventArgs e);
        void RenameFileEvent(RenamedEventArgs e);
    }
}