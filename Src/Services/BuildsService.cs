using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.Services
{
   public class BuildsService : IBuildsService
   {
      private readonly IVstsClientService _httpService;

      #region ctor

      public BuildsService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings))
      {
      }

      internal BuildsService(IVstsClientService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public Build[] Value { get; set; }
      }

      public async Task<IEnumerable<Build>> GetAllBuilds(string projectName, string buildDefinitionName)
      {
         Build[] allBuilds;

         try
         {
            var httpResponse = await _httpService.Get<HttpResponse>($"/{projectName}/_apis/build/builds?api-version=5.0");
            allBuilds = httpResponse.Value;
         }
         catch (BadStatusCodeReturned)
         {
            throw new ProjectNotFoundException {ProjectName = projectName};
         }

         if (string.IsNullOrEmpty(buildDefinitionName))
         {
            return allBuilds;
         }

         return allBuilds.Where(b => string.Equals(b.Definition?.Name, buildDefinitionName, StringComparison.InvariantCultureIgnoreCase));
      }
   }
}