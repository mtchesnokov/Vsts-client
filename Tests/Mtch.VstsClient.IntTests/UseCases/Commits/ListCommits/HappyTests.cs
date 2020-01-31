using System.Threading.Tasks;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Commits.ListCommits
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<ICommitsService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();
         var goodRepository = this.GetGoodRepository(goodProjectName);

         //act
         var repositories = await SUT().GetAllCommits(goodProjectName, goodRepository.Id);

         //arrange
         CollectionAssert.IsNotEmpty(repositories);

         //print
         repositories.Print();
      }
   }
}