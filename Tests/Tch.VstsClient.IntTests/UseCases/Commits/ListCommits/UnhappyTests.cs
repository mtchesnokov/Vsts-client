using NUnit.Framework;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Commits.ListCommits
{
   [Explicit]
   public class UnhappyTests : IntegrationTestBase<ICommitsService>
   {
      private string _projectName;
      private string _repositoryId;

      [SetUp]
      public void SetUp()
      {
         _projectName = this.GetGoodProjectName();
         _repositoryId = this.GetGoodRepository(_projectName).Id;
      }

      [Test]
      public void Bad_Project_Name()
      {
         //arrange
         _projectName = "abcd";

         //act+assert
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => SUT().GetAllCommits(_projectName, _repositoryId));

         //print 
         exception.Print();
      }

      [Test]
      public void Bad_Repository_Id()
      {
         //arrange
         _repositoryId = "abcd";

         //act+assert
         var exception = Assert.ThrowsAsync<RepositoryNotFoundException>(() => SUT().GetAllCommits(_projectName, _repositoryId));

         //print 
         exception.Print();
      }
   }
}