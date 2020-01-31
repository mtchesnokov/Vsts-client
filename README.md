Welcome to VSTS client
=============================

## Introduction

This repo contains a simple .Net client for Azure DevOps Services (aka Visual Studio Team Services) REST API. 

 The client consits has the following functionality:

* [List projects in organization](#list-projets-in-organization)
* [List repositories in project](#list-repositories-in-project)
* [List feeds](#list-proejcts-)
* [List Nuget packages in feed](#list-proejcts-)
* [List builds definitions and builds in project](#list-proejcts-)
* [List commits in repository](#list-proejcts-)


## List projects in organization

The following code snippet shos how to get the overview of available projects in your organization:

```
var clientSettings = new ClientSettings
{
   OrganizationName = "Your organization name",
   AccessToken = "Your personal access token",
};

IProjectsService service = new ProjectsService(clientSettings);

IEnumerable<Project> projects = await service.GetAllProjects();
```

In the code example above, in order to be able to connect to the DevOps REST Api we need 
to provide two variables: 
* your organization name
* your personal access token configured with appropriate scopes


## List repositories in project

The following code snippet shos how to get the overview of available repositories (GIT) in your project:

```
string projectName = "Your project name";

IRepositoriesService service = new RepositoriesService(clientSettings);

IEnumerable<Repository> repositories = await service.GetAllRepositories(projectName);
```
