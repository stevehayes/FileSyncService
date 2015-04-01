using System.IO;
using Moq;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileSyncOrchestratorTests
    {
        private FileSyncOrchestrator _fileSyncOrchestrator;
        private Mock<IFileCopyService> _copyFileServiceMock;
        private Mock<IFileDeleteService> _deleteFileServiceMock;
        private Mock<IFileRenameService> _renameFileServiceMock;

        [TestFixtureSetUp]
        public void Setup()
        {
            _copyFileServiceMock = new Mock<IFileCopyService>();
            _deleteFileServiceMock = new Mock<IFileDeleteService>();
            _renameFileServiceMock = new Mock<IFileRenameService>();
            _fileSyncOrchestrator = new FileSyncOrchestrator(_copyFileServiceMock.Object, _deleteFileServiceMock.Object, _renameFileServiceMock.Object);
        }

        [Test]
        public void Should_call_into_the_file_copy_service()
        {
            _fileSyncOrchestrator.CreateFileEvent(It.IsAny<FileSystemEventArgs>());
            _copyFileServiceMock.Verify(copy => copy.CopyFile(It.IsAny<FileSystemEventArgs>()));

        }

        [Test]
        public void Should_call_into_file_delete_service()
        {
            _fileSyncOrchestrator.DeleteFileEvent(It.IsAny<FileSystemEventArgs>());
            _deleteFileServiceMock.Verify(delete => delete.DeleteFile(It.IsAny<FileSystemEventArgs>()));
        }

        [Test]
        public void Should_call_into_the_file_rename_service()
        {
            _fileSyncOrchestrator.RenameFileEvent(It.IsAny<RenamedEventArgs>());
            _renameFileServiceMock.Verify(rename => rename.RenameFile(It.IsAny<RenamedEventArgs>()));
        }
    }
}
