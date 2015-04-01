using System.IO;

namespace FileSyncService
{
    public class FileSyncOrchestrator : IFileSyncOrchestrator
    {
        private readonly IFileCopyService _fileCopyService;
        private readonly IFileDeleteService _fileDeleteService;
        private readonly IFileRenameService _fileRenameService;

        public FileSyncOrchestrator(IFileCopyService fileCopyService, IFileDeleteService fileDeleteService, IFileRenameService fileRenameService)
        {
            _fileCopyService = fileCopyService;
            _fileDeleteService = fileDeleteService;
            _fileRenameService = fileRenameService;
        }

        public void UpdateFileEvent(FileSystemEventArgs e)
        {
            _fileCopyService.CopyFile(e);
        }

        public void CreateFileEvent(FileSystemEventArgs e)
        {
            _fileCopyService.CopyFile(e);
        }

        public void DeleteFileEvent(FileSystemEventArgs e)
        {
            _fileDeleteService.DeleteFile(e);
        }

        public void RenameFileEvent(RenamedEventArgs e)
        {
            _fileRenameService.RenameFile(e);
        }
    }
}
