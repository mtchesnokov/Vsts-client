using System.Linq;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Services;

namespace Mtch.VstsClient.IntTests.TestExtensions
{
   public static class GetGoodRepositoryExtension
   {
      public static Repository GetGoodRepository(this IntegrationTestBase test, string projectName)
      {
         var service = new RepositoriesService(test.ClientSettings);
         var feeds = service.GetAllRepositories(projectName).GetAwaiter().GetResult();
         return feeds.First();
      }
   }
}