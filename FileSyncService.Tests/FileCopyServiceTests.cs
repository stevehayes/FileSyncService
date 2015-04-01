using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileCopyServiceTests
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
        }

        [Test]
        public void Should_create_new_file()
        {
            var createdEvent = new FileSystemEventArgs(WatcherChangeTypes.Created, _localRootPath, _fileName);
            CreateFile();

            _fileCopyService.CopyFile(createdEvent);

            Assert.That(File.Exists(_localRootPath + "\\SteveHayes\\" + _fileName + ".txt"));
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
