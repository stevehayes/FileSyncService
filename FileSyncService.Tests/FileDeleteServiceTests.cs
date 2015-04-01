﻿using System;
using System.IO;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileDeleteServiceTests
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
            CreateFile();
        }

        [Test]
        public void Should_delete_a_test_file()
        {
            var deletedEvent = new FileSystemEventArgs(WatcherChangeTypes.Deleted, _localRootPath, _fileName);
            _fileDeleteService.DeleteFile(deletedEvent);
            Assert.That(!File.Exists(_localRootPath + "\\SteveHayes\\" + _fileName + ".txt"));
        }

        private void CreateFile()
        {
            var path = _localRootPath + "\\SteveHayes\\" + _fileName + ".txt";
            Directory.CreateDirectory(_localRootPath + "\\SteveHayes");
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                    writer.WriteLine(_fileName);
                }
                else if (File.Exists(path))
                {
                    writer.WriteLine("-{0}-", _fileName);
                }

                writer.Close();
            }
        }
    }
}
