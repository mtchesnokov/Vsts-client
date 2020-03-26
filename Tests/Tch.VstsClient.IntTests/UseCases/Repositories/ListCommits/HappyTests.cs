using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Repositories.ListCommits
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IRepositoriesService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();
         var goodRepository = this.GetGoodRepository(goodProjectName);

         //act
         var repositories = await SUT().GetAllCommits(goodProjectName, goodRepository.Id, "master", 3);

         //arrange
         CollectionAssert.IsNotEmpty(repositories);

         //print
         Console.WriteLine($"Project: {goodProjectName}");
         Console.WriteLine($"Repository: {goodRepository.Name}");
         repositories.Print();
      }
   }
}