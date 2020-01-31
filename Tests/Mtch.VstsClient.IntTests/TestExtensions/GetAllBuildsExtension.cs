using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.Services;

namespace Mtch.VstsClient.IntTests.TestExtensions
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
         var buildDefinitionNames = service.GetAllBuildDefinitionNames(projectName).GetAwaiter().GetResult();
         return buildDefinitionNames;
      }
   }
}