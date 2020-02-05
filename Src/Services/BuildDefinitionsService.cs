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
   public class BuildDefinitionsService : IBuildDefinitionsService
   {
      private readonly IVstsClientService _httpService;

      #region ctor

      public BuildDefinitionsService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings))
      {
      }

      internal BuildDefinitionsService(IVstsClientService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public BuildDefinition[] Value { get; set; }
      }

      public async Task<IEnumerable<BuildDefinition>> GetAllBuildDefinitions(string projectName)
      {
         BuildDefinition[] allBuilds;

         try
         {
            var httpResponse = await _httpService.Get<HttpResponse>($"/{projectName}/_apis/build/definitions?api-version=5.0");
            allBuilds = httpResponse.Value;
         }
         catch (BadStatusCodeReturned)
         {
            throw new ProjectNotFoundException {ProjectName = projectName};
         }

         return allBuilds;
      }
   }
}