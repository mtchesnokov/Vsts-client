using Mtch.VstsClient.Domain.Exceptions;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Builds.ListBuildDefinitions
{
   public class UnhappyTests : IntegrationTestBase<IBuildsService>
   {
      [Test]
      public void Bad_Project_Name()
      {
         //arrange
         var badProjectName = "abc";

         //act+arrange
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => SUT().GetAllBuildDefinitionNames(badProjectName));

         //print
         exception.Print();
      }
   }
}