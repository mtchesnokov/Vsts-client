using System.Linq;

namespace Tch.VstsClient.IntTests.TestExtensions
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