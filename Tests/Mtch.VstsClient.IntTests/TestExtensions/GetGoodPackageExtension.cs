using System.Linq;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Services;

namespace Mtch.VstsClient.IntTests.TestExtensions
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