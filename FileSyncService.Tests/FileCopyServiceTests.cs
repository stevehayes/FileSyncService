using System;
using System.IO;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileCopyServiceTests : FileSyncServiceTestBase
    {
        private FileCopyService _fileCopyService;
        private string _localRootPath;
        private string _fileName;

        [TestFixtureSetUp]
        public void Setup()
        {
            _localRootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _fileCopyService = new FileCopyService();
            _fileName = string.Format("FileSyncFile-{0}", Guid.NewGuid());
            CreateFile(_fileName);
        }

        [Test]
        public void Should_create_new_file()
        {
            var createdEvent = new FileSystemEventArgs(WatcherChangeTypes.Created, _localRootPath, _fileName);
            
            _fileCopyService.CopyFile(createdEvent);
            
            Assert.That(File.Exists(string.Format("{0}{1}.txt", RemoteRootPath, _fileName)));
        }
    }
}
