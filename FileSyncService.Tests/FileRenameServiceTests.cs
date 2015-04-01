using System;
using System.IO;
using Moq;
using NUnit.Framework;

namespace FileSyncService.Tests
{
    [TestFixture]
    public class FileRenameServiceTests
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
            CreateFile();
        }

        [Test]
        public void Should_rename_file()
        {
            var newFileName = string.Format("Renamed-file-{0}.txt", Guid.NewGuid());
            var renameEvent = new RenamedEventArgs(WatcherChangeTypes.Renamed, _localRootPath, newFileName, _fileName);
            _fileRenameService.RenameFile(renameEvent);
            Assert.That(File.Exists(_localRootPath + "\\SteveHayes\\" + newFileName));
        }

        private void CreateFile()
        {
            var path = _localRootPath + "\\" + _fileName + ".txt";
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
