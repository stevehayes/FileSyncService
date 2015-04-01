using Ninject.Modules;

namespace FileSyncService
{
    public class FileSyncModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileCopyService>().To<FileCopyService>();
            Bind<IFileDeleteService>().To<FileDeleteService>();
            Bind<IFileRenameService>().To<FileRenameService>();
            Bind<IFileSyncOrchestrator>().To<FileSyncOrchestrator>();
        }
    }
}
