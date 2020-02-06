using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Repositories.ListCommits
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRepositoriesService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();
         var goodRepositoryId = this.GetGoodRepository(goodProjectName).Id;

         //act
         var repositories = await SUT().GetAllCommits(goodProjectName, goodRepositoryId, "master", 3);

         //arrange
         CollectionAssert.IsNotEmpty(repositories);

         //print
         repositories.Print();
      }
   }
}