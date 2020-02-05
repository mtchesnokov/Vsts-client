using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Builds.ListBuilds
{
   public class UnhappyTests : IntegrationTestBase<IBuildsService>
   {
      [Test]
      public void Bad_Project_Name()
      {
         //arrange
         var badProjectName = "abc";

         //act+arrange
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => SUT().GetAllBuilds(badProjectName));

         //print
         exception.Print();
      }

      [Test]
      public async Task Bad_Definition_Name()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();
         var badBuildDefinitionName = "abc";

         //act
         var builds = await SUT().GetAllBuilds(goodProjectName, badBuildDefinitionName);

         //arrange
         CollectionAssert.IsEmpty(builds);
      }
   }
}