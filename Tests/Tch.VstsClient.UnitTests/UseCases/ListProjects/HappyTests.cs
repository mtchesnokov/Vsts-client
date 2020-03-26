using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.UnitTests.Fakes;
using Tch.VstsClient.UnitTests.TestExtensions;

namespace Tch.VstsClient.UnitTests.UseCases.ListProjects
{
   public class HappyTests : UnitTestBase
   {
      [SetUp]
      public void SetUp2()
      {
         var fakeService = this.Overwrite<IHttpService, FakeHttpService1>();

         fakeService.ResponseModel = new[]
         {
            new Project {Id = "1", Name = "Project1"},
            new Project {Id = "2", Name = "Project2"},
            new Project {Id = "3", Name = "Project3"}
         };
      }

      [Test]
      public async Task HappyCase()
      {
         //arrange
         var clientSettings = new ClientSettings("Organization", "AccessToken");
         var sut = Container.With(clientSettings).GetInstance<IProjectsService>();

         //act
         var projects = await sut.GetAllProjects();

         //assert
         CollectionAssert.IsNotEmpty(projects);

         //print
         projects.Print();
      }
   }
}