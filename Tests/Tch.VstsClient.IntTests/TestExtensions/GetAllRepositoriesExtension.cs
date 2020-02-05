using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Services;

namespace Tch.VstsClient.IntTests.TestExtensions
{
   public static class GetAllRepositoriesExtension
   {
      public static async Task<IEnumerable<Repository>> GetAllRepositories(this IntegrationTestBase test, string projectName)
      {
         var service = new RepositoriesService(test.ClientSettings);
         var repositories = await service.GetAllGitRepositories(projectName);
         return repositories;
      }
   }
}