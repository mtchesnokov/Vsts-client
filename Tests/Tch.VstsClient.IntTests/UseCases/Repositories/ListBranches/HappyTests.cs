using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Repositories.ListBranches
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
         var branches = await SUT().GetAllBranches(goodProjectName, goodRepository.Id);

         //arrange
         CollectionAssert.IsNotEmpty(branches);

         //print
         Console.WriteLine($"Project: {goodProjectName}");
         Console.WriteLine($"Repository: {goodRepository.Name}");
         branches.Print();
      }
   }
}