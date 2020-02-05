using NUnit.Framework;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Repositories.ListRepositories
{
   [Explicit]
   public class UnhappyTests : IntegrationTestBase<IRepositoriesService>
   {
      [Test]
      public void Bad_Project_Name()
      {
         //arrange
         var badProjectName = "abcd";

         //act+assert
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => SUT().GetAllGitRepositories(badProjectName));

         //print 
         exception.Print();
      }
   }
}