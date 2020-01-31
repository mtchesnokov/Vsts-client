using System.Linq;
using Mtch.VstsClient.Services;

namespace Mtch.VstsClient.IntTests.TestExtensions
{
   public static class GetGoodFeedNameExtension
   {
      public static string GetGoodFeedName(this IntegrationTestBase test)
      {
         var service = new FeedsService(test.ClientSettings);
         var feeds = service.GetAllFeeds().GetAwaiter().GetResult();
         return feeds.First().Name;
      }
   }
}