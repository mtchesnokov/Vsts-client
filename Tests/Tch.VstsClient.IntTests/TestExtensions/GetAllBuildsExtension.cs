using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Services;

namespace Tch.VstsClient.IntTests.TestExtensions
{
   public static class GetAllBuildsExtension
   {
      public static async Task<IEnumerable<Build>> GetAllBuilds(this IntegrationTestBase test, string projectName, string buildDefinitionName = null)
      {
         IBuildsService service = new BuildsService(test.ClientSettings);
         var builds = await service.GetAllBuilds(projectName, buildDefinitionName);
         return builds;
      }

      public static IEnumerable<string> GetAllBuildDefinitionNames(this IntegrationTestBase test, string projectName)
      {
         var service = new BuildsService(test.ClientSettings);
         var buildDefinitionNames = service.GetAllBuilds(projectName, string.Empty).GetAwaiter().GetResult()
            .Select(x => x.Definition?.Name).Where(s => !string.IsNullOrEmpty(s)).Distinct();
         return buildDefinitionNames;
      }
   }
}