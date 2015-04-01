using System;
using System.IO;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileDeleteServiceTests : FileSyncServiceTestBase
    {
        private FileDeleteService _fileDeleteService;
        private string _localRootPath;
        private string _fileName;

        [TestFixtureSetUp]
        public void Setup()
        {
            _fileDeleteService = new FileDeleteService();
            _localRootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _fileName = string.Format("FileSyncFile-{0}", Guid.NewGuid());
            CreateFile(_fileName);
        }

        [Test]
        public void Should_delete_a_test_file()
        {
            var deletedEvent = new FileSystemEventArgs(WatcherChangeTypes.Deleted, _localRootPath, _fileName);
            _fileDeleteService.DeleteFile(deletedEvent);
            Assert.That(!File.Exists(_localRootPath + "\\SteveHayes\\" + _fileName + ".txt"));
        }
    }
}
