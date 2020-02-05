using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Services;

namespace Tch.VstsClient.DemoApp
{
   internal class Program
   {
      private static async Task Main(string[] args)
      {
         var clientSettings = new ClientSettings
         {
            AccessToken = ConfigurationManager.AppSettings["accessToken"],
            OrganizationName = ConfigurationManager.AppSettings["organizationName"]
         };

         //await DemoProjects(clientSettings);

         await DemoRepositories(clientSettings);
      }

      #region Projects

      private static async Task DemoProjects(ClientSettings clientSettings)
      {
         IProjectsService service = new ProjectsService(clientSettings);

         IEnumerable<Project> projects = await service.GetAllProjects();

         projects.Print();
      }

      #endregion

      #region Repositories

      private static async Task DemoRepositories(ClientSettings clientSettings)
      {
         var projectName = "Your project name";

         IRepositoriesService service = new RepositoriesService(clientSettings);

         IEnumerable<Repository> repositories = await service.GetAllGitRepositories(projectName);

         repositories.Print();
      }

      #endregion
   }
}