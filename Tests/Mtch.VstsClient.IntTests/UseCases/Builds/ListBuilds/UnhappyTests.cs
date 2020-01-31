using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Exceptions;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Builds.ListBuilds
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