using System;
using System.Collections.Generic;
using System.Linq;
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
   ///    Implementation of <see cref="IBuildsService" />
   /// </summary>
   public class BuildsService : IBuildsService
   {
      private readonly IObjectHttpService _httpService;

      #region ctor

      public BuildsService(ClientSettings clientSettings) : this(new ObjectHttpService(clientSettings))
      {
      }

      internal BuildsService(IObjectHttpService httpService)
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

      public async Task<IEnumerable<string>> GetAllBuildDefinitionNames(string projectName)
      {
         var builds = await GetAllBuilds(projectName, string.Empty);
         return builds.Select(x => x.Definition?.Name).Where(s => !string.IsNullOrEmpty(s)).Distinct();
      }
   }
}