using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.NugetFeeds.ListFeeds
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<INugetFeedsService>
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