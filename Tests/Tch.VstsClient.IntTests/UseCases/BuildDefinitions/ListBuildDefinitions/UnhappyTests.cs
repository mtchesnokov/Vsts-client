﻿using NUnit.Framework;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.IntTests.TestExtensions;

namespace Tch.VstsClient.IntTests.UseCases.BuildDefinitions.ListBuildDefinitions
{
   public class UnhappyTests : IntegrationTestBase<IBuildDefinitionsService>
   {
      [Test]
      public void Bad_Project_Name()
      {
         //arrange
         var badProjectName = "abc";

         //act+arrange
         var exception = Assert.ThrowsAsync<ProjectNotFoundException>(() => SUT().GetAllBuildDefinitions(badProjectName));

         //print
         exception.Print();
      }
   }
}