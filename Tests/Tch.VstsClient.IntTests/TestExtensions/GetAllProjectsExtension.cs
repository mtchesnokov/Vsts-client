using System.Collections.Generic;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Services;

namespace Tch.VstsClient.IntTests.TestExtensions
{
   public static class GetAllProjectsExtension
   {
      public static IEnumerable<Project> GetAllProjects(this IntegrationTestBase test)
      {
         IProjectsService service = new ProjectsService(test.ClientSettings);
         var projects = service.GetAllProjects().GetAwaiter().GetResult();
         return projects;
      }
   }
}