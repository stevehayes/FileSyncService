using System;
using System.IO;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileRenameServiceTests : FileSyncServiceTestBase
    {
        private FileRenameService _fileRenameService;
        private string _localRootPath;
        private string _fileName;

        [TestFixtureSetUp]
        public void Setup()
        {
            _fileRenameService = new FileRenameService();
            _localRootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _fileName = string.Format("FileSyncFile-{0}", Guid.NewGuid());
            CreateFile(_fileName);
        }

        [Test]
        public void Should_rename_file()
        {
            var newFileName = string.Format("Renamed-file-{0}.txt", Guid.NewGuid());
            var renameEvent = new RenamedEventArgs(WatcherChangeTypes.Renamed, _localRootPath, newFileName, _fileName);
            _fileRenameService.RenameFile(renameEvent);
            Assert.That(File.Exists(_localRootPath + "\\SteveHayes\\" + newFileName));
        }
    }
}
