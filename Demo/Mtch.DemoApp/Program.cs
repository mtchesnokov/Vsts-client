using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Mtch.VstsClient.Config;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.Services;

namespace Mtch.DemoApp
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

         IEnumerable<Repository> repositories = await service.GetAllRepositories(projectName);

         repositories.Print();
      }

      #endregion
   }
}