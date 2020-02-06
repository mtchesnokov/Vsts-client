using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Builds.ListBuildDefinitions
{
   public class HappyTests : IntegrationTestBase<IBuildsService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();

         //act
         var builds = await SUT().GetAllBuildDefinitions(goodProjectName);

         //arrange
         CollectionAssert.IsNotEmpty(builds);

         //print
         builds.Print();
      }
   }
}