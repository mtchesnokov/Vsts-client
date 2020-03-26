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
      private readonly ILocalExceptionService _localExceptionService;

      #region ctor

      public BuildsService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings), new LocalExceptionService())
      {
      }

      internal BuildsService(IVstsClientService httpService, ILocalExceptionService localExceptionService)
      {
         _httpService = httpService;
         _localExceptionService = localExceptionService;
      }

      #endregion

      private class HttpResponse1
      {
         public Build[] Value { get; set; }
      }

      private class HttpResponse2
      {
         public BuildDefinition[] Value { get; set; }
      }

      public async Task<IEnumerable<Build>> GetAllBuilds(string projectName, string buildDefinitionName)
      {
         Build[] allBuilds;

         try
         {
            var httpResponse = await _httpService.Get<HttpResponse1>($"/{projectName}/_apis/build/builds?api-version=5.0");
            allBuilds = httpResponse.Value;
         }
         catch (BadStatusCodeReturned e)
         {
            _localExceptionService.TryMatch<ProjectNotFoundException>(e, new {projectName});
            throw;
         }

         if (string.IsNullOrEmpty(buildDefinitionName))
         {
            return allBuilds;
         }

         return allBuilds.Where(b => string.Equals(b.Definition?.Name, buildDefinitionName, StringComparison.InvariantCultureIgnoreCase));
      }

      public async Task<IEnumerable<BuildDefinition>> GetAllBuildDefinitions(string projectName)
      {
         BuildDefinition[] allBuilds;

         try
         {
            var httpResponse = await _httpService.Get<HttpResponse2>($"/{projectName}/_apis/build/definitions?api-version=5.0");
            allBuilds = httpResponse.Value;
         }
         catch (BadStatusCodeReturned e)
         {
            _localExceptionService.TryMatch<ProjectNotFoundException>(e, new {projectName});
            throw;
         }

         return allBuilds;
      }
   }
}