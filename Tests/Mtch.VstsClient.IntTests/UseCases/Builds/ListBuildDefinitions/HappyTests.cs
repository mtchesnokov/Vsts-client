using System.Threading.Tasks;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.IntTests.TestExtensions;
using NUnit.Framework;

namespace Mtch.VstsClient.IntTests.UseCases.Builds.ListBuildDefinitions
{
   public class HappyTests : IntegrationTestBase<IBuildsService>
   {
      [Test]
      public async Task Good_Project_Name()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();

         //act
         var buildDefinitionNames = await SUT().GetAllBuildDefinitionNames(goodProjectName);

         //arrange
         CollectionAssert.IsNotEmpty(buildDefinitionNames);

         //print
         buildDefinitionNames.Print();
      }
   }
}