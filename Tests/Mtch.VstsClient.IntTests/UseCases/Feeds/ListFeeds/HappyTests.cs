using System.Threading.Tasks;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Feeds.ListFeeds
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IFeedsService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         var feeds = await SUT().GetAllFeeds();

         //arrange
         CollectionAssert.IsNotEmpty(feeds);

         //print
         feeds.Print();
      }
   }
}