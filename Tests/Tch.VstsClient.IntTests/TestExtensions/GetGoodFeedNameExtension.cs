using System.Linq;
using Tch.VstsClient.Services;

namespace Tch.VstsClient.IntTests.TestExtensions
{
   public static class GetGoodFeedNameExtension
   {
      public static string GetGoodFeedName(this IntegrationTestBase test)
      {
         var service = new PackagesService(test.ClientSettings);
         var feeds = service.GetAllFeeds().GetAwaiter().GetResult();
         return feeds.First().Name;
      }
   }
}