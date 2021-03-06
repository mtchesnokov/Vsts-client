﻿using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.Builds.ListBuilds
{
   public class HappyTests : IntegrationTestBase<IBuildsService>
   {
      [Test]
      public async Task Get_All_Builds()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();

         //act
         var builds = await SUT().GetAllBuilds(goodProjectName);

         //arrange
         CollectionAssert.IsNotEmpty(builds);

         //print
         builds.Print();
      }

      [Test]
      public async Task Get_All_Builds_For_Specific_Build_Definition()
      {
         //arrange
         var goodProjectName = this.GetGoodProjectName();
         var goodBuildDefinitionName = this.GetAllBuildDefinitionNames(goodProjectName).First();

         //act
         var builds = await SUT().GetAllBuilds(goodProjectName, goodBuildDefinitionName);

         //arrange
         CollectionAssert.IsNotEmpty(builds);

         //print
         builds.Print();
      }
   }
}