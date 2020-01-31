using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Services;

namespace Mtch.VstsClient.IntTests.TestExtensions
{
   public static class GetAllRepositoriesExtension
   {
      public static async Task<IEnumerable<Repository>> GetAllRepositories(this IntegrationTestBase test, string projectName)
      {
         var service = new RepositoriesService(test.ClientSettings);
         var repositories = await service.GetAllRepositories(projectName);
         return repositories;
      }
   }
}