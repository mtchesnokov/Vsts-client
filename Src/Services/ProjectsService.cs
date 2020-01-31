using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Config;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.Interfaces.Helpers;
using Mtch.VstsClient.Services.Helpers;

namespace Mtch.VstsClient.Services
{
   /// <summary>
   ///    Implementation of <see cref="IProjectsService" />
   /// </summary>
   public class ProjectsService : IProjectsService
   {
      private readonly IObjectHttpService _httpService;

      #region ctor

      public ProjectsService(ClientSettings clientSettings) : this(new ObjectHttpService(clientSettings))
      {
      }

      internal ProjectsService(IObjectHttpService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public Project[] Value { get; set; }
      }

      public async Task<IEnumerable<Project>> GetAllProjects()
      {
         var httpResponse = await _httpService.Get<HttpResponse>("/_apis/projects");
         return httpResponse.Value;
      }
   }
}