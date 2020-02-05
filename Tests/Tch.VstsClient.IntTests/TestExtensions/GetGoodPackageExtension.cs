using System.Linq;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Services;

namespace Tch.VstsClient.IntTests.TestExtensions
{
   public static class GetGoodPackageExtension
   {
      public static Package GetGoodPackage(this IntegrationTestBase test, string feedName)
      {
         var service = new PackagesService(test.ClientSettings);
         var feeds = service.GetAllPackages(feedName).GetAwaiter().GetResult();
         return feeds.First();
      }
   }
}