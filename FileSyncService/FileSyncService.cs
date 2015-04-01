using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace FileSyncService
{
    public partial class FileSyncService : ServiceBase
    {
        private FileSystemWatcher _fileSystemWatcher;
        private readonly IFileSyncOrchestrator _syncOrchestrator;
        private readonly string _localRootPath = ConfigurationManager.AppSettings["localRootPath"];
        private readonly EventLog _eventLog;

        public FileSyncService(IFileSyncOrchestrator syncOrchestrator)
        {
            _eventLog = new EventLog("FileSyncService");
            _syncOrchestrator = syncOrchestrator;
            _fileSystemWatcher = new FileSystemWatcher();
            InitializeComponent();
        }

        public void RenameEventRaised(object sender, RenamedEventArgs e)
        {
            _syncOrchestrator.RenameFileEvent(e);
        }

        protected override void OnStart(string[] args)
        {
            _eventLog.WriteEntry("File Sync Service has Started.");
            _fileSystemWatcher = ConfigureFileSyncWatcher();
        }

        protected override void OnStop()
        {
            _eventLog.WriteEntry("File Sync Service has Stopped.");
        }

        private FileSystemWatcher ConfigureFileSyncWatcher()
        {
            var syncFolder = new FileSystemWatcher
            {
                Path = _localRootPath,
                IncludeSubdirectories = true
            };

            ConfigureNotifyFilter(syncFolder);
            RegisterEvents();

            try
            {
                syncFolder.EnableRaisingEvents = true;
            }
            catch (Exception exception)
            {
                _eventLog.WriteEntry("File Sync Service did not start due to the following reason(s): " + exception.Message);
            }

            return syncFolder;
        }

        private static void ConfigureNotifyFilter(FileSystemWatcher syncFolder)
        {
            syncFolder.NotifyFilter = NotifyFilters.DirectoryName;
            syncFolder.NotifyFilter = syncFolder.NotifyFilter | NotifyFilters.FileName;
            syncFolder.NotifyFilter = syncFolder.NotifyFilter | NotifyFilters.Attributes;
        }

        private void RegisterEvents()
        {
            _fileSystemWatcher.Changed += ChangeEventRaised;
            _fileSystemWatcher.Created += CreateEventRaised;
            _fileSystemWatcher.Deleted += DeleteEventRaised;
            _fileSystemWatcher.Renamed += RenameEventRaised;
        }

        private void ChangeEventRaised(object sender, FileSystemEventArgs e)
        {
            _syncOrchestrator.UpdateFileEvent(e);
        }

        private void CreateEventRaised(object sender, FileSystemEventArgs e)
        {
            _syncOrchestrator.CreateFileEvent(e);
        }

        private void DeleteEventRaised(object sender, FileSystemEventArgs e)
        {
            _syncOrchestrator.DeleteFileEvent(e);
        }
    }
}
