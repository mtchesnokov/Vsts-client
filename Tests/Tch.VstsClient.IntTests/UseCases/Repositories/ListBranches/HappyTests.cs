using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Repositories.ListBranches
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRepositoriesService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();
         var goodRepositoryId = "af0ffbfd-f163-4846-89e3-3e3f27f7a2e1";//this.GetGoodRepository(goodProjectName).Id;

         //act
         var branches = await SUT().GetAllBranches(goodProjectName, goodRepositoryId);

         //arrange
         CollectionAssert.IsNotEmpty(branches);

         //print
         branches.Print();
      }
   }
}