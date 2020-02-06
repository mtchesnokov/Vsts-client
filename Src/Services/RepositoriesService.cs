using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.Services
{
   public class RepositoriesService : IRepositoriesService
   {
      private readonly IVstsClientService _httpService;

      #region ctor

      public RepositoriesService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings))
      {
      }

      internal RepositoriesService(IVstsClientService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse1
      {
         public Repository[] Value { get; set; }
      }

      private class HttpResponse2
      {
         public Branch[] Value { get; set; }
      }

      private class HttpResponse3
      {
         public CommitDto[] Value { get; set; }
      }

      private class CommitDto
      {
         public string CommitId { get; set; }

         public string Comment { get; set; }

         public AuthorDto Author { get; set; }
      }

      private class AuthorDto
      {
         public string Name { get; set; }

         public DateTime Date { get; set; }
      }

      public async Task<IEnumerable<Repository>> GetAllGitRepositories(string projectName)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse1>($"/{projectName}/_apis/git/repositories");
            return response.Value;
         }
         catch (NotFoundStatusCodeException)
         {
            throw new ProjectNotFoundException {ProjectName = projectName};
         }
      }

      public async Task<IEnumerable<Branch>> GetAllBranches(string projectName, string repositoryId)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse2>($"/{projectName}/_apis/git/repositories/{repositoryId}/refs?filter=heads/&api-version=5.1");
            return response.Value.Select(x => new Branch {Name = x.Name?.Replace("refs/heads/", "")});
         }
         catch (NotFoundStatusCodeException e)
         {
            if (e.Error.TypeKey.Contains("ProjectDoesNotExist"))
            {
               throw new ProjectNotFoundException {ProjectName = projectName};
            }

            throw new RepositoryNotFoundException {ProjectName = projectName, RepositoryId = repositoryId};
         }
      }

      public async Task<IEnumerable<Commit>> GetAllCommits(string projectName, string repositoryId, string branchName, int top)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse3>($"/{projectName}/_apis/git/repositories/{repositoryId}/commits?searchCriteria.$top={top}&searchCriteria.itemVersion.version={branchName}&api-version=5.1");

            return response.Value.Select(x => new Commit {Author = x.Author.Name, Date = x.Author.Date, Comment = x.Comment, Id = x.CommitId});
         }
         catch (NotFoundStatusCodeException e)
         {
            if (e.Error.TypeKey.Contains("ProjectDoesNotExist"))
            {
               throw new ProjectNotFoundException {ProjectName = projectName};
            }

            if (e.Error.TypeKey.Contains("GitRepositoryNotFoundException"))
            {
               throw new RepositoryNotFoundException {RepositoryId = repositoryId, ProjectName = projectName};
            }

            throw new BranchNotFoundException {ProjectName = projectName, RepositoryId = repositoryId, BranchName = branchName};
         }
      }
   }
}