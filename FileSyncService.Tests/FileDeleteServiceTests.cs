using System;
using System.IO;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileDeleteServiceTests
    {
        [Test]
        public void Should_delete_a_test_file()
        {
            var deleteService = new FileDeleteService();
            var deletedEvent = new FileSystemEventArgs(WatcherChangeTypes.Deleted, @"C:\SteveHayes\SyncFileExample", "Steve-Test-File");
            deleteService.DeleteFile(deletedEvent);
            Assert.That(!deleteService.DirectoryExists(deletedEvent.FullPath));
        }
    }
}
