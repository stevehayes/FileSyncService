using System.IO;

namespace FileSyncService
{
    public interface IFileRenameService
    {
        void RenameFile(RenamedEventArgs e);
    }
}
