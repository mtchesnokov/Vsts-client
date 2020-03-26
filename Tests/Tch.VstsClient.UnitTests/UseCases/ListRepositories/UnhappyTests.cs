using NUnit.Framework;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.UnitTests.Fakes;
using Tch.VstsClient.UnitTests.TestExtensions;

namespace Tch.VstsClient.UnitTests.UseCases.ListRepositories
{
   public class UnhappyTests : UnitTestBase
   {
      [SetUp]
      public void SetUp2()
      {
         this.Overwrite<IHttpService, FakeHttpService2>();
      }

      [Test]
      public void ProjectNotFound()
      {
         //arrange
         var clientSettings = new ClientSettings("Organization", "AccessToken");
         var sut = Container.With(clientSettings).GetInstance<IRepositoriesService>();

         //act+assert
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => sut.GetAllGitRepositories("dummy"));

         //print
         exception.Print();
      }
   }
}