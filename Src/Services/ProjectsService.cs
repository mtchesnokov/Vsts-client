using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.Services
{
   public class ProjectsService : IProjectsService
   {
      private readonly IVstsClientService _vstsClientService;

      #region ctor

      public ProjectsService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings))
      {
      }

      internal ProjectsService(IVstsClientService vstsClientService)
      {
         _vstsClientService = vstsClientService;
      }

      #endregion

      private class HttpResponse
      {
         public Project[] Value { get; set; }
      }

      public async Task<IEnumerable<Project>> GetAllProjects()
      {
         var httpResponse = await _vstsClientService.Get<HttpResponse>("/_apis/projects");
         return httpResponse.Value;
      }
   }
}