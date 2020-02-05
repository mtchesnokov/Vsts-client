using System.Linq;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Services;

namespace Tch.VstsClient.IntTests.TestExtensions
{
   public static class GetGoodRepositoryExtension
   {
      public static Repository GetGoodRepository(this IntegrationTestBase test, string projectName)
      {
         var service = new RepositoriesService(test.ClientSettings);
         var feeds = service.GetAllGitRepositories(projectName).GetAwaiter().GetResult();
         return feeds.First();
      }
   }
}