using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Projects.ListProjects
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IProjectsService>
   {
      [Test]
      public async Task List_All_Projects()
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