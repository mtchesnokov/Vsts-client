using System.Linq;

namespace Mtch.VstsClient.IntTests.TestExtensions
{
   public static class GetGoodProjectNameExtension
   {
      public static string GetGoodProjectName(this IntegrationTestBase test)
      {
         var projects = test.GetAllProjects();
         var projectName = projects.First().Name;
         return projectName;
      }
   }
}