using System.Collections.Generic;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.Services;

namespace Mtch.VstsClient.IntTests.TestExtensions
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