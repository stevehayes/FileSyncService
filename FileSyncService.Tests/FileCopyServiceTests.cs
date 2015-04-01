using System;
using System.IO;
using Moq;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileCopyServiceTests
    {
        private FileCopyService _fileCopyService;

        [TestFixtureSetUp]
        public void Setup()
        {
            _fileCopyService = new FileCopyService();
        }

        [Test]
        public void Should_create_new_file()
        {
            var createdEvent = new FileSystemEventArgs(WatcherChangeTypes.Created, @"C:\SteveHayes\SyncFileExample", "Steve-" + Guid.NewGuid());
            _fileCopyService.CopyFile(createdEvent);
            Assert.That(_fileCopyService.DirectoryExists(createdEvent.FullPath));
        }
    }
}
