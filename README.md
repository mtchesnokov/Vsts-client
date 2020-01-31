Welcome to VSTS client
=============================

## Getting started 

This repo contains a simple .Net client for Visual Studio Team Services (aka Azure DevOps Services) REST API. 

 The client consits of the following servies: 

*  `ListProjects` - service to get available projects

and allows the following:

* [List available projects](#list-proejcts-)


 ## Connecting to VSTS
 In order to connect to VSTS, the following configuration settings should be provided:
*  `OrganizationName` - name of the organization (required)
*  `AcessToken` - access token (required)

## List available projects

In the example code below, we show how to get the overview of available elements:

```
IListProjects service = new Services.ListProjects(ClientSettings);

IEnumerable<Project> projects = await service.GetAll();
```

With example result:

```
[
  {
    "Name": "IntraOffice"
  }
]

```