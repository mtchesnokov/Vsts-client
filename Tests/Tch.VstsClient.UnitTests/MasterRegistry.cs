using StructureMap;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.UnitTests
{
   internal class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<IProjectsService>()
            .Use<ProjectsService>()
            .SelectConstructor(() => new ProjectsService((IVstsClientService) null));

         For<IRepositoriesService>()
            .Use<RepositoriesService>()
            .SelectConstructor(() => new RepositoriesService((IVstsClientService)null, (ILocalExceptionService)null));

         For<IVstsClientService>()
            .Use<VstsClientService>()
            .SelectConstructor(() => new VstsClientService((IHttpService) null));

         For<ILocalExceptionService>().Use<LocalExceptionService>();
      }
   }
}