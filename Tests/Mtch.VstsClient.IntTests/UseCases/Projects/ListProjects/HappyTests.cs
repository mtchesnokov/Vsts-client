using System.Threading.Tasks;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Projects.ListProjects
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IProjectsService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         var projects = await SUT().GetAllProjects();

         //arrange
         CollectionAssert.IsNotEmpty(projects);

         //print
         projects.Print();
      }
   }
}