using System.Threading.Tasks;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Repositories.ListRepositories
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRepositoriesService>
   {
      [Test]
      public async Task Good_Project_Name()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();

         //act
         var repositories = await SUT().GetAllRepositories(goodProjectName);

         //arrange
         CollectionAssert.IsNotEmpty(repositories);

         //print
         repositories.Print();
      }
   }
}