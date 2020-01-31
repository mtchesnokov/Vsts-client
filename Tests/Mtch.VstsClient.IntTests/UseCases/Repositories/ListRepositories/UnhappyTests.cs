using Mtch.VstsClient.Domain.Exceptions;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Repositories.ListRepositories
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
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => SUT().GetAllRepositories(badProjectName));

         //print 
         exception.Print();
      }
   }
}