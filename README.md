# Welcome to VSTS REST API client 

## Introduction

This GIT repository contains a simple .Net client for Azure DevOps Services (aka Visual Studio Team Services) REST API. 

## Getting started

In order to be able to connect to Azure DevOps Services, the client code should provide the following two parameters:

* `organization name`
* `personal access token` configured with appropriate scopes

Here `organization name`(as the name implies) is the name of your organization. The latter, `personal access token` 
can be created via Web UI. Please be aware that the token can be created with one or several scopes, so please be ensure
that the required scope is granted for the operation you want to perform. 

## Code examples

 The client allows the following:

* [List projects in organization](#list-projects-in-organization)
* [List repositories in project](#list-repositories-in-project)
* [List branches in repository](#list-branches-in-repository)
* [List commits in branch](#list-commits-in-branch)
* [List build definitions in project](#list-build-definitions-in-project)
* [List builds in build definition](#list-builds-in-build-definition)
* [List Nuget feeds](#list-nuget-feeds)
* [List Nuget packages in feed](#list-nuget-packages-in-feed)
* [List versions of Nuget package](#list-versions-of-nuget-package)


### List projects in organization

The following code snippet shows how to get projects:

```cs
ClientSettings clientSettings = new ClientSettings
{
   OrganizationName = "Your organization name",
   AccessToken = "Your personal access token",
};

IProjectsService projectsService = new ProjectsService(clientSettings);

IEnumerable<Project> projects = await projectsService.GetAllProjects();
```


### List repositories in project

The following code snippet shows how to get repositories (GIT) in selected project:

```
IRepositoriesService repositoriesService = new RepositoriesService(clientSettings);

IEnumerable<Repository> repositories = await repositoriesService.GetAllGitRepositories(projectName);
```

### List branches in repository

The following code snippet shows how to get branches in selected repository:

```
IRepositoriesService repositoriesService = new RepositoriesService(clientSettings);

IEnumerable<Branch> branches = await repositoriesService.GetAllBranches(projectName, repositoryId);
```

### List commits in branch

The following code snippet shows how to get commits in selected branch:

```
IRepositoriesService repositoriesService = new RepositoriesService(clientSettings);

IEnumerable<Commit> commits = await repositoriesService.GetAllCommits(projectName, repositoryId, branchName, top);
```

### List build definitions in project

The following code snippet shows how to get build definitions in selected project:

```
IBuildsService buildsService = new BuildsService(clientSettings);

IEnumerable<BuildDefinition> buildDefinitions = await buildsService.GetAllBuildDefinitions(projectName);
```

### List builds in build definition

The following code snippet shows how to get builds in selected build definition:

```
IBuildsService buildsService = new BuildsService(clientSettings);

IEnumerable<Build> builds = await buildsService.GetAllBuilds(projectName, buildDefinitionName);
```

### List Nuget feeds

The following code snippet shows how to get Nuget feeds:

```
IPackagesService packagesService = new PackagesService(clientSettings);

IEnumerable<PackageFeed> feeds = await packagesService.GetAllFeeds();
```

### List Nuget packages in feed

The following code snippet shows how to get Nuget packages in feed:

```
IPackagesService packagesService = new PackagesService(clientSettings);

IEnumerable<Package> packages = await packagesService.GetAllPackages(feedName);
```

### List versions of Nuget package

The following code snippet shows how to get Nuget package versions:

```
IPackagesService packagesService = new PackagesService(clientSettings);

IEnumerable<PackageVersion> packageVersions = await packagesService.GetAllPackageVersions(feedName, packageId);
```