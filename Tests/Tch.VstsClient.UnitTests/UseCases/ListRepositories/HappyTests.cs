using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.UnitTests.Fakes;
using Tch.VstsClient.UnitTests.TestExtensions;

namespace Tch.VstsClient.UnitTests.UseCases.ListRepositories
{
   public class HappyTests : UnitTestBase
   {
      [SetUp]
      public void SetUp2()
      {
         var fakeService = this.Overwrite<IHttpService, FakeHttpService1>();

         fakeService.ResponseModel = new[]
         {
            new Repository {Id = "1", Name = "Repo1"},
            new Repository {Id = "2", Name = "Repo2"},
            new Repository {Id = "3", Name = "Repo3"}
         };
      }

      [Test]
      public async Task HappyCase()
      {
         //arrange
         var clientSettings = new ClientSettings("Organization", "AccessToken");
         var sut = Container.With(clientSettings).GetInstance<IRepositoriesService>();

         //act
         var projects = await sut.GetAllGitRepositories("dummy");

         //assert
         CollectionAssert.IsNotEmpty(projects);

         //print
         projects.Print();
      }
   }
}