using System.Collections.Generic;
using System.Linq;
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
         (
            organizationName: OwnConfigurationManager.GetAppSetting("organizationName"),
            accessToken: OwnConfigurationManager.GetAppSetting("accessToken")
         );

         #region Get projects in organization

         IProjectsService projectsService = new ProjectsService(clientSettings);

         IEnumerable<Project> projects = await projectsService.GetAllProjects();

         projects.Print();

         #endregion

         #region Get repositories in project

         string projectName = projects.First().Name;

         IRepositoriesService repositoriesService = new RepositoriesService(clientSettings);

         IEnumerable<Repository> repositories = await repositoriesService.GetAllGitRepositories(projectName);

         repositories.Print();

         #endregion

         #region Get branches in repo

         string repositoryId = repositories.First().Id;

         IEnumerable<Branch> branches = await repositoriesService.GetAllBranches(projectName, repositoryId);

         branches.Print();

         #endregion

         #region Get all commits in branch

         string branchName = branches.First().Name;

         int top = 100;

         IEnumerable<Commit> commits = await repositoriesService.GetAllCommits(projectName, repositoryId, branchName, top);

         commits.Print();

         #endregion

         #region Get all build definitions in project

         IBuildsService buildsService = new BuildsService(clientSettings);

         IEnumerable<BuildDefinition> buildDefinitions = await buildsService.GetAllBuildDefinitions(projectName);

         buildDefinitions.Print();

         #endregion

         #region Get builds in build definition

         string buildDefinitionName = buildDefinitions.First().Name;

         IEnumerable<Build> builds = await buildsService.GetAllBuilds(projectName, buildDefinitionName);

         builds.Print();

         #endregion

         #region Get nuget feeds

         IPackagesService packagesService = new PackagesService(clientSettings);

         IEnumerable<PackageFeed> feeds = await packagesService.GetAllFeeds();

         feeds.Print();

         #endregion

         #region Get all packages in feed

         string feedName = feeds.First().Name;

         IEnumerable<Package> packages = await packagesService.GetAllPackages(feedName);

         packages.Print();

         #endregion

         #region Get all packages in feed

         string packageId = packages.First().Id;

         IEnumerable<PackageVersion> packageVersions = await packagesService.GetAllPackageVersions(feedName, packageId);

         packageVersions.Print();

         #endregion
      }
   }
}