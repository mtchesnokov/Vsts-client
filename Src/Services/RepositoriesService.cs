using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.Services
{
   public class RepositoriesService : IRepositoriesService
   {
      private readonly IVstsClientService _httpService;

      #region ctor

      public RepositoriesService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings))
      {
      }

      internal RepositoriesService(IVstsClientService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public Repository[] Value { get; set; }
      }

      public async Task<IEnumerable<Repository>> GetAllGitRepositories(string projectName)
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