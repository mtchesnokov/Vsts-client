using NUnit.Framework;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Repositories.ListCommits
{
   [Explicit]
   public class UnhappyTests : IntegrationTestBase<IRepositoriesService>
   {
      private string _projectName;
      private string _repositoryId;
      private string _branchName;

      [SetUp]
      public void SetUp()
      {
         _projectName = this.GetGoodProjectName();
         _repositoryId = this.GetGoodRepository(_projectName).Id;
         _branchName = "master";
      }

      [Test]
      public void Bad_Project_Name()
      {
         //arrange
         _projectName = "abcd";

         //act+assert
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => SUT().GetAllCommits(projectName: _projectName, repositoryId: _repositoryId, branchName: _branchName));

         //print 
         exception.Print();
      }

      [Test]
      public void Bad_Repository_Id()
      {
         //arrange
         _repositoryId = "abcd";

         //act+assert
         var exception = Assert.ThrowsAsync<RepositoryNotFoundException>(() => SUT().GetAllCommits(projectName: _projectName, repositoryId: _repositoryId, branchName: _branchName));

         //print 
         exception.Print();
      }

      [Test]
      public void Bad_Branch_Name()
      {
         //arrange
         _branchName = "abcd";

         //act+assert
         var exception = Assert.ThrowsAsync<BranchNotFoundException>(() => SUT().GetAllCommits(projectName: _projectName, repositoryId: _repositoryId, branchName: _branchName));

         //print 
         exception.Print();
      }
   }
}