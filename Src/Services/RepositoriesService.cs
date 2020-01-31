using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Config;
using Mtch.VstsClient.Domain.Exceptions;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.Interfaces.Helpers;
using Mtch.VstsClient.Services.Helpers;

namespace Mtch.VstsClient.Services
{
   /// <summary>
   /// Implementation of <see cref="IRepositoriesService"/>
   /// </summary>
   public class RepositoriesService : IRepositoriesService
   {
      private readonly IObjectHttpService _httpService;

      #region ctor

      public RepositoriesService(ClientSettings clientSettings) : this(new ObjectHttpService(clientSettings))
      {
      }

      internal RepositoriesService(IObjectHttpService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public Repository[] Value { get; set; }
      }

      public async Task<IEnumerable<Repository>> GetAllRepositories(string projectName)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse>($"/{projectName}/_apis/git/repositories");
            return response.Value;
         }
         catch (NotFoundStatusCodeException)
         {
            throw new ProjectNotFoundException {ProjectName = projectName};
         }
      }
   }
}