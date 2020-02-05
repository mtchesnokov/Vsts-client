using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Repositories.ListRepositories
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRepositoriesService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();

         //act
         var repositories = await SUT().GetAllGitRepositories(goodProjectName);

         //arrange
         CollectionAssert.IsNotEmpty(repositories);

         //print
         repositories.Print();
      }
   }
}