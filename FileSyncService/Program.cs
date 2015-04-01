using System.ServiceProcess;
using Ninject;

namespace FileSyncService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            IKernel kernel = new StandardKernel(new FileSyncModule());
            var servicesToRun = new ServiceBase[] 
                                              { 
                                                  new FileSyncService(kernel.Get<FileSyncOrchestrator>()) 
                                              };
            ServiceBase.Run(servicesToRun);
        }
    }
}
